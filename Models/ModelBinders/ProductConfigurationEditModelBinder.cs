using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreDynamicForm.Models.FieldTypes;
using AspNetCoreDynamicForm.Models.InputModels;
using AspNetCoreDynamicForm.Models.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCoreDynamicForm.Models.ModelBinders
{
    public class ProductConfigurationEditModelBinder : IModelBinder
    {
        private readonly IModelMetadataProvider modelMetadataProvider;
        private readonly IModelBinderFactory modelBinderFactory;
        public readonly IProductRepository productRepository;
        public ProductConfigurationEditModelBinder(IModelMetadataProvider modelMetadataProvider, IModelBinderFactory modelBinderFactory, IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            this.modelMetadataProvider = modelMetadataProvider;
            this.modelBinderFactory = modelBinderFactory;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (!int.TryParse(bindingContext.ValueProvider.GetValue("id").FirstValue, out int productId))
            {
                throw new Exception("The product id was not provided");
            }
            
            var editModel = new ProductConfigurationEditModel
            {
                Fields = productRepository.GetProductFields(productId)
            };

            for (int i = 0; i < editModel.Fields.Count; i++)
            {
                BaseField field = editModel.Fields[i];
                ModelMetadata modelMetadata = modelMetadataProvider.GetMetadataForType(field.GetType());
                IModelBinder modelBinder = modelBinderFactory.CreateBinder(new ModelBinderFactoryContext
                {
                    Metadata = modelMetadata,
                    CacheToken = modelMetadata
                });

                string modelName = $"{bindingContext.BinderModelName}.Fields[{i}]".TrimStart('.');
                using (var scope = bindingContext.EnterNestedScope(modelMetadata, modelName, modelName, field))
                {
                    await modelBinder.BindModelAsync(bindingContext);
                }
            }

            bindingContext.Result = ModelBindingResult.Success(editModel);
        }
    }
}