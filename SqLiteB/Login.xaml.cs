using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SqLiteB.Models;
using System.IO;

namespace SqLiteB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection _con;
        public Login()
        {
            InitializeComponent();
            _con = DependencyService.Get<Database>().GetConnection();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documentPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.bd3");
                var db = new SQLiteConnection(documentPath);
                //para ingresar a una tabla que existe
                //se crea una sola vez luego esta sabe que ya esta registrado
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContrasena.Text);
                if (resultado.Count() > 0) {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario no registrado", "ok");

                }
                
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante WHERE usuario = ? and contrasena = ?",usuario,contrasena);
        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }
    }
}