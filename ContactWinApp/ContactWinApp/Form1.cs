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
        IEFContactRepository repository;
        
        public Form1()
        {
            InitializeComponent();
            repository = new EFContactRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        public void DataBind()
        {
            dgView.AutoGenerateColumns = false;
            // dgView.DataSource = repository.SelectAll();
            dgView.DataSource = repository.EFSelectAll();

        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddOrEdit frm = new AddOrEdit();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
                DataBind();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            DataBind();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dgView.CurrentRow != null)
            {
                int contactID = Convert.ToInt32(dgView.CurrentRow.Cells[0].Value);
                string name = dgView.CurrentRow.Cells[1].Value.ToString();
                string family = dgView.CurrentRow.Cells[2].Value.ToString();
                string fullName = name + " " + family;
                if (MessageBox.Show($"آیا از حذف {fullName} مورد نظر مطمئن هستید؟","اطلاعات",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool isSuccess = repository.EFDelete(contactID);
                    if (isSuccess)
                    {
                        MessageBox.Show("آیتم مورد نظر با موفقیت حذف شد","موفقیت",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        DataBind();
                    }
                    else
                        MessageBox.Show("آیتم مورد نظرحذف نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (dgView.CurrentRow != null)
            {
                int contactID = Convert.ToInt32(dgView.CurrentRow.Cells[0].Value);
                AddOrEdit frm = new AddOrEdit();
                frm.contactID = contactID;
                if (frm.ShowDialog() == DialogResult.OK)
                    DataBind();

            }
        }
    }
}
