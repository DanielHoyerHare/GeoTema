using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GeoTema.ViewModels
{
    public class BrugerViewModel
    {
        public List<Models.BrugerModel> Login(string navn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConStr("Bruger")))
            {
                return connection.Query<Models.BrugerModel>("SELECT brugernavn, [status], kode FROM bruger left join brugerkode on bruger.ID = brugerkode.ID WHERE brugernavn = '"+navn+"';").ToList();
            }
        }
    }
}
