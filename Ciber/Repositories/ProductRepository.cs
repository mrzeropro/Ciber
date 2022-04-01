using Ciber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Repositories
{
  public class ProductRepository : BaseRepository<Product, CiberdbContext>, IProductRepository
  {
    public ProductRepository(CiberdbContext context) : base(context)
    {
    }
  }

  public interface IProductRepository : IRepository<Product>
  {
  }
}
