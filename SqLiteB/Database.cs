using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SqLiteB
{
    //convertir en interface
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();

    }
}
