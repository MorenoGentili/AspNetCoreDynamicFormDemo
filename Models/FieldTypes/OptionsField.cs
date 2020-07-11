using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreDynamicForm.Models.FieldTypes
{
    public class OptionsField : BaseField
    {
        public string SelectedValue { get; set; }
        public string[] Options { get; set; }
    }
}