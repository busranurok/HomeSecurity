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
    public partial class frmCustomerDetail : Form
    {
        Customer _customer;

        public frmCustomerDetail(Customer customer)
        {
            InitializeComponent();
            _customer = customer;

            if (_customer!=null)
            {
                txtCustomerAddress.Text = _customer.CustomerHomeAddress;
                txtCustomerDescription.Text = _customer.CustomerDescription;
                txtCustomerName.Text = _customer.CustomerName;
                txtModelDirectory.Text = _customer.ModelDirectoryName;
                txtModelXmlName.Text = _customer.ModelXmlName;
                txtModelFolderName.Text = _customer.ModelFolderName;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_customer!=null)
            {
                _customer.CustomerDescription = txtCustomerDescription.Text;
                _customer.CustomerHomeAddress = txtCustomerAddress.Text;
                _customer.CustomerName = txtCustomerName.Text;
                _customer.ModelDirectoryName = txtModelDirectory.Text;
                _customer.ModelXmlName = txtModelXmlName.Text;
                _customer.ModelFolderName = txtModelFolderName.Text;

                _customer.Update();
            }
            else
            {
                _customer = new Customer();
                _customer.CustomerDescription = txtCustomerDescription.Text;
                _customer.CustomerHomeAddress = txtCustomerAddress.Text;
                _customer.CustomerName = txtCustomerName.Text;
                _customer.ModelDirectoryName = txtModelDirectory.Text;
                _customer.ModelXmlName = txtModelXmlName.Text;
                _customer.ModelFolderName = txtModelFolderName.Text;

                _customer.InsertDB();
            }

            XtraMessageBox.Show("İşleminiz başarıyla gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
