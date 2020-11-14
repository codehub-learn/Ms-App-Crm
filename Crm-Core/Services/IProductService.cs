using Crm_Core.Options;
using ModelCrm.Models;
using ModelCrm.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelCrm.Services
{
    public interface IProductService
    {
        ProductOptions CreateProduct(ProductOptions productOptions);
        ProductOptions GetProductById(int id);
        List<ProductOptions> GetAllProduct();
        ProductOptions UpdateProduct(ProductOptions productOption, int id);
        bool DeleteProduct(int id);
    }
}
