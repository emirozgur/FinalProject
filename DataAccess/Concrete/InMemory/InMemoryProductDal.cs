using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;// hglobal değişkenler _ ile başlar naming convention

        public InMemoryProductDal()// constructor
        {
            // Oracle Sql Server , Postgres, MongoDb
            _products = new List<Product> {
               new Product{ProductID=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15 },
               new Product{ProductID=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3 },
               new Product{ProductID=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2 },
               new Product{ProductID=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65 },
               new Product{ProductID=5, CategoryId=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // LINQ Language Integrated Query

            Product ProductToDelete = _products.SingleOrDefault(p=>p.ProductID==product.ProductID);
            // her p için p nin ıd si göndrilen product id ye eşit mi eşitse referanslarını eşitle
            // single or defaultun gelmesi için isim uzayna using system.linq 
            _products.Remove(ProductToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }


        public void Update(Product product)
        {
            // Gönderdiğim ürün id sine sahip olan listedeki ürünü bul ki güncelleyebilelim
            Product ProductToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            ProductToUpdate.ProductName = product.ProductName;
            ProductToUpdate.CategoryId = product.CategoryId;
            ProductToUpdate.UnitPrice = product.UnitPrice;
            ProductToUpdate.UnitsInStock = product.UnitsInStock;

        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProduuctDetails()
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
