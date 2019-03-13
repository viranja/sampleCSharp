using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggerTesting
{
    public interface IDBAction
    {
        void Save();
        void Update();
        void Delete(int ID);
        void Delete(string Code);

    }
    public interface IDbService
    {
        void BeginTran();
        void Commit();
        void RolleBack();
        void StarConnection();
        void Dispose();
         


    }
    public interface IDataService : IDbService
    {
        void ExcuteNonQuery(string query,object connection);
        void SelectDataSet(string query,object connection);
    }

    public class Customer:IDBAction
    {
        private int customerCode;
        private string customerFirstName;
        private string customerLastName;
        IDataService _dataservce;

        public Customer()
        {

        }

        public Customer(IDataService dataService)
        {
            this._dataservce = dataService;
        }
        public void Save()
        {
            string query = "insert into table(code,name) values (@code,@name)";
            _dataservce.ExcuteNonQuery("insert recored", new object());
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public void Delete(string Code)
        {
            throw new NotImplementedException();
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual void Validate()
        {
            if (string.IsNullOrEmpty(Username))
            {
                throw new Exception("Username can't be blank");
            }

            if (string.IsNullOrEmpty(Password))
            {
                throw new Exception("Password can't be blank");
            }
        }

    }

    public class SupperUser : User
    {
        public override void Validate()
        {
            if (string.IsNullOrEmpty(Password))
            {
                throw new Exception("Password can't be blank");
            }
        }
    }
}
