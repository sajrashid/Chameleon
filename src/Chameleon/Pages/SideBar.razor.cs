using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Pages
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
        void Navigate()
        {


        }
        public void ClickEventHandler()
        {
            InvokeAsync(() => IsSideBar = !IsSideBar);
            IsOverLay = !IsOverLay;
        }
    }
}
