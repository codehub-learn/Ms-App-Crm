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
        private readonly CrmAppDbContext dbContext ;
        public ProductService(CrmAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool DeleteProduct(int id)
        {
            Product  product= dbContext.Products.Find(id);
            if (product == null) return false;
            dbContext.Products.Remove(product);
            return true;
        }

     
        ProductOptions IProductService.CreateProduct(ProductOptions productOptions)
        {
            Product product = GetProductFromProductOptions(productOptions);

            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            productOptions.Id = product.Id;
            return productOptions;
        }

        List<ProductOptions> IProductService.GetAllProduct()
        {
            List<Product> products= dbContext.Products
                .Where(product => product.Quantity>5)
            //     .Skip(6)
           //     .Take(10)
                .OrderByDescending (product => product.Price)
                .ThenBy(product => product.Name)
                
                
                .ToList();

            List<ProductOptions> productOpts = new List<ProductOptions>();
            products.ForEach(product => productOpts.Add(
                    GetProductOptionsFromProduct(product)
            ));
            return productOpts;
        }

        ProductOptions IProductService.GetProductById(int id)
        {
            Product product = dbContext.Products.Find(id);
            if (product == null) return null;
            return    GetProductOptionsFromProduct(product) ;
        }

          ProductOptions IProductService.UpdateProduct(ProductOptions productOption, int id)
        {
           
            Product product = dbContext.Products.Find(id);
            product.Code = productOption.Code;
            product.Description = productOption.Description;
            product.Name = productOption.Name;
            product.Price = productOption.Price;
            product.Quantity = productOption.Quantity;

            dbContext.SaveChanges();

            return productOption;
        }


        private static ProductOptions GetProductOptionsFromProduct(Product product)
        {
            return new ProductOptions
            {
                Code = product.Code,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Id = product.Id
            };
        }

        private static Product GetProductFromProductOptions(ProductOptions productOptions)
        {
            return new Product
            {
                Code = productOptions.Code,
                Description = productOptions.Description,
                Name = productOptions.Name,
                Price = productOptions.Price,
                Quantity = productOptions.Quantity,
            };
        }
    }
}
