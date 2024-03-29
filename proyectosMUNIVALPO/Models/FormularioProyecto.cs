﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace proyectosMUNIVALPO.Models
{
    public class FormularioProyecto
    {
        public string Nombre { get; set; }

        public DateTime Fecha { get; set; }

        public string Direccion { get; set; }

        public int Responsable { get; set; }

       // public string Correo { get; set; }

        public string Bajada { get; set; }

        public string Descripcion { get; set; }

        public int TipoProyecto { get; set; }

        public int Estado { get; set; }

        public string Archivo { get; set; }

        public DateTime Fecha_creacion { get; set; }

        
        public string __Mapa { get; set; }
    }

    public class ModificarFormularioProyecto
    {
        public int Id_Proyecto { get; set; }
        public string Nombre { get; set; }

        public DateTime Fecha { get; set; }

        public string Direccion { get; set; }

        public int Responsable { get; set; }

        //public string Correo { get; set; }

        public string Bajada { get; set; }

        public string Descripcion { get; set; }

        public int TipoProyecto { get; set; }

        public int Estado { get; set; }

        public string Archivo { get; set; }

        public DateTime Fecha_creacion { get; set; }

        public string __Mapa { get; set; }

    }
}