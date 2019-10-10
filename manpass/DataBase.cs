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
                    var message = MessageBox.Show("Build a new DataBase \"Yes\" \nImport the DataBase \"No\"\nExit \"Cansel\"", "DataBase not found", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
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

                        tb_password.Add("Id", "TEXT NOT NULL PRIMARY KEY");
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
                        System.IO.File.Copy(path, Application.StartupPath.ToString() + @"\DataBase.sqlite", true);

                    }
                    else if (message == DialogResult.Cancel)
                    {
                        Environment.Exit(0);
                        return;
                    }

                }

            }
            m_dbConnection = ConnectionDB("DataBase");
        }
        ~DataBase()
        {

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
                tostr += (item.Key + str + "'" + item.Value + "'" + " , ");
                flag = true;

            }
            if (flag)
                tostr = tostr.Remove(tostr.Length - 2);
            return tostr;
        }

        public bool insert(string tbl, Dictionary<string, string> dict)
        {
            string Primary_Key = "User";

            if (tbl == "tb_password")
            {
                Primary_Key = "Id";
            }
            List<string> lst = new List<string>();
            Dictionary<string, string> dict2 = new Dictionary<string, string>();
            dict2.Add(Primary_Key, dict[Primary_Key]);

            int rows = search(tbl, dict2, lst).Rows.Count;
            if (rows == 0)
            {
                m_dbConnection.Open();
                string str = dictostr_in(dict);
                string sql = "insert into " + tbl + str;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                m_dbConnection.Close();
                return true;
            }
            else
            {
                return false;
            }
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

        public DataTable search(string tbl, Dictionary<string, string> dict, List<string> lst)
        {
            m_dbConnection.Open();
            string strwhere = string.Empty;
            string strcolumn = "*";

            if (dict.Count != 0)
            {
                strwhere = " where " + dicttostr(dict);
            }
            if (lst.Count != 0)
            {
                strcolumn = lsttostr(lst);
            }

            string str = "select " + strcolumn + " from " + tbl + strwhere;
            SQLiteCommand command = new SQLiteCommand(str, m_dbConnection);


            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(str, m_dbConnection);

            da.Fill(dt);


            m_dbConnection.Close();
            return dt;
        }

        private static string lsttostr(List<string> lst)
        {
            string str = string.Empty;
            foreach (var item in lst)
            {
                str += item + " , ";
            }
            return str.Remove(str.Length - 2);
        }

        private static string dicttostr(Dictionary<string, string> dict)
        {
            string str = string.Empty;
            foreach (var item in dict)
            {
                str += item.Key + " = '" + item.Value + "' , ";
            }
            return str.Remove(str.Length - 2);
        }

        public void update(string tbl, string value, Dictionary<string, string> dict)
        {

            m_dbConnection.Open();
            string str = dictostr(dict, "=");
            string str2 = "User";

            if ("tb_password" == tbl)
                str2 = "Id";

            string sql = "UPDATE " + tbl + " SET " + str + " WHERE " + str2 + " = '" + value + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
    }
}
