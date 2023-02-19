using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp56.Classes;

namespace WindowsFormsApp56
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
            gridControl1.DataSource = Customer.GetObjects();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmCustomerDetail frm = new frmCustomerDetail(null);
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0 || gridView1.SelectedRowsCount > 1)
            {
                XtraMessageBox.Show("Düzenlemek istediğiniz satırı tek satır olacak şekilde seçin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int[] selectedRowIndexes = gridView1.GetSelectedRows();
            Customer customer = gridView1.GetRow(selectedRowIndexes[0]) as Customer;
            frmCustomerDetail frm = new frmCustomerDetail(customer);
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
                Customer customer = gridView1.GetRow(selectedRowIndexes[0]) as Customer;
                customer.Delete();
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = Customer.GetObjects();
            gridControl1.Refresh();
        }
    }
}
