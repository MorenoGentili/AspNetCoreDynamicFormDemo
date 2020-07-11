using System.Collections.Generic;
using AspNetCoreDynamicForm.Models.InputModels;
using AspNetCoreDynamicForm.Models.Services.Infrastructure;

namespace AspNetCoreDynamicForm.Models.Services.Application
{
    public class MockProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public MockProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ProductConfigurationEditModel GetProductForEditing(int productId)
        {
            //This service generates some fields for the given productId
            var editModel = new ProductConfigurationEditModel() {
                Fields = productRepository.GetProductFields(productId)
            };
            return editModel;
        }

        public void EditProduct(int productId, ProductConfigurationEditModel editModel)
        {
            productRepository.SaveProductFields(productId, editModel.Fields);
        }

    }
}