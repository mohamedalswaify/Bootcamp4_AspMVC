﻿using Bootcamp4_AspMVC.Data;
using Bootcamp4_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp4_AspMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> Products = _context.Products.ToList();
            return View(Products);
        }
    }
}
