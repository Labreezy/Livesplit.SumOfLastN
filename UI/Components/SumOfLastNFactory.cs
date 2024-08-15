using System;
using LiveSplit.Model;
using LiveSplit.UI.Components;

namespace Livesplit.UI.Components
{
    public class SumOfLastNFactory : IComponentFactory
    {
        public string ComponentName => "Sum Of Last N";

        public string Description => "Displays the sum of the last N completed splits.";

        // The sub-menu this component will appear under when adding the component to the layout.
        public ComponentCategory Category => ComponentCategory.Information;

        public IComponent Create(LiveSplitState state) => new SumOfLastNComponent(state);

        public string UpdateName => ComponentName;

        // Fill in this empty string with the URL of the repository where your component is hosted.
        // This should be the raw content version of the repository. If you're not uploading this
        // to GitHub or somewhere, you can ignore this.
        public string UpdateURL => "";

        // Fill in this empty string with the path of the XML file containing update information.
        // Check other LiveSplit components for examples of this. If you're not uploading this to
        // GitHub or somewhere, you can ignore this.
        public string XMLURL => UpdateURL + "";

        public Version Version => Version.Parse("0.1.0");
    }
}
