using SQLite;
using SqLiteB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqLiteB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;

        private SQLiteAsyncConnection _con;
        IEnumerable<Estudiante> ResultadoDelete;
        IEnumerable<Estudiante> ResultadoUpdate;
        public Elemento(int ID)
        {
           
            _con = DependencyService.Get<Database>().GetConnection();
            IdSeleccionado = ID;
            InitializeComponent();
            
        }

        private void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);

                ResultadoUpdate = Update(db, Nombre.Text, Usuario.Text, Contrasena.Text, IdSeleccionado);

                DisplayAlert("Alerta", "Dato actualizado", "OK");


                Nombre.Text = "";
                Usuario.Text = "";
                Contrasena.Text = "";
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", "Error" + ex.Message, "OK");
            }

        }
        //borrar metodo
        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where Id = ?", id);

        }
        //actualizar metodo
        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre, string usuario, string contrasena, int id)
        {

            return db.Query<Estudiante>("UPDATE Estudiante SET Nombre = ?, Usuario = ?," +
                "Contrasena = ? WHERE Id = ?", nombre, usuario, contrasena, id);
        }


        private void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);

                ResultadoDelete = Delete(db, IdSeleccionado);
                DisplayAlert("Alerta", "Dato eliminado correctamente", "OK");

                Nombre.Text = "";
                Usuario.Text = "";
                Contrasena.Text = "";
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", "Error" + ex.Message, "OK");
            }
        }
    }
}