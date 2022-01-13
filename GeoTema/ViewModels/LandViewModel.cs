using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTema.ViewModels
{
    public class LandViewModel
    {
        public List<Models.LandModel> GetDataTable(string searchkey)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConStr("Data")))
            {
                return connection.Query<Models.LandModel>("SELECT country.ID, Land, Verdensdel, Verdensdel2, Rang, Fødselsrate FROM country LEFT JOIN continent ON country.ID = continent.ID LEFT JOIN [rank] ON country.ID = [rank].ID WHERE country.ID LIKE '%" + searchkey + "%' OR Land LIKE '%" + searchkey + "%' OR Verdensdel LIKE '%" + searchkey + "%' OR Verdensdel2 LIKE '%" + searchkey + "%' OR Rang LIKE '%" + searchkey + "%' OR Fødselsrate LIKE '%" + searchkey + "%';").ToList();
            }
        }
    }
}
