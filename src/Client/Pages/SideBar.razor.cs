namespace Chameleon.Client.Pages
{
    public partial class SideBar
    {
        private bool IsSideBar { get; set; } = true;
        private bool IsOverLay { get; set; } = true;

        public void ChangeOverLayCssClass(MouseEventArgs e)
        {
            InvokeAsync(() => IsSideBar = !IsSideBar);
            IsOverLay = !IsOverLay;
        }

        public void Toggle()
        {
            InvokeAsync(() => IsSideBar = !IsSideBar);
            IsOverLay = !IsOverLay;
            StateHasChanged();
        }

        private void Navigate()
        {
        }

        public void ClickEventHandler()
        {
            InvokeAsync(() => IsSideBar = !IsSideBar);
            IsOverLay = !IsOverLay;
        }
    }
}