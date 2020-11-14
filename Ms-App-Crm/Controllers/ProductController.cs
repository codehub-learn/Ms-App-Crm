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
        private readonly IProductService productService = new ProductService();

        [HttpPost]
        public ProductOptions CreateProduct(ProductOptions ProductOption)
        {
            return productService.CreateProduct(ProductOption);
        }

        [HttpGet("{id}")]
        public ProductOptions GetProduct(int id)
        {
            return productService.GetProductById(id);
        }
        [HttpGet]
        public List<ProductOptions> GetProducts()
        {
            return productService.GetAllProduct();
        }

        [HttpPut("{id}")]
        public ProductOptions UpdateProducts(ProductOptions ProductOption, int id)
        {
            return productService.UpdateProduct(ProductOption, id);
        }
        [HttpDelete("{id}")]
        public bool DeleteProducts( int id)
        {
            return productService.DeleteProduct(id);
        }

    }
}
