using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreDynamicForm.Extensions
{
    public static class SelectListItemExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItem(this IEnumerable<string> items, string selectedValue)
        {
            if (items == null) {
                return new SelectListItem[0];
            }
            return items.Select(item => new SelectListItem(item, item, item == selectedValue)).ToArray();
        }
    }

}