using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CaztonWebApi.Repository;
using CaztonWebApi.Models;

namespace CaztonWebApi.Controllers
{
    [RoutePrefix("Api/Product")]
    public class ProductController : ApiController
    {
        // GET: Product
        CaztonProductsEntity db = new CaztonProductsEntity();
        ProductRepository productRepository = new ProductRepository();
        [HttpGet]
        [Route("AllProducts")]
        public IHttpActionResult GetProducts()
        {
            try
            {
                List<Product> productModelsToView = new List<Product>();
                productModelsToView = productRepository.GetAllProducts_Repo();
                return Ok(productModelsToView);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetProductById/{productId}")]
        public IHttpActionResult GetProductById(string productId)
        {
            try
            {
                Product productToView = new Product();
                productToView = productRepository.GetProductById_Repo(productId);
                return Ok(productToView);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("UpdateProduct")]
        //to updatig rating in the database
        public IHttpActionResult UpdateRating(Product productToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             productRepository.UpdateProduct_Repo(productToUpdate);
            return Ok(productToUpdate);
        }
        [HttpDelete]
        [Route("DeleteProduct/{productId}")]
        //to delete rating from the  database
        public IHttpActionResult DeleteRating(string productId)
        {
            productRepository.DeleteProduct_Repo(productId);
            return Ok();
        }
        [HttpPost]
        [Route("CreateProduct")]

        //to add Product to the database
        public IHttpActionResult PostProduct(Product productfromView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            productRepository.AddProductDetails_Repo(productfromView);

            return Ok(productfromView);
        }
    }
}