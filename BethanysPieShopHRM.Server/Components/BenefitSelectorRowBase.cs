using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Components
{
    public class BenefitSelectorRowBase : ComponentBase
    {
        [Parameter]
        public BenefitModel Benefit { get; set; }

        [Parameter]
        public EventCallback<bool> OnTryAdjust { get; set; }   

        public async Task CheckBoxChanged(ChangeEventArgs e, BenefitModel benefit)
        {
            var newValue = (bool)e.Value;
            benefit.Selected = newValue;

            if (newValue)
            {
                benefit.StartDate = DateTime.Now;
                benefit.EndDate = DateTime.Now.AddYears(1);
            }
            await ChDate(true);
           
        }
        public async Task ChDate(bool State = false)
        {            
            await OnTryAdjust.InvokeAsync(State);
        }
    }
}
