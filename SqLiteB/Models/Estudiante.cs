using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqLiteB.Models
{
    public class Estudiante
    {
        //crear los atributos que va a tener
        
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        
        [MaxLength(255)]
        public string Nombre { set; get; }
        
    
        
        [MaxLength(255)]
        public string Usuario { set; get; }
       
        [MaxLength(255)]
        public string Contrasena { set; get; }

    }
}
