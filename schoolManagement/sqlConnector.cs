using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace schoolManagement
{
    internal class sqlConnector
    {
        public  SqlConnection myConnection()
        {

            SqlConnection connect = new SqlConnection("Data Source=ROBERT;Initial Catalog=School_Management;Integrated Security=True");
            connect.Open();
            return connect;
        }

    }
}
