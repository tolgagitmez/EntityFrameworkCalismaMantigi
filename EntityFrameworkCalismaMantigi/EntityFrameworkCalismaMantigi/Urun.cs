using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCalismaMantigi
{
    public class Urun
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int SupplierID { get; set; }

        public int CategoryID { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public Nullable<Int16> UnitsInStock { get; set; }

        public Nullable<Int16> UnitsInOrder { get; set; }

        public Nullable<Int16> ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public Kategori Kategori { get; set; }

        public Tedarikci Tedarikci { get; set; }

         





    }
}
