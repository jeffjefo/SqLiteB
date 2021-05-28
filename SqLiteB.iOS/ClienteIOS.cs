﻿using Foundation;
using SQLite;
using SqLiteB.iOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;

[assembly:Xamarin.Forms.Dependency(typeof(ClienteIOS))]
namespace SqLiteB.iOS
{
    class ClienteIOS : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}