using System;
using System.Collections.Generic;
using System.Linq;
#nullable disable
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.ViewModels
{
    public class ProductList
    {
        public int ProductID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Discount { get; set; }
        public string UnitSize { get; set; }

        public int CategoryID { get; set; }
        public bool Taxable { get; set; }
    }
}
