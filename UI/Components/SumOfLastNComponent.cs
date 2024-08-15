using Livesplit.UI.Components;
using LiveSplit.Model;
using LiveSplit.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace LiveSplit.UI.Components
{
    public class SumOfLastNComponent : IComponent
    {
        
        protected InfoTextComponent InternalComponent { get; set; }
        
        public SumOfLastNSettings Settings { get; set; }
        
        protected LiveSplitState CurrentState { get; set; }

        public string ComponentName => "Sum Of Last N Splits";

        public float HorizontalWidth => InternalComponent.HorizontalWidth;
        public float MinimumWidth => InternalComponent.MinimumWidth;
        public float VerticalHeight => InternalComponent.VerticalHeight;
        public float MinimumHeight => InternalComponent.MinimumHeight;

        public float PaddingTop => InternalComponent.PaddingTop;
        public float PaddingLeft => InternalComponent.PaddingLeft;
        public float PaddingBottom => InternalComponent.PaddingBottom;
        public float PaddingRight => InternalComponent.PaddingRight;

        
        public IDictionary<string, Action> ContextMenuControls => null;

        private Time RunningTotalTime;
        private int NumTotaledSplits;
        private TimeSpan totalTimeSpan;
        void state_OnStart(object sender, EventArgs e)
        {
            RunningTotalTime = Time.Zero;
            
            NumTotaledSplits = 0;
        }

        void state_OnSplitChange(object sender, EventArgs e)
        {
            
            if (NumTotaledSplits < Settings.NumSplits)
            {
                NumTotaledSplits++;
                RunningTotalTime = CurrentState.Run[NumTotaledSplits - 1].SplitTime;
            } else
            {
                
                int EndIndex = CurrentState.CurrentSplitIndex - 1;
                int StartIndex = EndIndex - Settings.NumSplits;
                RunningTotalTime = CurrentState.Run[EndIndex].SplitTime - CurrentState.Run[StartIndex].SplitTime;
                Log.Info(RunningTotalTime.RealTime.Value.ToString("mm\\:ss\\.ff"));


            }

        }
        void state_OnSplitUndo(object sender, EventArgs e)
        {
            
            if (CurrentState.CurrentSplitIndex < Settings.NumSplits - 1)
            {
                NumTotaledSplits--;
                RunningTotalTime = CurrentState.Run[NumTotaledSplits - 1].SplitTime;
            }
            else
            {
                int EndIndex = CurrentState.CurrentSplitIndex - 1;
                int StartIndex = EndIndex - Settings.NumSplits;
                RunningTotalTime = CurrentState.Run[EndIndex].SplitTime - CurrentState.Run[StartIndex].SplitTime;

            }
        }
        void state_OnReset(object sender, TimerPhase e)
        {
            NumTotaledSplits = 0;
        }
        public SumOfLastNComponent(LiveSplitState state)
        {
            Settings = new SumOfLastNSettings();
            RunningTotalTime = Time.Zero;
            NumTotaledSplits = 0;
            TimingMethod timingMethod = state.CurrentTimingMethod;
            
            if(timingMethod == TimingMethod.RealTime)
            {
                totalTimeSpan = RunningTotalTime.RealTime.Value;
            } else
            {
                totalTimeSpan = RunningTotalTime.GameTime.Value;
            }
            InternalComponent = new InfoTextComponent($"Running Total ({Settings.NumSplits} Splits)", $@"{totalTimeSpan:mm\:ss\.ff}");
            
            state.OnStart += state_OnStart;
            state.OnSplit += state_OnSplitChange;
            state.OnUndoSplit += state_OnSplitUndo;
            state.OnReset += state_OnReset;
            CurrentState = state;
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            InternalComponent.NameLabel.HasShadow
                = InternalComponent.ValueLabel.HasShadow
                = state.LayoutSettings.DropShadows;

            InternalComponent.NameLabel.ForeColor = state.LayoutSettings.TextColor;
            InternalComponent.ValueLabel.ForeColor = state.LayoutSettings.TextColor;

            InternalComponent.DrawHorizontal(g, state, height, clipRegion);
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            
            InternalComponent.NameLabel.HasShadow
                = InternalComponent.ValueLabel.HasShadow
                = state.LayoutSettings.DropShadows;

            InternalComponent.NameLabel.ForeColor = state.LayoutSettings.TextColor;
            InternalComponent.ValueLabel.ForeColor = state.LayoutSettings.TextColor;

            InternalComponent.DrawVertical(g, state, width, clipRegion);
        }

        public Control GetSettingsControl(LayoutMode mode)
        {
            Settings.Mode = mode;
            return Settings;
        }

        public System.Xml.XmlNode GetSettings(System.Xml.XmlDocument document)
        {
            return Settings.GetSettings(document);
        }

        public void SetSettings(System.Xml.XmlNode settings)
        {
            Settings.SetSettings(settings);
        }

    
        
        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            InternalComponent.InformationName = $"Running Total ({Settings.NumSplits} Splits)";
            if (CurrentState.CurrentTimingMethod == TimingMethod.RealTime)
            {
                InternalComponent.InformationValue = $@"{RunningTotalTime.RealTime:mm\:ss\.ff}";
            }
            else
            {
                InternalComponent.InformationValue = $@"{RunningTotalTime.GameTime:mm\:ss\.ff}";
            }
            InternalComponent.Update(invalidator, state, width, height, mode);
        }

        
        public void Dispose()
        {
            CurrentState.OnStart -= state_OnStart;
            CurrentState.OnSplit -= state_OnSplitChange;
            CurrentState.OnUndoSplit -= state_OnSplitUndo;
            CurrentState.OnReset -= state_OnReset;
        }
        

        
        public int GetSettingsHashCode() => Settings.GetSettingsHashCode();
    }
}