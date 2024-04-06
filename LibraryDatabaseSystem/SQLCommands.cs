using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibraryDatabaseSystem
{
    class SQLCommands
    {
        //Database connection variables
        public static MySqlConnection conn;
        public static string myConnectionString;

        public static void Initialize(string connstr)
        {
            myConnectionString = connstr;
            conn = new MySqlConnection(myConnectionString);
        }
        //Opening connection to database
        public static bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //closing connection to database
        public static bool CloseConnection()
        {
            try
            {
                conn.Dispose();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        //Insert into database
        public static void Query(string q)
        {
            string query = q;
            if (OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Operation succeeded.", "Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    CloseConnection();
                }
            }
        }
    }
}
