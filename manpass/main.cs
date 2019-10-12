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
        string Id;
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
            panel_Change_Password.Location = new Point(71, 64);
            panel_About.Location = new Point(71, 64);

            //set size
            panel_Add_Edit_View.Size = new Size(715, 453);
            panel_Help.Size = new Size(715, 453);
            panel_Login.Size = new Size(715, 453);
            panel_Manager.Size = new Size(715, 453);
            panel_Setting.Size = new Size(715, 453);
            panel_SignUp.Size = new Size(715, 453);
            panel_Change_Password.Size = new Size(715, 453);
            panel_About.Size = new Size(715, 453);
            btn_PLog_ForGetPassWord.Enabled = false;

        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            btn_PLeft_Manager.Visible = false;
            btn_PLeft_Setting.Visible = false;
            panel_Add_Edit_View.Visible = false;
            panel_Help.Visible = false;
            panel_Login.Visible = true;
            panel_Manager.Visible = false;
            panel_Setting.Visible = false;
            panel_SignUp.Visible = false;
            panel_Change_Password.Visible = false;
            panel_About.Visible = false;
            txt_PLog_UserName.Focus();
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
            return true;
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
            panel_Change_Password.Visible = false;
            panel_About.Visible = false;



        }

        private void Btn_PLeft_Setting_Click(object sender, EventArgs e)
        {
            panel_Add_Edit_View.Visible = false;
            panel_Help.Visible = false;
            panel_Login.Visible = false;
            panel_Manager.Visible = false;
            panel_Setting.Visible = true;
            panel_SignUp.Visible = false;
            panel_Change_Password.Visible = false;
            panel_About.Visible = false;

        }

        private void Btn_PLeft_Help_Click(object sender, EventArgs e)
        {
            panel_Add_Edit_View.Visible = false;
            panel_Help.Visible = true;
            panel_Login.Visible = false;
            panel_Manager.Visible = false;
            panel_Setting.Visible = false;
            panel_SignUp.Visible = false;
            panel_Change_Password.Visible = false;
            panel_About.Visible = false;

        }

        private void Btn_PLeft_Manager_Click(object sender, EventArgs e)
        {
            panel_Add_Edit_View.Visible = false;
            panel_Help.Visible = false;
            panel_Login.Visible = false;
            panel_Manager.Visible = true;
            panel_Setting.Visible = false;
            panel_SignUp.Visible = false;
            panel_Change_Password.Visible = false;
            panel_About.Visible = false;
            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<string> lst = new List<string>();
            lst.Add("Title");
            lst.Add("Id");
            dict.Add("Who", user);
            var Result = DB.search("tb_password", dict, lst);
            listBox_PManage_Title.Items.Clear();
            for (int i = 0; i < Result.Rows.Count; i++)
            {
                listBox_PManage_Title.Items.Add("Id: ("+Result.Rows[i][1].ToString()+") Title: "+Result.Rows[i][0].ToString());
            }

        }

        private void Btn_PLog_SignUp_Click(object sender, EventArgs e)
        {
            panel_Add_Edit_View.Visible = false;
            panel_Help.Visible = false;
            panel_Login.Visible = false;
            panel_Manager.Visible = false;
            panel_Setting.Visible = false;
            panel_SignUp.Visible = true;
            panel_Change_Password.Visible = false;

            panel_About.Visible = false;

        }

        private void Btn_PSign_back_Click(object sender, EventArgs e)
        {
            panel_Add_Edit_View.Visible = false;
            panel_Help.Visible = false;
            panel_Login.Visible = true;
            panel_Manager.Visible = false;
            panel_Setting.Visible = false;
            panel_SignUp.Visible = false;
            panel_Change_Password.Visible = false;

            panel_About.Visible = false;

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
            string error = string.Empty;
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
                MessageBox.Show(error + "fields are empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_PSign_PassWord.Text.Length < 8)
            {
                MessageBox.Show("Use 8 characters or more for your password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_PSign_CPassWord.Text == txt_PSign_PassWord.Text)
            {
                Dictionary<string, string> dict_user = new Dictionary<string, string>();
                dict_user.Add("User", txt_PSign_Username.Text);
                dict_user.Add("Password", txt_PSign_PassWord.Text);

                if (DB.insert("tb_user", dict_user))
                {
                    Dictionary<string, string> dict_profile = new Dictionary<string, string>();
                    dict_profile.Add("User", txt_PSign_Username.Text);
                    dict_profile.Add("FirstName", txt_PSign_FirstName.Text);
                    dict_profile.Add("LastName", txt_PSign_LastName.Text);
                    dict_profile.Add("Email", txt_PSign_Email.Text);
                    dict_profile.Add("phoneNumber", txt_PSign_Phone_Number.Text);
                    if (DB.insert("tb_profile", dict_profile))
                    {
                        MessageBox.Show("Welcome " + txt_PSign_FirstName.Text);
                        user = txt_PSign_Username.Text;
                        btn_PLeft_Login.Visible = false;
                        btn_PLeft_Manager.Visible = true;
                        btn_PLeft_Setting.Visible = true;
                        panel_Login.Visible = false;
                        panel_SignUp.Visible = false;
                        panel_Change_Password.Visible = false;
                        panel_About.Visible = false;

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
            show(txt_PLog_PassWord);
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
                    panel_Change_Password.Visible = false;

                    panel_About.Visible = false;

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

        private void Btn_PSetting_ExportDB_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            if (fileSave(ref path, "DataBase | DataBase.sqlite", "DataBase.sqlite"))
            {
                File.Copy(Application.StartupPath + @"\DataBase.sqlite", path);

            }

        }
        public static bool fileSave(ref string path, string Filter, string FileName)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = Filter;
            save.FileName = FileName;
            var result = save.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = save.FileName;
                return true;
            }
            return false;
        }

        private void Btn_PSetting_Import_Click(object sender, EventArgs e)
        {
            bool flag;
            string path = string.Empty;
            flag = frm_Main.openfile(ref path, "DataBase|DataBase.sqlite");
            if (!flag)
            {
                MessageBox.Show("Please log in again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.IO.File.Copy(path, Application.StartupPath.ToString() + @"\DataBase.sqlite", true);

                btn_PLeft_Manager.Visible = false;
                btn_PLeft_Setting.Visible = false;
                btn_PLeft_Login.Visible = true;

                panel_Add_Edit_View.Visible = false;
                panel_Help.Visible = false;
                panel_Login.Visible = true;
                panel_Manager.Visible = false;
                panel_Setting.Visible = false;
                panel_SignUp.Visible = false;
                panel_Change_Password.Visible = false;
                panel_About.Visible = false;


                txt_PLog_UserName.Text = string.Empty;
                txt_PLog_PassWord.Text = string.Empty;
                txt_PSign_CPassWord.Text = string.Empty;
                txt_PSign_Email.Text = string.Empty;
                txt_PSign_FirstName.Text = string.Empty;
                txt_PSign_LastName.Text = string.Empty;
                txt_PSign_PassWord.Text = string.Empty;
                txt_PSign_Phone_Number.Text = string.Empty;
                txt_PSign_Username.Text = string.Empty;




            }

        }

        private void Btn_PSetting_EditPassWord_Click(object sender, EventArgs e)
        {
            panel_Change_Password.Visible = true;
            panel_Add_Edit_View.Visible = false;
            panel_Help.Visible = false;
            panel_Login.Visible = false;
            panel_Manager.Visible = false;
            panel_Setting.Visible = false;
            panel_SignUp.Visible = false;
            panel_About.Visible = false;

            btn_PLeft_Exit.Visible = false;
            btn_PLeft_Help.Visible = false;
            btn_PLeft_Login.Visible = false;
            btn_PLeft_Manager.Visible = false;
            btn_PLeft_Setting.Visible = false;
            txt_PChPass_CPassword.Clear();
            txt_PChPass_NPassword.Clear();
            txt_PChPass_Password.Clear();


        }

        private void Btn_ChPass_Cancel_Click(object sender, EventArgs e)
        {
            panel_Change_Password.Visible = false;
            panel_Setting.Visible = true;
            panel_About.Visible = false;

            btn_PLeft_Exit.Visible = true;
            btn_PLeft_Help.Visible = true;
            btn_PLeft_Login.Visible = false;
            btn_PLeft_Manager.Visible = true;
            btn_PLeft_Setting.Visible = true;

        }

        private void Btn_PChPass_ShowPass_Click(object sender, EventArgs e)
        {
            show(txt_PChPass_Password);

        }

        private void Btn_PChPass_ShowNPass_Click(object sender, EventArgs e)
        {
            show(txt_PChPass_NPassword);
        }

        private void Btn_PChPass_ShowCPass_Click(object sender, EventArgs e)
        {
            show(txt_PChPass_CPassword);
        }

        private void Btn_PChPass_Ok_Click(object sender, EventArgs e)
        {

            Dictionary<string, string> dict = new Dictionary<string, string>();

            bool flag = false;
            string error = string.Empty;
            if (check_txt_Empty(txt_PChPass_Password))
            {
                error += "Password\n";
                flag = true;
            }
            if (check_txt_Empty(txt_PChPass_NPassword))
            {
                error += "New Password\n";
                flag = true;
            }
            if (check_txt_Empty(txt_PChPass_CPassword))
            {
                error += "Confirm\n";
                flag = true;
            }
            if (flag)
            {
                MessageBox.Show(error + "fields are empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_PChPass_NPassword.Text.Length < 8)
            {
                MessageBox.Show("Use 8 characters or more for your password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_PChPass_CPassword.Text != txt_PChPass_NPassword.Text)
            {
                MessageBox.Show("Those passwords didn't match. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<string> lst = new List<string>();
            dict.Add("User", user);
            var rows = DB.search("tb_user", dict, lst).Rows;

            if (rows[0][1].ToString() == txt_PChPass_Password.Text)
            {
                dict.Clear();
                dict.Add("Password", txt_PChPass_NPassword.Text);
                DB.update("tb_user", user, dict);
                panel_Change_Password.Visible = false;
                panel_Setting.Visible = true;
                btn_PLeft_Exit.Visible = true;
                btn_PLeft_Help.Visible = true;
                btn_PLeft_Login.Visible = false;
                btn_PLeft_Manager.Visible = true;
                btn_PLeft_Setting.Visible = true;
                panel_About.Visible = false;

                return;
            }
            else
            {
                MessageBox.Show("Wrong password. ");
            }
        }

        private void show(TextBox txt)
        {
            if (txt.PasswordChar == '*')
                txt.PasswordChar = '\0';
            else
                txt.PasswordChar = '*';
        }

        private void Btn_PHelp_About_Click(object sender, EventArgs e)
        {
            panel_About.Visible = true;

            panel_Add_Edit_View.Visible = false;
            panel_Help.Visible = false;
            panel_Login.Visible = false;
            panel_Manager.Visible = false;
            panel_Setting.Visible = false;
            panel_SignUp.Visible = false;
            panel_Change_Password.Visible = false;
        }

        private void LinkLabel_PAbout_Instagram_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://instagram.com/xmzhry/");

        }

        private void LinkLabel_PAbout_Mail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:msaxmsa@gmail.com");

        }

        private void LinkLabel_PAbout_Github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xmsa");

        }

        private void LinkLabel_PAbout_telegtam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/Xmzhry");
        }

        private void Btn_PManager_Add_Click(object sender, EventArgs e)
        {
            panel_Add_Edit_View.Visible = true;
            panel_Help.Visible = false;
            panel_Login.Visible = false;
            panel_Manager.Visible = false;
            panel_Setting.Visible = false;
            panel_SignUp.Visible = false;
            panel_Change_Password.Visible = false;
            panel_About.Visible = false;

            groupBox_PAEV_Random.Visible = true;

            btn_PAEV_Ok.Visible = false;
            txt_PAEV_Description.Clear();
            txt_PAEV_PassWord.Clear();
            txt_PAEV_Site.Clear();
            txt_PAEV_Title.Clear();
            txt_PAEV_UserName.Clear();
            btn_PAEV_Edit.Visible = false;

            txt_PAEV_Description.Enabled=true;
            txt_PAEV_PassWord.Enabled = true;
            txt_PAEV_Site.Enabled = true;
            txt_PAEV_Title.Enabled = true;
            txt_PAEV_UserName.Enabled = true;



        }

        private void Btn_PAEV_Random_Click(object sender, EventArgs e)
        {
            var rnd = random("qwertyuiopasdfghjklzxcvbnm", (int)numericUpDown_PAEV_Down.Value);
            rnd.AddRange(random("qwertyuiopasdfghjklzxcvbnm".ToUpper(), (int)numericUpDown_PAEV_Up.Value));
            rnd.AddRange(random("1234567890".ToUpper(), (int)numericUpDown_PAEV_Number.Value));
            rnd.AddRange(random("!@#$%".ToUpper(), (int)numericUpDown_PAEV_Symbol.Value));

            txt_PAEV_PassWord.Text = random(rnd);
        }

        private string random(List<char> lst)
        {
            string str = string.Empty;
            Random rnd = new Random();
            while (lst.Count > 0)
            {
                int index = rnd.Next(lst.Count);
                str += lst[index];

                lst.RemoveAt(index);
            }
            return str;
        }

        private List<char> random(string str, int len)
        {
            List<char> lst = new List<char>();
            Random rnd = new Random();
            for (int i = 0; i < len; i++)
            {
                int index = rnd.Next(str.Length);
                lst.Add(str[index]);
            }
            return lst;

        }

        private void Btn_PAEV_Add_Click(object sender, EventArgs e)
        {
            
            bool flag = false;
            string error = string.Empty;
            if (check_txt_Empty(txt_PAEV_Title))
            {
                error += "Title\n";
                flag = true;
            }
            if (check_txt_Empty(txt_PAEV_PassWord))
            {
                error += "PassWord\n";
                flag = true;
            }
            if (flag)
            {
                MessageBox.Show(error + "fields are empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Random rnd = new Random();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Id", rnd.Next(1000000, 999999999).ToString());
            dict.Add("Title", txt_PAEV_Title.Text);
            dict.Add("User", txt_PAEV_UserName.Text);
            dict.Add("Password", txt_PAEV_PassWord.Text);
            dict.Add("Site", txt_PAEV_Site.Text);
            dict.Add("Description", txt_PAEV_Description.Text);
            dict.Add("Who", user);
            while (!(DB.insert("tb_password", dict)))
            {
                dict["Id"] = rnd.Next(100000000, 999999999).ToString();
            }
            txt_PAEV_Title.Text = string.Empty;
            txt_PAEV_UserName.Text = string.Empty;
            txt_PAEV_PassWord.Text = string.Empty;
            txt_PAEV_Site.Text = string.Empty;
            txt_PAEV_Description.Text = string.Empty;
            panel_Add_Edit_View.Visible = false;
            panel_Manager.Visible = true;
            Btn_PLeft_Manager_Click(sender, e);
        }

        private void Btn_PManager_View_Click(object sender, EventArgs e)
        {
            if (showvalue()) { 
                txt_PAEV_Description.Enabled=false;
                txt_PAEV_PassWord.Enabled=false;
                txt_PAEV_Site.Enabled=false;
                txt_PAEV_Title.Enabled=false;
                txt_PAEV_UserName.Enabled = false;
                groupBox_PAEV_Random.Visible = false;
                btn_PAEV_Random.Visible = false;
                btn_PAEV_Add.Visible = false;
                panel_Add_Edit_View.Visible = true;
                panel_Manager.Visible = false;
                btn_PAEV_Ok.Visible = false;
            }
        }

        private bool showvalue()
        {
            try
            {
                string str;
                str = listBox_PManage_Title.SelectedItem.ToString();
                str = str.Remove(0, 5);
                Id = str.Remove(9, str.Length - 9);
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("Id", Id);
                List<string> lst = new List<string>();
                var Result = DB.search("tb_password", dict, lst);
                txt_PAEV_Description.Text = Result.Rows[0][5].ToString();
                txt_PAEV_PassWord.Text = Result.Rows[0][3].ToString();
                txt_PAEV_Site.Text = Result.Rows[0][4].ToString();
                txt_PAEV_Title.Text = Result.Rows[0][1].ToString();
                txt_PAEV_UserName.Text = Result.Rows[0][2].ToString();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("please select item from list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Txt_PLog_PassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Btn_PLog_Login_Click(sender, e);
            }
        }

        private void Txt_PLog_UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txt_PLog_PassWord.Focus();
            }
        }

        private void Btn_PManager_Edit_Click(object sender, EventArgs e)
        {
            txt_PAEV_Description.Enabled = true;
            txt_PAEV_PassWord.Enabled = true;
            txt_PAEV_Site.Enabled = true;
            txt_PAEV_Title.Enabled = true;
            txt_PAEV_UserName.Enabled = true;
            groupBox_PAEV_Random.Visible = true;
            btn_PAEV_Random.Visible = true;
            btn_PAEV_Add.Visible = false;
            panel_Add_Edit_View.Visible = true;
            panel_Manager.Visible = false;
            btn_PAEV_Ok.Visible = true;
        }

        private void Btn_PAEV_Edit_Click(object sender, EventArgs e)
        {
            txt_PAEV_Description.Enabled = true;
            txt_PAEV_PassWord.Enabled = true;
            txt_PAEV_Site.Enabled = true;
            txt_PAEV_Title.Enabled = true;
            txt_PAEV_UserName.Enabled = true;
            btn_PAEV_Random.Visible = true;
            btn_PAEV_Add.Visible = false;
            btn_PAEV_Edit.Visible = false;
            btn_PAEV_Ok.Visible = true;
            groupBox_PAEV_Random.Visible = true;
            
        }

        private void Btn_PAEV_Ok_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string error = string.Empty;
            if (check_txt_Empty(txt_PAEV_Title))
            {
                error += "Title\n";
                flag = true;
            }
            if (check_txt_Empty(txt_PAEV_PassWord))
            {
                error += "PassWord\n";
                flag = true;
            }
            if (flag)
            {
                MessageBox.Show(error + "fields are empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Dictionary<string, string> dict = new Dictionary<string, string>();;
            dict.Add("Title", txt_PAEV_Title.Text);
            dict.Add("User", txt_PAEV_UserName.Text);
            dict.Add("Password", txt_PAEV_PassWord.Text);
            dict.Add("Site", txt_PAEV_Site.Text);
            dict.Add("Description", txt_PAEV_Description.Text);
            DB.update("tb_password", Id, dict);
            panel_Add_Edit_View.Visible = false;
            panel_Manager.Visible = true;

        }

        private void Btn_PAEV_Back_Click(object sender, EventArgs e)
        {

        }
    }
}
