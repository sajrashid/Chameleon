using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Chameleon.Client.Pages.Components
{
    public partial class DataTable<T>
    {
        [Parameter]
        public List<T> ListModel { get; set; }
        [Parameter]
        public EventCallback<T> OnCanUpdateAsync { get; set; }
        [Parameter]
        public string TableCSS { get; set; }
        [Parameter]
        public string TheadCSS { get; set; }
        [Parameter]
        public string TrTheadCSS { get; set; }
        [Parameter]
        public string TbodyCSS { get; set; }
        [Parameter]
        public string TrTbodyCSS { get; set; }
        [Parameter]
        public string TdTrTbodyCss { get; set; }
        [Parameter]
        public string InputTdTrTbody { get; set; } = "text-center input-group-text";
        [Parameter]
        public string PTdTrTbodyCSS { get; set; } = "text-center";
        [Parameter]
        public string TrTableCss { get; set; }

        private enum AcceptedTypes
        {
            Int32, DateTime, Boolean, String
        }

        private List<PropertyInfo> properties;
        private List<string> propertiesValues;
        private List<string> focusedRowProperties;
        private string focusedProperty;
        AcceptedTypes currentType;
        int newInt;
        DateTime newDateTime;
        bool newBool;
        string newString;
        protected override void OnParametersSet()
        {
            properties = new();
            propertiesValues = new();
            focusedRowProperties = new();
            foreach (var prop in typeof(T).GetProperties())
            {
                properties.Add(prop);
            }
        }
        private async Task OnFocusOutAsync(PropertyInfo prop, T obj, AcceptedTypes type)
        {
            switch (type)
            {
                case AcceptedTypes.Int32:
                    prop.SetValue(obj, newInt);
                    break;
                case AcceptedTypes.DateTime:
                    prop.SetValue(obj, newDateTime);
                    break;
                case AcceptedTypes.Boolean:
                    prop.SetValue(obj, newBool);
                    break;
                default:
                    prop.SetValue(obj, newString);
                    break;
            }

            focusedProperty = string.Empty;
            await OnCanUpdateAsync.InvokeAsync(obj);
        }
        private bool isFocusedRowColumn(T rowObj, string prop)
        {
            if (focusedRowProperties.Count != 0)
            {
                for (int i = 0; i < focusedRowProperties.Count; i++)
                {
                    if (prop == focusedProperty)
                    {
                        if (properties[i].GetValue(rowObj, null).ToString() != focusedRowProperties[i])
                        {
                            return false;
                        }
                        return true;
                    }
                }
            }
            return false;
        }
    }
}