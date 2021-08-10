using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BlazorDB.Server.Controllers;
using BlazorDB.Shared.Models;
using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;

namespace BlazorDB.Server.DB
{
    public class ProductProvider
    {
        //*********************Yek object az class ClotheDBContext
        private readonly ProductDBContext _context;
        private readonly ILogger _logger;
        public ProductProvider(ProductDBContext context, ILoggerFactory loggerFactory)
        {
            this._context = context;
            this._logger = loggerFactory.CreateLogger("ProductProvider");
        }

        //***************************************************

        
        public void AddProduct2(Product p)
        {
            // if(this._context.Products is null)
            // {
            //     _context.Products.Add(p);
            //     _context.SaveChanges();
            // }
            // else{
            //     var last = this._context.Products.Select(arg => arg.ID).Max() + 1;
            //     p.ID = last;
            //     _context.Products.Add(p);
            // }
            // _context.SaveChanges();
            // var last = this._context.Products.ToArray().LastOrDefault();
            // var nid = 0;
            // if(!(last is null))
            //     nid = last.ID+1;
            // p.ID = nid;
            // await _context.Products.AddAsync(p);
            // await _context.SaveChangesAsync();
            var newId = this._context.Products.Select(arg => arg.ID).ToArray().LastOrDefault() + 1;
            p.ID = newId;
            _context.Products.Add(p);
            _context.SaveChanges();
        }

        public List<Product> GetAllProducts()
            => this._context.Products.ToList();

        public Product GetProductById(int id)
        {
            return this._context.Products.Where(p => p.ID == id).FirstOrDefault();
        }
        public List<Product> GetProductByCatagory(string c)
        {
            return this._context.Products.Where(p => p.Catagory == c).ToList();
        }


        public void Delete(int id)
        {
            var p = this._context.Products.Where(arg => arg.ID == id).FirstOrDefault();
            this._context.Products.Remove(p);
            this._context.SaveChanges();
        }


        public async Task UpdateProduct4(Product Newp)
        {
            _context.Products.Update(Newp);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> WhenIsAdded2(Product pr)
        {
            

            var p = this._context.Products.Where(arg => arg.ID == pr.ID).FirstOrDefault();
            if(p.Inventory >=1)
                p.Inventory--;
            await _context.SaveChangesAsync();
            return p;
        } 
    }
}
