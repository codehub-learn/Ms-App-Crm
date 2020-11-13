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
        Product CreateProduct(ProductOptions productOptions);
        Product GetProductById(int id);
        List<Product> GetAllProduct();
        Product UpdateProduct(ProductOptions productOption, int id);
        bool DeleteProduct(int id);
    }
}
