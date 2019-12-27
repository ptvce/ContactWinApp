using ContactWinApp.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWinApp.Service
{
    class EFContactRepository : IEFContactRepository
    {
        Contact_DBEntities db = new Contact_DBEntities();
        public bool EFDelete(int contactId)
        {
            MyContact p = new MyContact();
            p = EFSelectRow(contactId);
            db.MyContacts.Remove(p);

            var res = db.SaveChanges();
            if (res == 1) return true;
            else return false;
        }

        public bool EFInsert(string name, string family, string mobile, string email, string age, string address)
        {
            MyContact p = new MyContact
            {
                Name = name,
                Family = family,
                Mobile = mobile,
                Email = email,
                Age = Convert.ToInt32(age),
                Address = address
            };
            db.MyContacts.Add(p);

            var res = db.SaveChanges();
            if (res == 1) return true;
            else return false;
        }

        public List<MyContact> EFSelectAll()
        {
           return db.MyContacts.ToList();
        }

        public MyContact EFSelectRow(int contactId)
        {
            return db.MyContacts.Single(p => p.ContactID == contactId);
        }

        public bool EFUpdate(int contactId, string name, string family, string mobile, string email, string age, string address)
        {
            MyContact p = new MyContact();
            p = EFSelectRow(contactId);
            p.Name = name.ToString();
            p.Family = family.ToString();
            p.Mobile = mobile.ToString();
            p.Email = email.ToString();
            p.Age = Convert.ToInt32(age);
            p.Address = address.ToString();

            var res = db.SaveChanges();
            if (res == 1) return true;
            else return false;
        }
    }
}
