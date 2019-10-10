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
        string user;
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
            btn_PLog_ForGetPassWord.Enabled = false;

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
            bool flag = false;
            string error=string.Empty;
            if (check_txt_Empty(txt_PSign_Username))
            {
                error += "Username\n";
                flag = true;
            }
            if (check_txt_Empty(txt_PSign_PassWord))
            {
                error += "PassWord\n";
                flag = true;
            }
            if (check_txt_Empty(txt_PSign_CPassWord))
            {
                error += "Confrim\n";
                flag = true;
            }
            if (check_txt_Empty(txt_PSign_FirstName))
            {
                error += "FirstName\n";
                flag = true;
            }
            if (check_txt_Empty(txt_PSign_LastName))
            {
                error += "FirstName\n";
                flag = true;
            }
            if (check_txt_Empty(txt_PSign_Email))
            {
                error += "Email\n";
                flag = true;
            }
            if (check_txt_Empty(txt_PSign_Phone_Number))
            {
                error += "Phone Number\n";
                flag = true;
            }
            if (flag)
            {
                MessageBox.Show(error+ "fields are empty","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_PSign_PassWord.Text.Length<8)
            {
                MessageBox.Show("Use 8 characters or more for your password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            if (txt_PSign_CPassWord.Text== txt_PSign_PassWord.Text)
            {
                Dictionary<string, string> dict_user = new Dictionary<string, string>();
                dict_user.Add("User", txt_PSign_Username.Text);
                dict_user.Add("Password", txt_PSign_PassWord.Text);

                if (DB.insert("tb_user", dict_user))
                {
                    Dictionary<string, string> dict_profile = new Dictionary<string, string>();
                    dict_profile.Add("User", txt_PSign_Username.Text );
                    dict_profile.Add("FirstName",txt_PSign_FirstName.Text);
                    dict_profile.Add("LastName", txt_PSign_LastName.Text);
                    dict_profile.Add("Email", txt_PSign_Email.Text);
                    dict_profile.Add("phoneNumber", txt_PSign_Phone_Number.Text);
                    if (DB.insert("tb_profile", dict_profile))
                    {
                        MessageBox.Show("Welcome "+ txt_PSign_FirstName.Text);
                        user = txt_PSign_Username.Text;
                        btn_PLeft_Login.Visible=false;
                        btn_PLeft_Manager.Visible=true;
                        btn_PLeft_Setting.Visible = true;
                        panel_Login.Visible=false;
                        panel_SignUp.Visible = false;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Username is a duplicate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Those passwords didn't match. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool check_txt_Empty(TextBox txtbox)
        {
            return txtbox.Text == string.Empty;
        }

        private void Btn_PLog_Show_Click(object sender, EventArgs e)
        {
            if (txt_PLog_PassWord.PasswordChar=='*')
            {
                txt_PLog_PassWord.PasswordChar = '\0';
            }
            else
            {
                txt_PLog_PassWord.PasswordChar = '*';
            }
        }

        private void Btn_PLog_Login_Click(object sender, EventArgs e)
        {

            bool flag = false;
            string error = string.Empty;
            if (check_txt_Empty(txt_PLog_UserName))
            {
                error += "Username\n";
                flag = true;
            }
            if (check_txt_Empty(txt_PLog_PassWord))
            {
                error += "PassWord\n";
                flag = true;
            }
            if (flag)
            {
                MessageBox.Show(error + "fields are empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<string> lst = new List<string>();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("User", txt_PLog_UserName.Text);
            var rows = DB.search("tb_user", dict, lst).Rows;
            if (rows.Count == 1)
            {
                if (rows[0][1].ToString() == txt_PLog_PassWord.Text)
                {
                    MessageBox.Show("Welcome " + txt_PLog_UserName.Text);
                    user = txt_PLog_UserName.Text;
                    btn_PLeft_Login.Visible = false;
                    btn_PLeft_Manager.Visible = true;
                    btn_PLeft_Setting.Visible = true;
                    panel_Login.Visible = false;
                    panel_SignUp.Visible = false;
                    return;
                }
                else
                {
                    MessageBox.Show("Wrong password. Try again or click Forgot password to reset it.");
                    btn_PLog_ForGetPassWord.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Couldn't find your UserName");
            }
        }

        

        private void Pic_PSetting_Background_Click(object sender, EventArgs e)
        {
            rBtn_PSetting_Background.Checked = true;

        }

        private void Pic_PSetting_Background2_Click(object sender, EventArgs e)
        {
            rBtn_PSetting_Background2.Checked = true;

        }

        private void Pic_PSetting_Background3_Click(object sender, EventArgs e)
        {
            rBtn_PSetting_Background3.Checked = true;

        }

        private void Pic_PSetting_Background4_Click(object sender, EventArgs e)
        {
            rBtn_PSetting_Background4.Checked = true;

        }

        private void Pic_PSetting_Background5_Click(object sender, EventArgs e)
        {
            rBtn_PSetting_Background5.Checked = true;
        }

        private void RBtn_PSetting_Background_CheckedChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.background;
        }

        private void RBtn_PSetting_Background2_CheckedChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.background2;
        }

        private void RBtn_PSetting_Background3_CheckedChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.background3;
        }

        private void RBtn_PSetting_Background4_CheckedChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.background4;
        }

        private void RBtn_PSetting_Background5_CheckedChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.background5;
        }
    }
}
