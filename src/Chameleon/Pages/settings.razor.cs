using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Chameleon.Pages
{
    public partial class Settings : ComponentBase
    {
        List<Game> Games = new List<Game> {
            new Game() { ID= "Game1", Text= "American Football"},
            new Game() { ID= "Game2", Text= "Badminton"  },
            new Game() { ID= "Game3", Text= "Basketball"  },
            new Game() { ID= "Game4", Text= "Cricket"},
            new Game() { ID= "Game5", Text= "Football" },
            new Game() { ID= "Game6", Text= "Golf"  },
            new Game() { ID= "Game7", Text= "Hockey"  },
            new Game() { ID= "Game8", Text= "Rugby" },
            new Game() { ID= "Game9", Text= "Snooker"  },
            new Game() { ID= "Game10", Text= "Tennis" },
            };
        int currentIndex;
        void StartDrag(Game item)
        {
            currentIndex = GetIndex(item);
            Console.WriteLine($"DragStart for {item.ID} index {currentIndex}");
        }

        void ClickItem(Game item)
        {
            currentIndex = GetIndex(item);
        }

        int GetIndex(Game item)
        {
            return Games.FindIndex(a => a.ID == item.ID);
        }

        void Drop(Game item)
        {
            if (item != null)
            {
                Console.WriteLine($"Drop item {item.Text} ({item.ID})");
                var index = GetIndex(item);
                Console.WriteLine($"Drop index is {index}, move from {currentIndex}");
                // get current item
                var current = Games[currentIndex];
                // remove game from current index
                Games.RemoveAt(currentIndex);
                Games.Insert(index, current);

                // update current selection
                currentIndex = index;
                InvokeAsync(StateHasChanged);
            }
            else
            {
                Console.WriteLine("Drop - null");
            }
        }

       
    }
    public class Game
    {
        public string ID { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            return Text;
        }

    }

}


