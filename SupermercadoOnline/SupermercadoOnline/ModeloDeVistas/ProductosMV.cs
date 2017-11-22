using SupermercadoOnline.Azure;
using SupermercadoOnline.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SupermercadoOnline.ModeloDeVistas
{
    class ProductosMV : INotifyPropertyChanged
    {
        public ObservableCollection<Producto> Productos { get; set; }

        public ProductosMV()
        {
            Productos = new ObservableCollection<Producto>();
            GetProductosCommand = new Command(
                async ()=> await GetProductos(),
                ()=>!IsBusy);
        }

        public Command GetProductosCommand { get; set; }

        private bool Busy;

        public bool IsBusy
        {
            get { return Busy; }
            set
            {
                Busy = value;
                OnPropertyChanged();
                GetProductosCommand.ChangeCanExecute();
            }
        }

        async Task GetProductos()
        {
            if(!IsBusy)
            {
                Exception Error = null;

                try
                {
                    IsBusy = true;

                    var Servicio = new AzureService();
                    var Item = await Servicio.GetProductos();

                    Productos.Clear();
                    foreach(var Producto in Item)
                    {
                        Productos.Add(Producto);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error:{ex}");
                    Error = ex;
                }
                finally
                {
                    IsBusy = false;
                }

                if(Error!=null)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error!!!",Error.Message,"OK");
                }
            }
            return;
        }

        void OnPropertyChanged([CallerMemberName]string PropertyName = null)
        {
            if(PropertyName!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
