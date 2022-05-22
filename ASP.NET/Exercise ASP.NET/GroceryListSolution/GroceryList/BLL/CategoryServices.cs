using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryList.DAL;
using GroceryList.ViewModels;

namespace GroceryList.BLL
{
    public class CategoryServices
    {
        private readonly GrocerylistContext _context;

        internal CategoryServices(GrocerylistContext context)
        {
            _context = context;
        }

        public List<SelectionList> GetAllCategories()
        {
            IEnumerable<SelectionList> info = _context.Categories
                                       .Select(x => new SelectionList
                                       {
                                           ValueId = x.CategoryID,
                                           DisplayText = x.Description
                                       });
            return info.ToList();
        }
    }
}
