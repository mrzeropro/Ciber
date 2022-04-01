using Ciber.Models;
using Ciber.Repositories;
using Ciber.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Controllers
{
  [Authorize(Roles = "admin")]
  public class OrderController : Controller
  {
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICustomerRepository _customerRepository;

    public OrderController(
      IOrderRepository orderRepository,
      IProductRepository productRepository,
      ICategoryRepository categoryRepository,
      ICustomerRepository customerRepository
      )
    {
      _orderRepository = orderRepository;
      _productRepository = productRepository;
      _categoryRepository = categoryRepository;
      _customerRepository = customerRepository;
    }

    public async Task<IActionResult> Index()
    {
      var allOrders = GetAllOrders();
      return View(await allOrders);
    }

    public async Task<IActionResult> CreateNewOrder(string orderName, int productID, int customerID, string orderDate, int amount)
    {
      var product = await _productRepository.Get(productID);
      var remainingAmount = product.Quantity;

      if (remainingAmount < amount)
      {
        return new JsonResult(new { data = "Cannot create order", status = "Error" });
      }

      var newOrder = new Order
      {
        Amount = amount,
        ProductId = productID,
        CustomerId = customerID,
        OrderDate = DateTime.ParseExact(orderDate, "dd/MM/yyyy", null)
      };

      product.Quantity = product.Quantity - amount;

      await _orderRepository.Add(newOrder);

      return new JsonResult(new { data = "Success", status = "OK" });
    }

    public async Task<IActionResult> GetAllProducts()
    {
      var products = await _productRepository.GetAll();
      var returnProducts = products.Select(c => new { id = c.Id, text = c.Name });
      var result = new
      {
        results = returnProducts,
      };

      return new JsonResult(result);
    }

    public async Task<IActionResult> GetAllCustomers()
    {
      var customers = await _customerRepository.GetAll();
      var result = new
      {
        results = customers.Select(c => new { id = c.Id, text = c.Name })
    };

      return new JsonResult(result);
    }

    public async Task<IEnumerable<DetailOrderViewModel>> GetAllOrders()
    {
      var ordersTask = _orderRepository.GetAll();
      var productTask = _productRepository.GetAll();
      var customerTask = _customerRepository.GetAll();
      var categoryTask = _categoryRepository.GetAll();

      var orders = await ordersTask;
      var products = await productTask;
      var customers = await customerTask;
      var categories = await categoryTask;

      var result = from o in orders
                   join p in products
                   on o.ProductId equals p.Id
                   join c in customers
                   on o.CustomerId equals c.Id
                   join cat in categories
                   on p.CategoryId equals cat.Id
                   select new DetailOrderViewModel
                   {
                     Amount = o.Amount.GetValueOrDefault(),
                     CategoryName = cat.Name,
                     CustomerName = c.Name,
                     OrderDate = o.OrderDate.GetValueOrDefault(),
                     ProductName = p.Name
                   };

      return result;
    }

    public IActionResult Privacy()
    {
      return View();
    }
  }
}
