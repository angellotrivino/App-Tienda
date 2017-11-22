using SupermercadoOnline.Modelos;
using SupermercadoOnline.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SupermercadoOnline.Vistas
{
    public partial class productos : ContentPage
    {
        public productos()
        {
            InitializeComponent();

            ListViewProductos.ItemSelected += ListViewProductos_ItemSelected;
        }

        private async void ListViewProductos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var SelectedProducto = e.SelectedItem as Producto;
            if(SelectedProducto!=null)
            {
                await Navigation.PushAsync(new productoDetalles(SelectedProducto));
                ListViewProductos.SelectedItem = null;
            }
        }
    }
}
