using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermercadoOnline.Modelos
{
    [DataTable("productos")]
    public class Producto
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public int precio { get; set; }

        public string descripcion { get; set; }

        public string imagen { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

    }
}
