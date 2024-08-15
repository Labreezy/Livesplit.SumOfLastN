using System;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.UI;

namespace Livesplit.UI.Components
{
    public partial class SumOfLastNSettings : UserControl
    {
        public int NumSplits { get; set; }
        public LayoutMode Mode { get; set; }

        public enum SumTimingMethod { CurrentComparison = 0, GameTime = 1, RealTime = 2}
        public SumOfLastNSettings()
        {
            
            InitializeComponent();
            
        }

        private void SumOfLastNSettings_Load(object sender, EventArgs e)
        {
            
            numSplitsNumUpDown.DataBindings.Clear();
            numSplitsNumUpDown.DataBindings.Add("Value", this, "NumSplits", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "Version", "1.0") ^
                SettingsHelper.CreateSetting<int>(document, parent, "NumSplits", 5);
        }
        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        public int GetSettingsHashCode()
        {
            return CreateSettingsNode(null, null);
        }
        public void SetSettings(XmlNode node)
        {
            var element = (XmlElement)node;
            NumSplits = SettingsHelper.ParseInt(element["NumSplits"], 1);

        }
    }
}
