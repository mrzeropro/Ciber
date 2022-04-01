using Ciber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Repositories
{
  public class CategoryRepository : BaseRepository<Category, CiberdbContext>, ICategoryRepository
  {
    public CategoryRepository(CiberdbContext context) : base(context)
    {
    }
  }

  public interface ICategoryRepository : IRepository<Category>
  {
  }
}
