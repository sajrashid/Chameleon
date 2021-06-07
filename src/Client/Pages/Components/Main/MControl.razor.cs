namespace Chameleon.Client.Pages.Components.Main
{
    public partial class MControl
    {
        private bool ExpandedCss { get; set; } = true;
        private bool RotateCss { get; set; } = false;

        private void ExpandClick()
        {
            ExpandedCss = !ExpandedCss;
            RotateCss = !RotateCss;
        }
    }
}