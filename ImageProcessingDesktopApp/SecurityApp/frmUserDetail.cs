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
using WindowsFormsApp56.Classes;

namespace WindowsFormsApp56
{
    public partial class frmUserDetail : Form
    {
        User _user = null;
        List<Customer> customerList = new List<Customer>();
        public frmUserDetail(User user)
        {
            InitializeComponent();
            customerList = Customer.GetObjects();

            foreach (var item in customerList)
            {
                cmbCustomer.Items.Add(item.CustomerName);
            }
            _user = user;

            if (user!=null)
            {
                txtEmail.Text = _user.Email;
                txtFirstName.Text = _user.FirstName;
                txtLastName.Text = _user.LastName;
                txtPassword.Text = _user.Password;
                txtUsername.Text = _user.Username;
                cmbCustomer.Text = customerList.FirstOrDefault(x => x.CustomerId == _user.CustomerId).CustomerName;
            }

            if (!GlobalSetting.IsAdmin)
            {
                chkIsAdmin.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_user!=null)
            {
                _user.AlarmSettingId = 0;
                _user.CustomerId = customerList.FirstOrDefault(x => x.CustomerName == cmbCustomer.Text).CustomerId;
                //_user.CustomerId = GlobalSetting.CustomerId==null ? 0 :Convert.ToInt32(GlobalSetting.CustomerId);
                _user.Email = txtEmail.Text;
                _user.FirstName = txtFirstName.Text;
                _user.LastName = txtLastName.Text;
                _user.PanicSettingId = 0;
                _user.Password = txtPassword.Text;
                _user.Username = txtUsername.Text;


                if (!GlobalSetting.IsAdmin)
                    _user.IsAdmin = false;
                else
                    _user.IsAdmin = chkIsAdmin.Checked;

                _user.Update();
            }
            else
            {
                _user = new User();
                _user.AlarmSettingId = 0;
                _user.CustomerId = customerList.FirstOrDefault(x => x.CustomerName == cmbCustomer.Text).CustomerId;

                //_user.CustomerId = GlobalSetting.CustomerId == null ? 0 : Convert.ToInt32(GlobalSetting.CustomerId);
                _user.Email = txtEmail.Text;
                _user.FirstName = txtFirstName.Text;
                _user.LastName = txtLastName.Text;
                _user.PanicSettingId = 0;
                _user.Password = txtPassword.Text;
                _user.Username = txtUsername.Text;


                if (!GlobalSetting.IsAdmin)
                    _user.IsAdmin = false;
                else
                    _user.IsAdmin = chkIsAdmin.Checked;

                _user.Insert();

            }

            XtraMessageBox.Show("İşleminiz başarıyla gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
