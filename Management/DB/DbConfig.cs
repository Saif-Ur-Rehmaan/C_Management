using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Management.DB
{
    internal static class DbConfig
    {

        public static SqlConnection conn = new SqlConnection();

        public static bool OpenConn()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error");
                return false;
            }
        }
    
        public static List<KeyValuePair<int, List<KeyValuePair<string, object>>>> GetData(string table,string columns="*" ,string  Conditions="")
        { 
            List<
                KeyValuePair<int, List<
                    KeyValuePair<string, object>>
                    >
                >
                listOfPairs = new List<KeyValuePair<int, List<KeyValuePair<string, object>>>>();

            string query = (string.IsNullOrEmpty(Conditions)) ? $"SELECT {columns} FROM {table} " : $"SELECT {columns} FROM {table} Where {Conditions} ";
            try
            {
                if (!OpenConn())
                {
                    throw new Exception("Connection Failed");
                };
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.ExecuteNonQuery();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int Rownumber = 0;
                //this loop itrates for each row
                while (reader.Read())
                {
                    //this loop itrates for each column
                    // Create a list to store column data for the current row
                    List<KeyValuePair<string, object>> rowColumnData = new();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string Colname = reader.GetName(i);
                        object ValueOfColumn = reader.GetValue(i);

                        // Create a KeyValuePair for the current column and add it to the row's list
                        rowColumnData.Add(new KeyValuePair<string, object>(Colname, ValueOfColumn));
                    }

                    // Add the row's list to the listOfPairs
                    listOfPairs.Add(new KeyValuePair<int, List<KeyValuePair<string, object>>>(Rownumber, rowColumnData));

                    Rownumber++;
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show($"Action Failed While Getting Data \n Exception : {ex.Message}");
            }

                return listOfPairs;

        }
            
    
    }


}
