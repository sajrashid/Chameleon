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
        private bool isSideBar { get; set; } = true;
        private bool isOverLay { get; set; } = true;
        

        public void ChangeOverLayCssClass(MouseEventArgs e)
        {
            InvokeAsync(() => isSideBar = !isSideBar);
            isOverLay = !isOverLay;
        }

        public void Toggle()
        {
            InvokeAsync(() => isSideBar = !isSideBar);
            isOverLay = !isOverLay;
            StateHasChanged();
        }
    }
}
