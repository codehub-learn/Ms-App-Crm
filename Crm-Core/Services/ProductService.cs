using Crm_Core.Options;
using Microsoft.EntityFrameworkCore;
using ModelCrm.CrmDbContext;
using ModelCrm.Models;
using ModelCrm.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelCrm.Services
{
    public class ProductService : IProductService
    {
        private readonly CrmAppDbContext dbContext = new CrmAppDbContext();
         

        public bool DeleteProduct(int id)
        {
            Product  product= dbContext.Products.Find(id);
            if (product == null) return false;
            dbContext.Products.Remove(product);
            return true;
        }

       
        public Product GetProductById(int id)
        {
            return dbContext.Products.Find(id);
        }

        public Product UpdateProduct(ProductOptions productOption, int id)
        {
            Product product = dbContext.Products.Find(id);
            product.Code = productOption.Code;
            product.Description = productOption.Description;
            product.Name = productOption.Name;
            product.Price = productOption.Price;
            product.Quantity = productOption.Quantity;

            dbContext.SaveChanges();

            return product;
        }

        ProductOptions IProductService.CreateProduct(ProductOptions productOptions)
        {
            Product product = new Product
            {
                Code = productOptions.Code,
                Description = productOptions.Description,
                Name = productOptions.Name,
                Price = productOptions.Price,
                Quantity = productOptions.Quantity
            };

            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            productOptions.Id = product.Id;
            return productOptions;
        }

        List<ProductOptions> IProductService.GetAllProduct()
        {
            List<Product> products= dbContext.Products.ToList();
            List<ProductOptions> productOpts = new List<ProductOptions>();
            products.ForEach(product => productOpts.Add(new ProductOptions {
                Code = product.Code,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Id = product.Id


            }));
            return productOpts;
        }

        ProductOptions IProductService.GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        ProductOptions IProductService.UpdateProduct(ProductOptions productOption, int id)
        {
            throw new NotImplementedException();
        }
    }
}
