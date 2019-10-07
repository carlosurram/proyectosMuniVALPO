using proyectosMUNIVALPO.Models;
using proyectosMUNIVALPO.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult AgregarProyecto(FormularioProyecto form)
        {


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
            com.Parameters.AddWithValue("mapa", form.Mapa);
            
            //com.Parameters.AddWithValue("id_estado", form.Estado);


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

        public ActionResult ModificarProyecto()
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

    /* public ActionResult SeleccionarProyecto2()
     {

 }*/
}