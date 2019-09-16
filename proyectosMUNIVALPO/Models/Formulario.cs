using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectosMUNIVALPO.Models
{
    public class Formulario
    {
        public string Nombre { get; set; }

        public DateTime Fecha { get; set; }

        public string Direccion { get; set; }

        public string Correo { get; set; }

        public string Bajada { get; set; }

        public string Descripcion { get; set; }

        public Byte [] Archivo { get; set; }

        //REVISR : deberian ir ademas tipo_proyecto y estado 


    }
}