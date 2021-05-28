using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SqLiteB.Droid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

[assembly:Xamarin.Forms.Dependency(typeof(ClienteAndroid))]
namespace SqLiteB.Droid
{
    class ClienteAndroid : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}