using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examen01.Controllers
{
    public class SubrandController : ApiController
    {
        public class Subrand
        {
            public int Id_sub { get; set; }
            public string nombre_sub { get; set; }

            public int id_marc { get; set; }
        }

        public IEnumerable<Subrand> Get(int id)
        {
            using (Models.ExamenEntities db = new Models.ExamenEntities())
            {
                var lst = (from s in db.Submarcas
                           where s.id_marca == id
                           select new Subrand
                           {
                               Id_sub= s.id_submarca,
                               nombre_sub=s.submarca1,
                               id_marc=s.id_marca
                           }).ToList();

                return lst;
            }
        }
    }
}
