using proyectosMUNIVALPO.Models;
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

        public ActionResult AgregarProyecto(FormularioProyecto form)
        {
           /* "insert into "

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
            }*/
        }


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
                return View();
            }
            else
            {
                return View("Login");
            }
        }

    }
}