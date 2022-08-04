using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examen01.Controllers
{
    public class BrandController : ApiController
    {
        public class Brand
        {
            public int Id { get; set; }
            public string nombre { get; set; }
        }

        public IEnumerable<Brand> Get()
        {
            using(Models.ExamenEntities db=new Models.ExamenEntities())
            {
                var lst = (from m in db.Marcas
                           select new Brand
                           {
                               Id=m.id_marca,
                               nombre=m.marca1
                           }).ToList();

                return lst;
            }
        }
    }
}
