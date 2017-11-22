using Microsoft.WindowsAzure.MobileServices;
using SupermercadoOnline.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermercadoOnline.Azure
{
    public class AzureService
    {
        IMobileServiceClient Cliente;
        IMobileServiceTable<Producto> Productos;

        public AzureService()
        {
            string MyAppServiceURL = "https://snh31d3rtienda.azurewebsites.net/";
            Cliente = new MobileServiceClient(MyAppServiceURL);
            Productos = Cliente.GetTable<Producto>();
        }

        public Task<IEnumerable<Producto>> GetProductos()
        {
            return Productos.ToEnumerableAsync();
        }
    }
}
