using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTema.ViewModels
{
    public class DataGridViewModel
    {
        public List<Models.DataGridModel> GetDataTable(string searchkey)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConStr("Data")))
            {
                return connection.Query<Models.DataGridModel>("SELECT country.ID, Land, CONCAT(Verdensdel, ' ' ,Verdensdel2) AS Verdensdel, Rang, Fødselsrate FROM country LEFT JOIN continent ON country.ID = continent.ID LEFT JOIN [rank] ON country.ID = [rank].ID WHERE country.ID LIKE '%" + searchkey + "%' OR Land LIKE '%" + searchkey + "%' OR Verdensdel LIKE '%" + searchkey + "%' OR Verdensdel2 LIKE '%" + searchkey + "%' OR Rang LIKE '%" + searchkey + "%' OR Fødselsrate LIKE '%" + searchkey + "%';").ToList();
            }
        }
    }
}
