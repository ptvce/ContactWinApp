using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWinApp.Repository
{
    interface IContactRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int contactId);
        bool Insert(string name, string family, string mobile, string email, string age, string address);
        bool Update(int contactId, string name, string family, string mobile, string email, string age, string address);
        bool Delete(int contactId);
    }
}
