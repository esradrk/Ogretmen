using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace Okulapp.DAL
{
    public class Helper
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        string cstr = ConfigurationManager.ConnectionStrings["cstr"].ConnectionString;//app.configteki connection stringi okuyor.
        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p = null)
        {
            using (cn = new SqlConnection(cstr))
            {
                using (cmd = new SqlCommand(cmdtext, cn))
                {
                    if (p != null)
                    {
                        cmd.Parameters.AddRange(p);
                    }
                    cn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

    }
   

}
