using proyectosMUNIVALPO.Models;
using proyectosMUNIVALPO.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace proyectosMUNIVALPO.Controllers
{
    public class HomeController : Controller
    {

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaludYDeporte()
        {
            return View();
        }
        public ActionResult DesarrolloEconomico()
        {
            return View();
        }
        public ActionResult EspaciosPublicos()
        {
            return View();
        }
        public ActionResult ViviendaYReactivacion()
        {
            return View();
        }
        public ActionResult ListaProyectos()
        {
            return View();
        }

        public ActionResult VerProyecto()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }


        //-------------------------prueba de subir archivo en una vista externa----------------------
        /*
        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase postedFile)
        {
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
                ViewBag.Message = "File uploaded successfully.";
            }

            return View();
        }
        */
        

        void connectionString()
        {
            con.ConnectionString = "Server=192.168.110.22;Database=Ventanilla;User Id=practicadesarrollo;Password=desarrollo864;";

        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from usuario where nombre_usuario='" + acc.Name + "' and contrasena='" + acc.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                Session["Login"] = "correcto";
                con.Close();
                return View("RegistrarProyecto");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult AgregarProyecto(FormularioProyecto form , HttpPostedFileBase Upload)
        {
            if (Upload != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                Upload.SaveAs(path + Path.GetFileName(Upload.FileName));
                ViewBag.Message = "Archivo subido exitosamente.";
            }

            connectionString();
            con.Open();
            com.Connection = con;
            //sql = "Insert into demotb(TutorialID,TutorialName) value(3, '" + "VB.Net +"')";

            com.CommandText = "INSERT into MUNI_proyecto (nombre,direccion,fecha_entrega,bajada,descripcion,id_tipoProyecto,id_responsable,id_estado,fecha_creacion,mapa) " +

            "VALUES (@nombre,@direccion,@fecha_entrega,@bajada,@descripcion,@id_tipoProyecto,@id_responsable,@id_estado,@fecha_creacion,@mapa)";
            // VALUES (@  ,@, @ , @ , @ , @rol , @ , @direccion_rol )"


            com.Parameters.AddWithValue("nombre", form.Nombre);
            com.Parameters.AddWithValue("direccion", form.Direccion);
            com.Parameters.AddWithValue("fecha_entrega", form.Fecha);
            com.Parameters.AddWithValue("bajada", form.Bajada);
            com.Parameters.AddWithValue("descripcion", form.Descripcion);
            com.Parameters.AddWithValue("id_tipoProyecto", form.TipoProyecto);
            com.Parameters.AddWithValue("id_responsable", form.Responsable);
            int id_estado = 1;
            com.Parameters.AddWithValue("id_estado", id_estado);
            DateTime Fecha_creacion = DateTime.Now;

            com.Parameters.AddWithValue("fecha_creacion", Fecha_creacion);
            com.Parameters.AddWithValue("mapa", form.__Mapa);
            
            
            com.ExecuteNonQuery();

            con.Close();



            return View("RegistrarProyecto");
        }


        [HttpGet]
        public ActionResult RegistrarProyecto()
        {
            if (Session["Login"] != null)
            {

                return View();
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult ModificarProyecto(int id)
        {
            /*
            if (Session["Login"] != null)
            {
                return View();
            }
            else
            {
                return View("Login");
            }*/

            ModificarFormularioProyecto editModel = new ModificarFormularioProyecto();
            using (var db = new VentanillaEntities())
            {
                MUNI_proyecto oProyecto = db.MUNI_proyecto.Find(id);
                editModel.Id_Proyecto = id;
                editModel.Estado = oProyecto.id_estado;
                editModel.Nombre = oProyecto.nombre;
                editModel.TipoProyecto = oProyecto.id_tipoProyecto;
                editModel.Fecha = (DateTime)oProyecto.fecha_entrega;
                editModel.Direccion = oProyecto.direccion;
                editModel.Responsable = oProyecto.id_responsable;
                editModel.Bajada = oProyecto.bajada;
                editModel.Descripcion = oProyecto.descripcion;

                editModel.Fecha_creacion = (DateTime)oProyecto.fecha_creacion;
                editModel.__Mapa = oProyecto.mapa;

            }
           

            return View(editModel);
        }

        [HttpPost]
        public ActionResult ModificarProyecto(ModificarFormularioProyecto editModel)
        {
            /*if (!ModelState.IsValid)
            {
                return View(editModel);

            }*/

            using (var db = new VentanillaEntities())
            {
                var oProyecto = db.MUNI_proyecto.Find(editModel.Id_Proyecto);

                oProyecto.id_proyecto = editModel.Id_Proyecto;
                oProyecto.nombre = editModel.Nombre;
                oProyecto.id_tipoProyecto = editModel.TipoProyecto;
                oProyecto.id_estado = editModel.Estado;
                oProyecto.fecha_entrega = editModel.Fecha;
                oProyecto.direccion = editModel.Direccion;
                oProyecto.id_responsable = editModel.Responsable;
                oProyecto.bajada = editModel.Bajada;
                oProyecto.descripcion = editModel.Descripcion;
                oProyecto.fecha_creacion = editModel.Fecha_creacion;
                oProyecto.mapa = editModel.__Mapa;

                

                db.Entry(oProyecto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();


            }

            return Redirect(Url.Content("~/Home/SeleccionarProyecto"));
        }



        public ActionResult SeleccionarProyecto()
        {
            if (Session["Login"] != null)
            {
                List<ProyectoViewModel> lst = null;
                using (VentanillaEntities db = new VentanillaEntities())
                {
                    lst = (from d in db.MUNI_proyecto
                           select new ProyectoViewModel
                           {
                               Id_proyecto = d.id_proyecto,
                               Nombre = d.nombre,
                               Id_estado = d.id_estado
                           }).ToList();
                }
                return View(lst);

            }
            else
            {
                return View("Login");
            }
        }
    }


}