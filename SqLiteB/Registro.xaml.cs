using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SqLiteB.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqLiteB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection _con;
        public Registro()
        {
            InitializeComponent();
            _con = DependencyService.Get<Database>().GetConnection();
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Datos = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasena = txtContrasena.Text };
                _con.InsertAsync(Datos);
                
                txtNombre.Text = "";
                txtUsuario.Text = "";
                txtContrasena.Text = "";
                DisplayAlert("Alerta", "Dato Ingresado", "ok");
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}