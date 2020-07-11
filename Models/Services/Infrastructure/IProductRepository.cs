using System.Collections.Generic;
using AspNetCoreDynamicForm.Models.FieldTypes;
using AspNetCoreDynamicForm.Models.InputModels;
namespace AspNetCoreDynamicForm.Models.Services.Infrastructure
{
    public interface IProductRepository
    {
        List<BaseField> GetProductFields(int productId);
        void SaveProductFields(int productId, List<BaseField> fields);
    }
}