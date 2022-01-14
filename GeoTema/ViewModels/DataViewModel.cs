using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTema.ViewModels
{
    public class DataViewModel
    {
        public List<Models.DataLandModel> GetData()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConStr("Data")))
            {
                return connection.Query<Models.DataLandModel>("SELECT country.ID, Land, Verdensdel, Verdensdel2, Rang, Fødselsrate FROM country LEFT JOIN continent ON country.ID = continent.ID LEFT JOIN [rank] ON country.ID = [rank].ID;").ToList();
            }
        }
        public void UploadData(string Land, string Verdensdel, string Verdensdel2, string Rang, string Fødselsrate)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConStr("Data")))
            {
                connection.Query<Models.DataLandModel>("INSERT INTO country VALUES ('"+ Land +"','"+ Verdensdel + "');");
                int ID = GetID(Land);
                if (ID != 0)
                {
                    connection.Query<Models.DataRankModel>("INSERT INTO continent VALUES ('" + ID + "','" + Verdensdel2 + "');");
                    connection.Query<Models.DataContinentModel>("INSERT INTO [rank] VALUES ('" + ID + "','" + Rang + "','" + Fødselsrate + "');");
                }
            }
        }
        public int GetID(string Land)
        {
            string conStr = Helper.ConStr("Data");
            string SqlCmd = "Select ID from country where Land = '" + Land + "'";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand getid = new SqlCommand(SqlCmd, con);
                SqlDataAdapter sda = new SqlDataAdapter(getid);
                DataTable dt = new DataTable("CountryID");
                sda.Fill(dt);
                try
                {
                    var value = dt.Rows[0].ItemArray[0];
                    return Convert.ToInt32(value);
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}
