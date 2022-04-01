using Ciber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Repositories
{
  public class CustomerRepository : BaseRepository<Customer, CiberdbContext>, ICustomerRepository
  {
    public CustomerRepository(CiberdbContext context) : base(context)
    {
    }
  }

  public interface ICustomerRepository : IRepository<Customer>
  {
  }
}
