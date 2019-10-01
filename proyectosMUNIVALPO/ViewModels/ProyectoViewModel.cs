using proyectosMUNIVALPO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectosMUNIVALPO.ViewModels
{
    public class ProyectoViewModel
    {
        public int Id_proyecto { get; set; }
        public string Nombre { get; set; }
        public int Id_estado { get; set; }

    }
}