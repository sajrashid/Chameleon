using Chameleon.Client.Pages.Components.Main;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Chameleon.Client.Pages
{
    public partial class Index 
    {
        public List<DyamicComp> ListComp { get; set; } = new()
        {
            new DyamicComp(0, typeof(Connect)),
            new DyamicComp(1, typeof(MControl)),
            new DyamicComp(2, typeof(MConsole)),
            new DyamicComp(3, typeof(Thermals)),
            new DyamicComp(4, typeof(Macros)),
            new DyamicComp(5, typeof(Tune)),
        };
        private  int count = 0;
        private string dropClass = "";

        private int currentIndex;

        private int GetIndex(DyamicComp item)
        {
            Console.WriteLine("myid:"+ item.Id);
            return ListComp.FindIndex(a => a.Id == item.Id);
        }

        protected  void StartDrag(DyamicComp item)
        {
           // if (item.Id == 2) { return; } //trying to cancel drag not happening here

            item.DropEnterCss = "start-drag";
            currentIndex = GetIndex(item);
            Console.WriteLine($"DragStart for {item.Id} index {currentIndex}");
        }
        private void DragEnter(DyamicComp item)
        {
            item.DropEnterCss = "drag-enter";
        }

        private void DragLeave(DyamicComp item)
        {
            item.DropEnterCss = "";
        }
        private void Drop(DyamicComp item)
        {
            item.DropEnterCss = "";

            dropClass = "";
            if (item != null)
            {
                //Console.WriteLine($"Drop item {item.Name} ({item.Id})");
                int index = GetIndex(item);
                Console.WriteLine($"Drop index is {index}, move from {currentIndex}");
                // get current item
                var current = ListComp[currentIndex];
                // remove game from current index
                ListComp.RemoveAt(currentIndex);
                ListComp.Insert(index, current);
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

    public class DyamicComp
    {
        public DyamicComp(int id, Type comp)
        {
            Id = id;
            MyComp = comp;
            DropEnterCss = string.Empty;
        }
        public int Id { get; set; }

        public Type MyComp { get; set; }

        public string DropEnterCss { get; set; }
    }
}
