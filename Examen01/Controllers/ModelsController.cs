using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Examen01.Controllers
{
    public class ModelsController : ApiController
    {
        public class Modelo
        {
            public int id_submarca { get; set; }
            public int id_modelo { get; set; }
            public string nombre_model { get; set; }
            public string DescripcionId { get; set; }



        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IEnumerable<Modelo> Get(int id)
        {
            using (Models.ExamenEntities db = new Models.ExamenEntities())
            {
                var lst = (from d in db.Descripcions
                           join mo in db.Modeloes on d.id_modelo equals mo.id_modelo
                           where d.id_submarca == id
                           select new Modelo
                           {
                               DescripcionId=d.DescripcionId,
                               id_submarca = (int)d.id_submarca,
                               id_modelo = (int)d.id_modelo,
                               nombre_model = mo.modelo1

                           });

                var modelos = lst.DistinctBy(x=>x.nombre_model).ToList();

                return modelos;
            }
        }
    }
}
