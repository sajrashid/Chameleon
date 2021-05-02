using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Pages.Components
{
    public partial class ThemeSelector
    {
        private IList<Theme> ThemeList { get; set; } = new List<Theme>() {
            new Theme() { Id = 1, ThemeName = "John" },
            new Theme() { Id = 2, ThemeName = "Steve"},
            new Theme() { Id = 3, ThemeName = "Bill"},
            new Theme() { Id = 4, ThemeName = "Ram"},
            new Theme() { Id = 5, ThemeName = "Ron"}
        };
    }

    public class Theme
    {
        public int Id { get; set; }
        public string ThemeName { get; set; }
    }
}
