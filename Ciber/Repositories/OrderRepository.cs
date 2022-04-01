using Ciber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Repositories
{
  public class OrderRepository : BaseRepository<Order, CiberdbContext>, IOrderRepository
  {
    public OrderRepository(CiberdbContext context) : base(context)
    {
    }
  }

  public interface IOrderRepository : IRepository<Order>
  {
  }
}
