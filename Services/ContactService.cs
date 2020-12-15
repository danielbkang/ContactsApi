using ContactsApi.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Collections.Generic;

namespace ContactsApi.Services
{
    public class ContactService
    {
        private OracleConnection _connection = null;
        private string _tableName = null;

        public ContactService(IContactsDatabaseSettings settings)
        {
            _connection = new OracleConnection(settings.ConnectionString);
            _tableName = settings.TableName;
        }

        public List<Contact> GetAll()
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                string sql = "select * from " + _tableName;

                OracleCommand command = new OracleCommand(sql, _connection);
                command.CommandType = CommandType.Text;

                OracleDataReader dataReader = command.ExecuteReader();

                List<Contact> contacts = new List<Contact>();

                while (dataReader.Read())
                {
                    contacts.Add(new Contact()
                    {
                        Id = dataReader.GetInt32(0),
                        FirstName = dataReader.GetString(1),
                        LastName = dataReader.GetString(2),
                        Birth = dataReader.GetDateTime(3),
                        Email = dataReader.GetString(4),
                        Address = dataReader.GetString(5),
                        PhoneNumber = dataReader.GetString(6)
                    });
                }

                return contacts;
            }
            finally
            {
                _connection.Close();
            }
        }

        public Contact Get(long id)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                string sql = "select * from " + _tableName
                    + " where id = " + id;

                OracleCommand command = new OracleCommand(sql, _connection);
                command.CommandType = CommandType.Text;

                OracleDataReader dataReader = command.ExecuteReader();
                return dataReader.Read() ? new Contact()
                {
                    Id = dataReader.GetInt32(0),
                    FirstName = dataReader.GetString(1),
                    LastName = dataReader.GetString(2),
                    Birth = dataReader.GetDateTime(3),
                    Email = dataReader.GetString(4),
                    Address = dataReader.GetString(5),
                    PhoneNumber = dataReader.GetString(6)
                } : null;
            }
            finally
            {
                _connection.Close();
            }
        }

        public Contact Create(Contact contact)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                string sql = "INSERT INTO " + _tableName
                    + " values("
                    + contact.Id + ", "
                    + "'" + contact.FirstName + "',"
                    + "'" + contact.LastName + "',"
                    + "TO_DATE('" + contact.Birth.ToString("yyyy/MM/dd") + "','yyyy/mm/dd'),"
                    + "'" + contact.Email + "',"
                    + "'" + contact.Address + "',"
                    + "'" + contact.PhoneNumber + "')";
                OracleCommand command = new OracleCommand(sql, _connection);
                command.CommandType = CommandType.Text;

                command.ExecuteNonQuery();

                return contact;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}