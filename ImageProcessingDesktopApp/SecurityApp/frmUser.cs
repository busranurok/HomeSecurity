using DevExpress.XtraEditors;
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

namespace WindowsFormsApp56
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
            FillUsers();
        }

        private void FillUsers()
        {
            List<User> UserList = User.GetObjects();

            if (GlobalSetting.IsAdmin)
                gridControl1.DataSource = UserList;
            else
                gridControl1.DataSource = UserList.Where(x => x.CustomerId == GlobalSetting.CustomerId).ToList();

            gridControl1.Refresh();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmUserDetail frm = new frmUserDetail(null);
            frm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0 || gridView1.SelectedRowsCount > 1)
            {
                XtraMessageBox.Show("Düzenlemek istediğiniz satırı tek satır olacak şekilde seçin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int[] selectedRowIndexes = gridView1.GetSelectedRows();
            User user = gridView1.GetRow(selectedRowIndexes[0]) as User;
            frmUserDetail frm = new frmUserDetail(user);
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                XtraMessageBox.Show("Silmek istediğiniz satırları seçin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int[] selectedRowIndexes = gridView1.GetSelectedRows();
            foreach (var item in selectedRowIndexes)
            {
                User user = gridView1.GetRow(selectedRowIndexes[0]) as User;
                user.Delete();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillUsers();
        }
    }
}
