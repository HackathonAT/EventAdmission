using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace FaceAPI_Services
{
    //NOT SURE IF THAT WORKKS, ITS 5 IN THE MORNING!
    public class AzureDatabseConnectorcs
    {
        public static void Connector(string PersonId, string FirstName, string LastName, string Status, string Role, DateTime Birthday)
        {
            //Fill in the Data
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "your_server.database.windows.net";
            builder.UserID = "your_user";
            builder.Password = "your_password";
            builder.InitialCatalog = "your_database";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append($"INSERT INTO <PLEASE TELL ME THE NAME> VALUES {{'{PersonId}', '{Birthday}', '{Status}', '{Role}', '{FirstName}', '{LastName}'}}");
                String sql = sb.ToString();
                connection.Close();
            }
        }
    }
}