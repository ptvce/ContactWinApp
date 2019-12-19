using ContactWinApp.Repository;
using ContactWinApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactWinApp
{
    public partial class AddOrEdit : Form
    {
        IContactRepository repository;
        public AddOrEdit()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
               bool isSuccess = repository.Insert(txtName.Text, txtFamily.Text, txtMobile.Text, txtEmail.Text, txtAddress.Text, txtAddress.Text);
                if (isSuccess)
                {
                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else {
                    MessageBox.Show("عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
        }

        bool ValidateInput()
        {
            if (txtName.Text == "") {
                MessageBox.Show("نام را وارد کنید","خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            if (txtFamily.Text == "")
            {
                MessageBox.Show("نام خانوادگی را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("موبایل را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("ایمیل را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtAge.Text == "")
            {
                MessageBox.Show("سن را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("آدرس را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            return true;
        }
    }
}
