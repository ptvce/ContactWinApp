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
    public partial class Form1 : Form
    {
        IContactRepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        public void DataBind()
        {
            dgView.AutoGenerateColumns = false;
            dgView.DataSource = repository.SelectAll();
        }

        private void Add_Click(object sender, EventArgs e)
        {

        }
    }
}
