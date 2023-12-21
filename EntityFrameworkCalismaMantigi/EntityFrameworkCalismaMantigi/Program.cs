using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCalismaMantigi
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            DataModel dm = new DataModel();

            List<Urun> urunler = dm.UrunleriGetir();

            foreach (Urun urun in urunler)
            {
                Console.WriteLine($"Ürün Adı: " + urun.ProductName + " \n Kategori Adı: " + urun.Kategori.Name + " \n Tedarikçi Adı: " + urun.Tedarikci.CompanyName + "\n Telefon No: " + urun.Tedarikci.Phone + "\n Fax: " + urun.Tedarikci.Fax);
            }

        }
    }
}
