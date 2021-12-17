﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductoEntity
    {
        public int? IdProducto { get; set; }

        public string Categoria { get; set; }
       
        public string NombreProducto { get; set; }

        public int? Cantidad_Disponible { get; set; }

        public string Caracteristicas { get; set; }

        public string Estado { get; set; }

    }
}