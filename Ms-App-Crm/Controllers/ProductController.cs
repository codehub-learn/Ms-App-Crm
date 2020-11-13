using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm_Core.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelCrm.Models;
using ModelCrm.Services;

namespace CrmWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService productService = new ProductService();

        [HttpPost]
        public Product createProduct(ProductOptions ProductOption)
        {
            return productService.CreateProduct(ProductOption);
        }

        [HttpGet("{id}")]
        public Product getProduct(int id)
        {
            return productService.GetProductById(id);
        }
        [HttpGet]
        public List<Product> getProducts()
        {
            return productService.GetAllProduct();
        }

        [HttpPut("{id}")]
        public  Product  updateProducts(ProductOptions ProductOption, int id)
        {
            return productService.UpdateProduct(ProductOption, id);
        }
        [HttpDelete("{id}")]
        public bool deleteProducts( int id)
        {
            return productService.DeleteProduct(id);
        }

    }
}
