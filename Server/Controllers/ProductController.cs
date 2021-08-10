using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlazorDB.Server.DB;
using BlazorDB.Shared;
using BlazorDB.Shared.Models;

namespace BlazorDB.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api/Clothe
    public class ProductController : Controller
    {
        #region DataBase
        private readonly ProductProvider _provider;
        public ProductController(ProductProvider provider)
        {
            this._provider = provider;
        }
        //////////////////////////////////////////////////////////
        [HttpPost("AddNewProductToDB")]
        public  Product AddNewClotheToDB(Product p)
        {
            this._provider.AddProduct2(p);
            return p;
        }

        /////////////////////////////////////////////////////////////////
        [HttpGet]
        [Route("GetAllProductssFromDB")]
        public List<Product> GetAllHFromDB()
            => this._provider.GetAllProducts();
        ////////////////////////////////////////////////////////////
        [HttpGet("GetAllProductByCatagory/{s}")]
        public List<Product> GetAllProductsFromDBByCat(string s)
            => this._provider.GetProductByCatagory(s);
        ////////////////////////////////////////////////////////////////
        [HttpGet("getProductByIdFromDb/{id}")]
        public Product getProductByIdFromDb(int id)
            =>this._provider.GetProductById(id);        
        // //////////////////////////////////////////////////////////

        [HttpDelete("DeleteProductFromDbById/{h}")]
        public void DeleteProductFromDbById(int h)
        {
            this._provider.Delete(h);
        }


        [HttpPut("UpdateProductFromDB")]
        public async Task<Product> UpdateProductFromDB(Product p)
        {
            await this._provider.UpdateProduct4(p);
            return p;
        }

        [HttpPut("AddedToCart")]
        public async Task<Product> AddedToCartFromDB2(Product p)
        {
            await this._provider.WhenIsAdded2(p);
            return p;
        }
        #endregion
    }
}