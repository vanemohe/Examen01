using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Examen01.Controllers
{
    public class DescriptionController : ApiController
    {
       
        public class Descripcion
        {


            public string DescripcionId { get; set; }

            public string descripcion { get; set; }



        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IEnumerable<Descripcion> Get(int id_sub, int id_mod)
        {
            using (Models.ExamenEntities db = new Models.ExamenEntities())
            {
               

                var lst = (from d in db.Descripcions
                           where d.id_submarca == id_sub && d.id_modelo == id_mod
                           select new Descripcion
                           {
                               DescripcionId = d.DescripcionId,
                               descripcion = d.descripcion1

                           }).ToList();

                return lst;
            }
        }
    }
}