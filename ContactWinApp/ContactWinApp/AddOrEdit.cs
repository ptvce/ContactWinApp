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
            repository.Insert(txtName.Text, txtFamily.Text, txtMobile.Text, txtEmail.Text, txtAddress.Text, txtAddress.Text);
        }
    }
}
