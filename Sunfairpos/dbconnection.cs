using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunfairpos
{
    class dbconnection
    {
        public string connection()
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Acer\Desktop\Project\Sunfairpos\db\sunfairdb.mdf;Integrated Security=True;Connect Timeout=30";
            return con;
        }
    }
}
