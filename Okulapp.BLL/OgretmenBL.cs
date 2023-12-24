using Okulapp.DAL;
using okulAppModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Okulapp.BLL
{
    public class OgretmenBL
    {
        public bool Ogretmenekle(Ogretmen ogrt)
        {
            var hlp = new Helper();
            var p = new SqlParameter[]
            {
                 new SqlParameter("@Ad",ogrt.Ad),
                    new SqlParameter("@Soyad",ogrt.Soyad),
                    new SqlParameter("@TC",ogrt.TC)
            };
            return hlp.ExecuteNonQuery("Insert into tblOgretmenler1 values(@Ad,@Soyad,@TC)", p) > 0;

        }
    }
}
