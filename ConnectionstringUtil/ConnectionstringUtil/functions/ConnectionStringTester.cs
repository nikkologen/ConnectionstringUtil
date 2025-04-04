using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ConnectionstringUtil.functions
{
    public static class ConnectionStringTester
    {
        public static string TestConnectionString(CommandInterpeter command)
        {
            if (command.Args.Length != 2)
                return "SyntaxError: formate must be: testcon {connectionstring}";
            using (SqlConnection connection = new SqlConnection(command.Args[1]))
            {
                try
                {
                    connection.Open(); // Open the connection
                    // Test the connection with a simple query
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT CURRENT_TIMESTAMP;", connection))
                    {
                        var result = sqlCommand.ExecuteScalar(); // Execute the query
                        Console.WriteLine("Current Timestamp: " + result);
                    }
                    return "connection opened successfully";

                }
                catch (Exception ex)
                {
                    return "Error: " + ex.Message;
                }
            }
        }
    }
}
