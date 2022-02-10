using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaztonWebApi.Models;

namespace CaztonWebApi.Repository
{
    public class ProductRepository
    {

        CaztonProductsEntity db = new CaztonProductsEntity();
        //logic to add product details to the database
        public Boolean AddProductDetails_Repo(Product productFromView)
        {
            try
            {
                Product productToPostDB = new Product();
                productToPostDB.ProductId = productFromView.ProductId;
                productToPostDB.Title = productFromView.Title;
                productToPostDB.Description = productFromView.Description;
                productToPostDB.ModelNumber = productFromView.ModelNumber;
                productToPostDB.Picture = productFromView.Picture;
                productToPostDB.Price = productFromView.Price;
                db.Products.Add(productToPostDB);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }
        public List<Product> GetAllProducts_Repo()
        {
            try
            {
                var ProductsFromDB = db.Products.ToList();
                List<Product> ProductModelstoView = new List<Product>();
                foreach (Product productToView in ProductsFromDB)
                {
                    Product productModelToView = new Product();
                    productModelToView.ProductId = productToView.ProductId;
                    productModelToView.Title = productToView.Title;
                    productModelToView.Description = productToView.Description;
                    productModelToView.ModelNumber = productToView.ModelNumber;
                    productModelToView.Picture = productToView.Picture;
                    productModelToView.Price = productToView.Price;
                    ProductModelstoView.Add(productModelToView);
                }
                    return ProductModelstoView;
            }
            catch (Exception)
            {
                throw;
            }                       
        }
        //logic to get product details based on productId
        public Product GetProductById_Repo(string productId)
        {
            Product producttoView = new Product();
            int ID = Convert.ToInt32(productId);
            try
            {
                producttoView = db.Products.Where(e => e.ProductId == ID).FirstOrDefault();
                return producttoView;

            }
            catch (Exception)
            {
                throw;
            }
        }
        //logic to delete product
        public Boolean DeleteProduct_Repo(string ProductId)
        {
            try
            {
                int ID = Convert.ToInt32(ProductId);
                Product productSelected = db.Products.Where(x => (x.ProductId.Equals(ID))).FirstOrDefault();
                if (productSelected != null)
                {
                    db.Products.Remove(productSelected);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return true;

        }
        //logic to update Product details
        public Boolean UpdateProduct_Repo(Product productToUpdate)
        {
            Product productOld = new Product();
            productOld = db.Products.Where(e => (e.ProductId == productToUpdate.ProductId)).FirstOrDefault();
            try
            {
                if (productOld != null)
                {
                    productOld.Title = productToUpdate.Title;
                    productOld.Description = productToUpdate.Description;
                    productOld.ModelNumber = productToUpdate.ModelNumber;
                    productOld.Picture = productToUpdate.Picture;
                    productOld.Price = productToUpdate.Price;
                    db.SaveChanges();
                }
                else
                {
                    db.Products.Add(productToUpdate);
                    db.SaveChanges();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
    }
}