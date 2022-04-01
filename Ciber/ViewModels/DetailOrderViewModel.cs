using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.ViewModels
{
  public class DetailOrderViewModel
  {
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public int Amount { get; set; }

    public override bool Equals(object obj)
    {
      if (obj is DetailOrderViewModel order)
      {
        return ProductName == order.ProductName
          && CategoryName == order.CategoryName
          && CustomerName == order.CustomerName
          && Amount == order.Amount
          && OrderDate == order.OrderDate;
      }

      return false;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(ProductName, CategoryName, CustomerName, Amount, OrderDate);
    }
  }
}
