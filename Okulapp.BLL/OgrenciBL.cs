using Okulapp.DAL;
using okulAppModel;
using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
namespace Okulapp.BLL
{
    public class OgrenciBL
    {
        public bool ogrenciekle(Ogrenci ogr)
        {
            var hlp = new Helper();
            var p = new SqlParameter[]
            {
                 new SqlParameter("@Ad",ogr.Ad),
                    new SqlParameter("@Soyad",ogr.Soyad),
                    new SqlParameter("@Numara",ogr.Numara)
            };
          return  hlp.ExecuteNonQuery("Insert into tblOgrenciler values(@Ad,@Soyad,@Numara)", p)>0;


        }
    }
}
