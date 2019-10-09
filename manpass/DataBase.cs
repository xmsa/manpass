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
            if (!File.Exists(Application.StartupPath + @"DataBase.sqlite"))
            {
                var message=MessageBox.Show("Build a new DataBase \"Yes\" \nImport the DataBase \"No\"", "DataBase not found",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (message==DialogResult.Yes)
                {
                    CreateFileDB("DataBase");
                    m_dbConnection = ConnectionDB("DataBase");

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
    }
}
