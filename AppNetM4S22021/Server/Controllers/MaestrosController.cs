using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppNetM4S22021.Shared;
using AppNetM4S22021.Server.Models;

namespace AppNetM4S22021.Server.Controllers
{
    [ApiController]
    public class MaestrosController : Controller
    {
        [HttpGet]
        [Route("api/Maestro/obtenerMaestro/{idMaestro}")]
        public MaestrosCls obtenerMaestro(int idMaestro)
        {
            MaestrosCls mCls = new MaestrosCls();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                mCls = (from maestro in db.Maestros
                        where maestro.MaestroId == idMaestro
                        select new MaestrosCls
                        {
                            MaestroId = maestro.MaestroId,
                            Nombre = maestro.Nombre

                        }).First();

            }
            return mCls;
        }



        [HttpPost]
        [Route("api/Maestro/Guardar")]
        public async Task<ActionResult<int>> Guardar(MaestrosCls maestroCls)
        {

            int rpta = 0;
            try
            {

                using (RegistroAcademicoContext db = new RegistroAcademicoContext())
                {
                    Maestros oMaestros = new Maestros();
                    if (maestroCls.MaestroId == 0)
                    {
                        oMaestros.MaestroId = maestroCls.MaestroId;
                        oMaestros.Nombre = maestroCls.Nombre;

                        db.Maestros.Add(oMaestros);
                    }
                    else
                    {
                        Maestros c = db.Maestros.Where(c => c.MaestroId == maestroCls.MaestroId).FirstOrDefault();
                        c.Nombre = maestroCls.Nombre;
                    }
                    await db.SaveChangesAsync();
                    rpta = 1;
                }


            }
            catch (Exception)
            {
                rpta = 0;
            }
            return rpta;
        }

        [HttpGet]
        [Route("api/Maestro/EliminarMaestro/{data?}")]
        public int EliminaMaestro(string data)
        {
            int rpta = 0;
            try
            {
                using (RegistroAcademicoContext db = new RegistroAcademicoContext())
                {
                    int idMaestro = int.Parse(data);
                    Maestros maestro = db.Maestros.Where(c => c.MaestroId == idMaestro).First();
                    db.Attach(maestro);
                    db.Remove(maestro);
                    db.SaveChanges();
                    rpta = 1;
                }
            }
            catch (Exception)
            {

                rpta = 0;
            }
            return rpta;
        }

        [HttpGet]
        [Route("api/Maestro/Filtrar/{data?}")]
        public List<Maestros> Filtrar(string data)
        {
            List<Maestros> lista = new List<Maestros>();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                if (data == null)
                {
                    lista = (from maestro in db.Maestros
                             select new Maestros
                             {
                                 MaestroId = maestro.MaestroId,
                                 Nombre = maestro.Nombre

                             }).ToList();
                }

                else
                {
                    lista = (from m in db.Maestros
                             where m.MaestroId.ToString().Contains(data) || m.Nombre.Contains(data)
                             select new Maestros
                             {
                                 MaestroId = m.MaestroId,
                                 Nombre = m.Nombre
                             }).ToList();

                }
            }
            return lista;

        }


        [HttpGet]
        [Route("api/Maestros/Get")]
        public List<MaestrosCls> Get()
        {
            List<MaestrosCls> lista = new List<MaestrosCls>();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                lista = (from m in db.Maestros
                         select new MaestrosCls
                         {
                             MaestroId = m.MaestroId,
                             Nombre = m.Nombre
                         }).ToList();
            }
            return lista;

        }
    }

}
