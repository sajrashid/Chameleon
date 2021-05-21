using Chameleon.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Chameleon.Client.Pages.Components.Settings
{
    public partial class FavMachines
    {
        [Inject]
        private HttpClient Http { get; set; }

        public List<Machine> Machines { get; set; } = new List<Machine>();

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("In Class Task OnInitializedAsyn");
            //  Console.WriteLine($"enumurable: {MachinesEnumerbale.ToList()} ");
                Machines = await Http.GetFromJsonAsync<List<Machine>>("api/Machines");
            await InvokeAsync(StateHasChanged);
        }

        private int currentIndex;

        private void StartDrag(Machine item)
        {
            currentIndex = GetIndex(item);
            Console.WriteLine($"DragStart for {item.Id} index {currentIndex}");
        }

        private void ClickItem(Machine item)
        {
            currentIndex = GetIndex(item);
        }

        private int GetIndex(Machine item)
        {
            return Machines.FindIndex(a => a.Id == item.Id);
        }

        private void Drop(Machine item)
        {
            if (item != null)
            {
                Console.WriteLine($"Drop item {item.Name} ({item.Id})");
                var index = GetIndex(item);
                Console.WriteLine($"Drop index is {index}, move from {currentIndex}");
                // get current item
                var current = Machines[currentIndex];
                // remove game from current index
                Machines.RemoveAt(currentIndex);
                Machines.Insert(index, current);
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
}