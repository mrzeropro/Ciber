using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ciber.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Ciber.Models;
using Moq;
using Ciber.Repositories;
using System.Linq;
using Ciber.ViewModels;

namespace Ciber.Controllers.Tests
{
  [TestClass()]
  public class OrderControllerTests
  {
    [TestMethod()]
    public void GetAllOrdersTest()
    {
      var orders = GetOrders();
      var products = GetProducts();
      var categories = GetCategories();
      var customers = GetCustomers();

      var mockOrderRepository = new Mock<IOrderRepository>();
      mockOrderRepository.Setup(m => m.GetAll()).ReturnsAsync(orders);

      var mockProductRepository = new Mock<IProductRepository>();
      mockProductRepository.Setup(m => m.GetAll()).ReturnsAsync(products);

      var mockCustomerRepository = new Mock<ICustomerRepository>();
      mockCustomerRepository.Setup(m => m.GetAll()).ReturnsAsync(customers);

      var mockCategoryRepository = new Mock<ICategoryRepository>();
      mockCategoryRepository.Setup(m => m.GetAll()).ReturnsAsync(categories);

      var orderController = new OrderController(
        mockOrderRepository.Object,
        mockProductRepository.Object,
        mockCategoryRepository.Object,
        mockCustomerRepository.Object);

      var returnOrders = orderController.GetAllOrders().Result;

      var expectedOrders = GetDetailOrderViewModels();

      Assert.AreEqual(expectedOrders.Count(), returnOrders.Count());

      Assert.IsTrue(expectedOrders.SequenceEqual(returnOrders));
    }

    private List<Order> GetOrders()
    {
      return new List<Order>
      {
        new Order{ Id = 1, CustomerId = 1, ProductId = 1, OrderDate = DateTime.Today, Amount = 100 },
        new Order{ Id = 1, CustomerId = 1, ProductId = 2, OrderDate = DateTime.Today, Amount = 200 },
        new Order{ Id = 1, CustomerId = 1, ProductId = 3, OrderDate = DateTime.Today, Amount = 300 }
      };
    }

    private List<Product> GetProducts()
    {
      return new List<Product>
      {
        new Product{ Id = 1, Name = "prod1", CategoryId = 1 },
        new Product{ Id = 2, Name = "prod2", CategoryId = 1 },
        new Product{ Id = 3, Name = "prod3", CategoryId = 1 }
      };
    }

    private List<Category> GetCategories()
    {
      return new List<Category>
      {
        new Category{Id = 1, Name = "Cat1" }
      };
    }

    private List<Customer> GetCustomers()
    {
      return new List<Customer>
      {
        new Customer{ Id = 1, Name = "A" }
      };
    }

    private IEnumerable<DetailOrderViewModel> GetDetailOrderViewModels()
    {
      return new List<DetailOrderViewModel>
      {
        new DetailOrderViewModel{Amount = 100, CategoryName = "Cat1", CustomerName = "A", OrderDate = DateTime.Today, ProductName = "prod1"},
        new DetailOrderViewModel{Amount = 200, CategoryName = "Cat1", CustomerName = "A", OrderDate = DateTime.Today, ProductName = "prod2"},
        new DetailOrderViewModel{Amount = 300, CategoryName = "Cat1", CustomerName = "A", OrderDate = DateTime.Today, ProductName = "prod3"},
      };
    }
  }
}