using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using SqLiteB.Models;

namespace SqLiteB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection _con;
        private ObservableCollection<Estudiante> _tablaEstudiante;
       
        public ConsultaRegistro()
        {
            InitializeComponent();
            _con = DependencyService.Get<Database>().GetConnection();
        }

        protected async override void OnAppearing() {
            var resultado = await _con.Table<Estudiante>().ToListAsync();
            _tablaEstudiante = new ObservableCollection<Estudiante>(resultado);
            ListaUsuarios.ItemsSource = _tablaEstudiante;
            base.OnAppearing();
        }

        private void ListaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //captura de la fila va aser esto
            var Obj = (Estudiante)e.SelectedItem;
            var item = Obj.Id.ToString();
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Elemento(ID));
            }
            catch
            {

            }
        }
    }
}