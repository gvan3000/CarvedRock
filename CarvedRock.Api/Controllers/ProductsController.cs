﻿using System.Collections.Generic;
using CarvedRock.Api.ApiModels;
using CarvedRock.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CarvedRock.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductLogic _productLogic;

        public ProductsController(IProductLogic productLogic)
        {
            _productLogic = productLogic;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts(string category = "all")
        {
            Log.ForContext("Category", category)
                .Information("Starting Controller action GetProducts");
            return _productLogic.GetProductsForCategory(category);
        }
    }
}