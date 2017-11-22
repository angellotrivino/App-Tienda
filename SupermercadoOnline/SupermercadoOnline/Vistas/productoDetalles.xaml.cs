using SupermercadoOnline.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SupermercadoOnline.Vistas
{
    public partial class productoDetalles : ContentPage
    {
        Producto SelectedProducto;

        public productoDetalles(Producto SelectedProducto)
        {
            InitializeComponent();
            this.SelectedProducto = SelectedProducto;
            BindingContext = this.SelectedProducto;

        }
    }
}
