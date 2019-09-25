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

        public string Responsable { get; set; }

        public string Correo { get; set; }

        public string Bajada { get; set; }

        public string Descripcion { get; set; }

        public string TipoProyecto { get; set; }

        public string Estado { get; set; }

        public byte[] Archivo { get; set; }

        



    }
}