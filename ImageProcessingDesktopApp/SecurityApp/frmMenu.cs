using GuvenlikDesktop.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp56;

namespace GuvenlikDesktop
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            if (GlobalSetting.IsAdmin)
            {
                grpCustomer.Visible = true;
                grpUser.Visible = true;
            }
            else
            {
                grpCustomer.Visible = false;
                grpUser.Visible = false;
            }
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            frmTrain frm = new frmTrain();
            frm.ShowDialog();
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            OVCameraSaveImage frm = new OVCameraSaveImage();
            frm.ShowDialog();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.ShowDialog();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmUser frm = new frmUser();
            frm.ShowDialog();
        }
    }
}
