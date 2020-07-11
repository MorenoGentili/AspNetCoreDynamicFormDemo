using System.Collections.Generic;
using AspNetCoreDynamicForm.Models.InputModels;

namespace AspNetCoreDynamicForm.Models.Services.Application
{
    public interface IProductService
    {
        ProductConfigurationEditModel GetProductForEditing(int productId);
        void EditProduct(int productId, ProductConfigurationEditModel editModel);
    }
}