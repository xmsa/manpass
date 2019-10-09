using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace manpass
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
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
    }
}
