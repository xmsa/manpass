using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace manpass
{
    public partial class frm_Main : Form
    {
        DataBase DB;
        public frm_Main()
        {
            InitializeComponent();
            DB = new DataBase();
            //set location 
            panel_Add_Edit_View.Location = new Point(71, 64);
            panel_Help.Location = new Point(71, 64);
            panel_Login.Location = new Point(71, 64);
            panel_Manager.Location = new Point(71, 64);
            panel_Setting.Location = new Point(71, 64);
            panel_SignUp.Location = new Point(71, 64);
            //set size
            panel_Add_Edit_View.Size = new Size(715, 453);
            panel_Help.Size = new Size(715, 453);
            panel_Login.Size = new Size(715, 453);
            panel_Manager.Size = new Size(715, 453);
            panel_Setting.Size = new Size(715, 453);
            panel_SignUp.Size = new Size(715, 453);

        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            btn_PLeft_Manager.Visible = false;
            btn_PLeft_Setting.Visible = false;
            panel_Add_Edit_View.Visible =false;
            panel_Help.Visible =false;
            panel_Login.Visible =true;
            panel_Manager.Visible =false;
            panel_Setting.Visible =false;
            panel_SignUp.Visible =false;
            
        }

        public static bool openfile(ref string path, string Filter)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = Filter;
            openFileDialog.FileName = String.Empty;

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                return false;
                   
            }
            path = string.Empty;
            return true ;
        }

        private void Btn_PLeft_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Btn_PLeft_Login_Click(object sender, EventArgs e)
        {
            panel_Add_Edit_View.Visible = false;
            panel_Help.Visible = false;
            panel_Login.Visible = true;
            panel_Manager.Visible = false;
            panel_Setting.Visible = false;
            panel_SignUp.Visible = false;



        }

        private void Btn_PLeft_Setting_Click(object sender, EventArgs e)
        {
            panel_Add_Edit_View.Visible = false;
            panel_Help.Visible = false;
            panel_Login.Visible = false;
            panel_Manager.Visible = false;
            panel_Setting.Visible = true;
            panel_SignUp.Visible = false;

        }

        private void Btn_PLeft_Help_Click(object sender, EventArgs e)
        {
            panel_Add_Edit_View.Visible = false;
            panel_Help.Visible = true;
            panel_Login.Visible = false;
            panel_Manager.Visible = false;
            panel_Setting.Visible = false;
            panel_SignUp.Visible = false;
        }

        private void Btn_PLeft_Manager_Click(object sender, EventArgs e)
        {
            panel_Add_Edit_View.Visible = false;
            panel_Help.Visible = false;
            panel_Login.Visible = false;
            panel_Manager.Visible = true;
            panel_Setting.Visible = false;
            panel_SignUp.Visible = false;
        }

        private void Btn_PLog_SignUp_Click(object sender, EventArgs e)
        {
            panel_Add_Edit_View.Visible = false;
            panel_Help.Visible = false;
            panel_Login.Visible = false;
            panel_Manager.Visible = false;
            panel_Setting.Visible = false;
            panel_SignUp.Visible = true;
        }

        private void Btn_PSign_back_Click(object sender, EventArgs e)
        {
            panel_Add_Edit_View.Visible = false;
            panel_Help.Visible = false;
            panel_Login.Visible = true;
            panel_Manager.Visible = false;
            panel_Setting.Visible = false;
            panel_SignUp.Visible = false;
        }

        private void Btn_PSign_clear_Click(object sender, EventArgs e)
        {
            txt_PSign_CPassWord.Text = string.Empty;
            txt_PSign_Email.Text = string.Empty;
            txt_PSign_FirstName.Text = string.Empty;
            txt_PSign_LastName.Text = string.Empty;
            txt_PSign_PassWord.Text = string.Empty;
            txt_PSign_Phone_Number.Text = string.Empty;
            txt_PSign_Username.Text = string.Empty;

        }

        private void Btn_PSign_Add_Click(object sender, EventArgs e)
        {
            if (txt_PSign_CPassWord.Text== txt_PSign_PassWord.Text)
            {
            Dictionary<string, string> dict_profile = new Dictionary<string, string>();

                dict_profile.Add("User", txt_PSign_Username.Text );
                dict_profile.Add("FirstName",txt_PSign_FirstName.Text);
                dict_profile.Add("LastName", txt_PSign_LastName.Text);
                dict_profile.Add("Email", txt_PSign_Email.Text);
                dict_profile.Add("phoneNumber", txt_PSign_Phone_Number.Text);
                DB.insert("tb_profile", dict_profile);

                Dictionary<string, string> dict_user = new Dictionary<string, string>();
                dict_user.Add("User", txt_PSign_Username.Text);
                dict_user.Add("Password", txt_PSign_PassWord.Text);

                DB.insert("tb_user", dict_user);

            }
            else
            {
                MessageBox.Show("Those passwords didn't match. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
