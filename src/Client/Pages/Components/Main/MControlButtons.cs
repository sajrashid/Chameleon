using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Client.Pages.Components.Main
{
    public class MControlButton
    {

        public List<MControlButton> HomeButtons = new()
        {
            new MControlButton("ALL", "ALL" , "btn btn-accent controlbtn"),
            new MControlButton("X", "X", "btn controlbtn"),
            new MControlButton("Y", "Y", "btn controlbtn"),
            new MControlButton("Z", "Z", "btn controlbtn"),

        };

        public MControlButton(string name, string text, string cssClass)
        {
            
            Name = name;
            Text = text;
            CssClass = cssClass;
        }
        public string Name { get; set; }
        public string CssClass { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public ElementReference ValueElem { get; set; }
    }
}
