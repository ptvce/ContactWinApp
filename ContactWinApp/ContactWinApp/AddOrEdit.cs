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
        IEFContactRepository repository;
        public int contactID = 0;
        public AddOrEdit()
        {
            InitializeComponent();
            repository = new EFContactRepository();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                bool isSuccess = false;
                if (contactID == 0)
                {
                     isSuccess = repository.EFInsert(txtName.Text, txtFamily.Text, txtMobile.Text, txtEmail.Text, txtAge.Text, txtAddress.Text);
                    
                }
                else
                {
                     isSuccess = repository.EFUpdate(contactID,txtName.Text, txtFamily.Text, txtMobile.Text, txtEmail.Text,txtAge.Text, txtAddress.Text);

                }
                if (isSuccess)
                {
                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
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

        private void AddOrEdit_Load(object sender, EventArgs e)
        {
            if (contactID == 0)
                this.Text = "افزودن شخص جدید";
            else
            {
                this.Text = "ویرایش شخص جدید";

                MyContact c = repository.EFSelectRow(contactID);
                txtName.Text = c.Name.ToString();
                txtFamily.Text = c.Family.ToString();
                txtMobile.Text = c.Mobile.ToString();
                txtEmail.Text = c.Email.ToString();
                txtAge.Text = c.Age.ToString();
                txtAddress.Text = c.Address.ToString();
            }
        }
    }
}
