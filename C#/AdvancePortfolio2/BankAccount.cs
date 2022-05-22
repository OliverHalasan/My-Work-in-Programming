using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancePortfolio2
{
    class BankAccount
    {
        private int _accountID = 0;
        private double _balance = 0;
        private double _annualInterestRate = 0;
        private DateTime _dateCreated;
        private char _type;

        public BankAccount(int accountID, double balance, double annualInterestRate, DateTime dateCreated)
        {
            _accountID = accountID;
            _balance = balance;
            _annualInterestRate = annualInterestRate;
            _dateCreated = dateCreated;
        }

        public char GetType()
        {
            return _type;
        }

        public int GetAccountID()
        {
            return _accountID;
        }
        public double GetBalance()
        {
            return _balance;
        }
        public double GetAnnualInterestRate()
        {
            return _annualInterestRate;
        }

        public DateTime GetDate()
        {
            return _dateCreated;
        }

        public void SetAccountID(int accountID)
        {
            _accountID = accountID;
        }
        public void SetBalance(double balance)
        {
            _balance = balance;
        }
        public void SetAnnualInterestRate(double annualInterestRate)
        {
            _annualInterestRate = annualInterestRate;
        }

        public void SetDate (DateTime dateCreated)
        {
            _dateCreated = dateCreated;
        }

    }
}
