using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Client.Pages.Components.Main
{
    public partial class MConsole
    {
        private bool expandedCss { get; set; } = true;
        private bool expandedPopupCss { get; set; } = true;
        private string fColorcss { get; set; } = "text-white";
        private string bkGrndcss { get; set; } = "bg-black";
        public ConsoleSelect ConsoleSelect { get; set; } = new();

        private void expandClick()
        {
            expandedCss = !expandedCss;
        }
    
        private void TogglePopup()
        {
            expandedPopupCss = !expandedPopupCss;
        }
        
        private async Task SelectFColorClick(ChangeEventArgs e)
        {
            fColorcss= e.Value.ToString();
            await InvokeAsync(StateHasChanged);
        }

      
        private async Task SelectBColorClick(ChangeEventArgs e)
        {
            bkGrndcss = e.Value.ToString();
            await InvokeAsync(StateHasChanged);
        }
    }
    public  class ConsoleSelect
    {
       

        public List<Colour> BColorList { get; set; } = new()
        {
            new Colour("bg-white", "White"),
            new Colour("bg-black", "Black"),
            new Colour("bg-gray-100", "Light Gray"),
            new Colour("bg-gray-900", "Dark Gray"),
            new Colour("BGreen", "Green"),
            new Colour("BYellow", "Yellow"),
            new Colour("BRed", "Red"),
            new Colour("BIndigo", "Indigo"),
        };
        public string SelectedBColor { get; set; } = "bg-black";

        public List<Colour> FColorList { get; set; } = new()
        {
            new Colour("text-white", "White"),
            new Colour("text-black", "Black"),
            new Colour("text-gray-100", "Light Gray"),
            new Colour("text-gray-900", "Dark Gray"),
            new Colour("FYellow", "Yellow"),
            new Colour("FGreen", "Green"),
            new Colour("FRed", "Red"),
            new Colour("FIndigo", "Indigo"),
        };
        public string SelectedFColor { get; set; } = "text-white";
    }
    public class Colour
    {
        public Colour(string value, string name)
        {
            Value = value;
            Name = name;
        }

        public string Value { get; set; }
        public string Name { get; set; }
    }
}
