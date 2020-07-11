using System.Collections.Generic;
using System.Linq;
using AspNetCoreDynamicForm.Models.FieldTypes;
using AspNetCoreDynamicForm.Models.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDynamicForm.Models.InputModels
{
    [ModelBinder(typeof(ProductConfigurationEditModelBinder))]
    public class ProductConfigurationEditModel
    {
        public List<BaseField> Fields { get; set; } = new List<BaseField>();
    }
}