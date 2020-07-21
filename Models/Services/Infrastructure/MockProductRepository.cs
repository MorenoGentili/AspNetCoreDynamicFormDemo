using System;
using System.Collections.Generic;
using AspNetCoreDynamicForm.Models.FieldTypes;
using AspNetCoreDynamicForm.Models.InputModels;
namespace AspNetCoreDynamicForm.Models.Services.Infrastructure
{
    public class MockProductRepository : IProductRepository
    {
        private Dictionary<int, List<BaseField>> inMemoryDatabase = GetInMemoryDatabase();

        public List<BaseField> GetProductFields(int productId)
        {
            if (inMemoryDatabase.ContainsKey(productId))
            {
                return inMemoryDatabase[productId];
            }
            throw new Exception("Product not found");
        }

        public void SaveProductFields(int productId, List<BaseField> fields)
        {
            if (fields == null)
            {
                throw new ArgumentException("Field list cannot be null");
            }
            inMemoryDatabase[productId] = fields;
        }

        private static Dictionary<int, List<BaseField>> GetInMemoryDatabase()
        {
            return new Dictionary<int, List<BaseField>> {
                {1, new List<BaseField> {
                    new ColorField { Name = "Primary color", Color = "#000000" },
                    new ColorField { Name = "Secondary color", Color = "#FFFF00" },
                    new TextField { Name = "Text on the front", Text = "Darmok and Jalad at Tanagra" },
                    new TextField { Name = "Text on the back", Text = "Alpha quadrant tour 1991" },
                    new OptionsField { Name = "Material", Options = new [] { "Linen", "Cotton", "Lycra" }, SelectedValue = "Cotton" },
                    new QuantityField { Name = "Quantity", Quantity = 1 }
                }}
            };
        }
    }
}