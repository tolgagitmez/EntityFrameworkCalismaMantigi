using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCalismaMantigi
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel() 
        {
            con = new SqlConnection(ConnectionString.ConStr);
            cmd = con.CreateCommand();
        }


        public List<Urun> UrunleriGetir()
        {
            List<Urun>urunler = new List<Urun>();
            try
            {
                cmd.CommandText = "Select P.ProductID, P.ProductName, P.SupplierID, P.CategoryID, P.QuantityPerUnit, P.UnitPrice, P.UnitsInStock, P.UnitsOnOrder, P.ReorderLevel, P.Discontinued, C.CategoryID, C.CategoryName, C.Description, S.SupplierID, S.CompanyName, S.ContactName, S.ContactTitle, S.Address, S.City, S.Region, S.PostalCode, S.Country, S.Phone, S.Fax, S.HomePage from Products as P JOIN Categories as C on P.CategoryID = C.CategoryID JOIN Suppliers as S ON P.SupplierID = S.SupplierID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Urun urun = new Urun();
                    urun.ProductID = reader.GetInt32(0);
                    urun.ProductName = reader.GetString(1);
                    urun.SupplierID = reader.GetInt32(2);
                    urun.CategoryID = reader.GetInt32(3);
                    urun.QuantityPerUnit = reader.GetString(4);
                    urun.UnitPrice = reader.GetDecimal(5);
                    urun.UnitsInStock = reader.GetInt16(6);
                    urun.UnitsInOrder = reader.GetInt16(7);
                    urun.ReorderLevel = reader.GetInt16(8);
                    urun.Discontinued = reader.GetBoolean(9);
                    Kategori kat = new Kategori();
                    kat.ID = reader.GetInt32(10);
                    kat.Name = reader.GetString(11);
                    kat.Description = reader.GetString(12);
                    Tedarikci ted = new Tedarikci();
                    ted.SupplierID = reader.GetInt32(13);
                    ted.CompanyName = reader.GetString(14);
                    ted.ContactName = reader.GetString(15);
                    ted.ContactTitle = reader.GetString(16);
                    ted.Address = reader.GetString(17);
                    ted.City = reader.GetString(18);

                    if (reader.IsDBNull(19))
                    {
                        ted.Region = "-Veri Yok-";
                    }
                    else
                    {
                        ted.Region = reader.GetString(19);
                    }

                    ted.PostalCode = reader.GetString(20);
                    ted.Country = reader.GetString(21);
                    ted.Phone = reader.GetString(22);

                    if (reader.IsDBNull(23))
                    {
                        ted.Fax = "-Veri Yok-";
                    }
                    else
                    {
                        ted.Fax = reader.GetString(23);
                    }

                    if (reader.IsDBNull(24))
                    {
                        ted.HomePage = "-Veri Yok-";
                    }
                    else
                    {
                        ted.HomePage = reader.GetString(24);
                    }
                    urun.Kategori = kat;
                    urun.Tedarikci = ted;
                    urunler.Add(urun);
                }
                return urunler;


            }
            catch(Exception ex)
            {
                return null;

            }
            finally
            {
                con.Close();

            }
        }
    }
}
