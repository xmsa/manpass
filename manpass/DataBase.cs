using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace manpass
{
    class DataBase
    {
        public DataBase()
        {
            if (!File.Exists(Application.StartupPath + @"DataBase.sqlite"))
            {
                var message=MessageBox.Show("Build a new DataBase \"Yes\" \nImport the DataBase \"No\"", "DataBase not found",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (message==DialogResult.Yes)
                {
                    CreateFileDB("DataBase");

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
    }
}
