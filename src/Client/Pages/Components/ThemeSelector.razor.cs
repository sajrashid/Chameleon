using System.Collections.Generic;

namespace Chameleon.Client.Pages.Components
{
    public class Themes
    {
  
        public List<Theme> ThemeList { get; set; } = new ()
            {
                    new Theme ("auto", "🎨 auto"),
                    new Theme ("light", "🌝 light"),
                    new Theme ("dark", "🌚 dark"),
                    new Theme ("valentine", "🌸 valentine"),
                    new Theme ("retro", "👴 retro"),
                    new Theme ("synthwave", "🌃 synthwave"),
                    new Theme ("cyberpunk", "🤖 cyberpunk"),
                    new Theme ("black", "🏴 black"),
                    new Theme ("dracula", "🧛‍♂️ dracula"),
                    new Theme ("garden", "🌷 garden"),
                    new Theme ("halloween", "🎃 halloween"),
                    new Theme ("aqua", "🐟 aqua"),
                    new Theme ("cupcake", "🧁 cupcake"),
                    new Theme ("bumblebee", "🐝 bumblebee"),
                    new Theme ("pastel", "🖍 pastel"),
                    new Theme ("forest", "🧚‍♀️ forest"),
                    new Theme ("luxury", "💎 luxury"),
            };

        public string SelectedTheme { get; set; } = "cupcake";
    }

    public class Theme
    {
        public Theme(string value, string name)
        {
            Value = value;
            Name = name;
        }

        public string Value { get; set; }
        public string Name { get; set; }
    }
}