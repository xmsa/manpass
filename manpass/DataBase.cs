using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace manpass
{
    class DataBase
    {
        SQLiteConnection m_dbConnection;
        public DataBase()
        {
            if (!File.Exists(Application.StartupPath.ToString() + @"\DataBase.sqlite"))
            {
                var message=MessageBox.Show("Build a new DataBase \"Yes\" \nImport the DataBase \"No\"", "DataBase not found",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (message==DialogResult.Yes)
                {
                    CreateFileDB("DataBase");

                    m_dbConnection = ConnectionDB("DataBase");

                    Dictionary<string, string> tb_user = new Dictionary<string, string>();
                    Dictionary<string, string> tb_profile = new Dictionary<string, string>();
                    Dictionary<string, string> tb_password = new Dictionary<string, string>();

                    tb_user.Add("Uesr", "TEXT NOT NULL PRIMARY KEY");
                    tb_user.Add("Password", "TEXT NOT NULL");

                    tb_profile.Add("Uesr", "TEXT NOT NULL PRIMARY KEY");
                    tb_profile.Add("FirstName", "TEXT NOT NULL ");
                    tb_profile.Add("LastName", "TEXT NOT NULL ");
                    tb_profile.Add("Email", "TEXT NOT NULL ");
                    tb_profile.Add("phoneNumber", "TEXT NOT NULL ");

                    tb_password.Add("Title", "TEXT NOT NULL");
                    tb_password.Add("User", "TEXT");
                    tb_password.Add("Password", "TEXT NOT NULL");
                    tb_password.Add("Site", "TEXT");
                    tb_password.Add("Description", "TEXT");

                    create_tb(m_dbConnection, "tb_user", tb_user);
                    create_tb(m_dbConnection, "tb_profile", tb_profile);
                    create_tb(m_dbConnection, "tb_password", tb_password);
                }
                else if (message == DialogResult.No)
                {

                }
            }
        }

        private static void CreateFileDB(string name)
        {
            SQLiteConnection.CreateFile(name + ".sqlite");
        }

        public static SQLiteConnection ConnectionDB(string name)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=" + name + ".sqlite;Version=3;");
            return m_dbConnection;
        }
        private static void create_tb(SQLiteConnection m_dbConnection, string tbl, Dictionary<string, string> dict)
        {
            m_dbConnection.Open();
            string str = dictostr(dict, " ");
            string sql = "create table " + tbl + "(" + str + ")";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery(); //if is unfind
            m_dbConnection.Close();
        }
        private static string dictostr(Dictionary<string, string> dict, string str)
        {
            string tostr = string.Empty;
            bool flag = false;

            foreach (KeyValuePair<string, string> item in dict)
            {
                tostr += (item.Key + str + item.Value + " , ");
                flag = true;

            }
            if (flag)
                tostr = tostr.Remove(tostr.Length - 2);
            return tostr;
        }
    }
}
