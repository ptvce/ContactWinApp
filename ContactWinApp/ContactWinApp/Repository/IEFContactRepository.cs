using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWinApp.Repository
{
    interface IEFContactRepository
    {
        List<MyContact> EFSelectAll();
        MyContact EFSelectRow(int contactId);
        bool EFInsert(string name, string family, string mobile, string email, string age, string address);
        bool EFUpdate(int contactId, string name, string family, string mobile, string email, string age, string address);
        bool EFDelete(int contactId);
    }
}
