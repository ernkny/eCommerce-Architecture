using Project.DataAccessL.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessL.DataAccess.CreateTable
{
    public class EFCreateTable
    {
        string _connection;
        public EFCreateTable()
        {
            ConnectionStr connection = new ConnectionStr();
            _connection = connection.SqlCon;

        }


        public void CreateTable()
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var querString = "CREATE TABLE Persons(PersonId int NOT NULL IDENTITY(1,1) PRIMARY KEY,Name varchar(255),Surname varchar(255),Age int);";
                SqlCommand command = new SqlCommand(querString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();

            }
        }
    }
}
