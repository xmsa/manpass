using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace manpass
{
    class DataBase
    {
        SQLiteConnection m_dbConnection;
        public DataBase()
        {
            bool flag = true;
            if (!File.Exists(Application.StartupPath.ToString() + @"\DataBase.sqlite"))
            {
                while (flag)
                {
                    var message = MessageBox.Show("Build a new DataBase \"Yes\" \nImport the DataBase \"No\"", "DataBase not found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (message == DialogResult.Yes)
                    {
                        CreateFileDB("DataBase");

                        m_dbConnection = ConnectionDB("DataBase");

                        Dictionary<string, string> tb_user = new Dictionary<string, string>();
                        Dictionary<string, string> tb_profile = new Dictionary<string, string>();
                        Dictionary<string, string> tb_password = new Dictionary<string, string>();

                        tb_user.Add("User", "TEXT NOT NULL PRIMARY KEY");
                        tb_user.Add("Password", "TEXT NOT NULL");


                        tb_profile.Add("User", "TEXT NOT NULL PRIMARY KEY");
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
                        break;
                    }
                    else if (message == DialogResult.No)
                    {
                        string path = string.Empty;
                        flag = frm_Main.openfile(ref path, "DataBase|DataBase.sqlite");
                        if (flag)
                        {
                            continue;
                        }
                        System.IO.File.Move(path, Application.StartupPath.ToString() + @"\DataBase.sqlite");

                    }

                }

            }
            m_dbConnection = ConnectionDB("DataBase");
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("User", "admin");
            dict.Add("Password", "123");
            insert("tb_user", dict);
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
                tostr += (item.Key + str +"'"+ item.Value+"'" + " , ");
                flag = true;

            }
            if (flag)
                tostr = tostr.Remove(tostr.Length - 2);
            return tostr;
        }
        public void insert(string tbl, Dictionary<string, string> dict)
        {

            m_dbConnection.Open();
            string str = dictostr_in(dict);
            string sql = "insert into " + tbl + str;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();


        }

        private static string dictostr_in(Dictionary<string, string> dict)
        {
            string str = string.Empty;
            string key = string.Empty;
            string value = string.Empty;

            foreach (KeyValuePair<string, string> item in dict)
            {
                key += item.Key + " , ";
                value += "'" + item.Value + "',";
            }
            key = key.Remove(key.Length - 2);
            value = value.Remove(value.Length - 1);

            str = " ( " + key + " ) values ( " + value + " ) ";
            return str;
        }
        

    }
}
