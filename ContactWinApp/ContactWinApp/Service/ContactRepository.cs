using ContactWinApp.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWinApp.Service
{
    class ContactRepository : IContactRepository
    {
        private string connectionString = "DataSource=.;Initial Catalog=Contact_DB;Integrated Security=true";
        public bool Delete(int contactId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "delete from MyContacts Where ContactID=@ContactID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ContactID", contactId);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Insert(string name, string family, string mobile, string email, string age, string address)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "insert into MyContacts (Name,Family,Mobile,Email,Age,Address) values (@Name,@Family,@Mobile,@Email,@Age,@Address)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Address", address);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
           
        }

        public DataTable SelectAll()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from MyContacts";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public DataTable SelectRow(int contactId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from MyContacts where contactId =" + contactId;
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public bool Update(int contactId, string name, string family, string mobile, string email, string age, string address)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Update MyContacts Set Name=@Name,Family=@Family,Mobile=@Mobile,Email=@Email,Age=@Age,Address=@Address Where ContactID=@ContactID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@ContactID", contactId);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
