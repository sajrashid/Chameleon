﻿using Chameleon.Services;
using Data.shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Pages.Components.Settings
{
    public partial class FavMachines
    {

        private List<Machine> Machines { get; set; } = new List<Machine>();
        [Inject]
        private IApiService<List<Machine>> ApiService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            
            Machines = await ApiService.OnGet("http://localhost:5001/api/machines");
            await InvokeAsync(StateHasChanged);
        }

        int currentIndex;
        void StartDrag(Machine item)
        {
            currentIndex = GetIndex(item);
            Console.WriteLine($"DragStart for {item.Id} index {currentIndex}");
        }

        void ClickItem(Machine item)
        {
            currentIndex = GetIndex(item);
        }

        int GetIndex(Machine item)
        {
            return Machines.FindIndex(a => a.Id == item.Id);
        }

        void Drop(Machine item)
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
