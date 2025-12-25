using System;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;
namespace MainConstructor
{
    public class Account
    {
        public int AccountID{get;set;}
        public string Name{get;set;}
        public string AccountDetails()
        {
          return $"I am base class with id {AccountID}";
        }
    }
    public class SalesAccount : Account
    {
        public string SalesInfo{get;set;}
        public string SalesDetails()
        {
            string infor=string.Empty;
            infor+=base.AccountDetails();
            infor+="I am from SalesDerived Class";
            return infor;

        }
        }
    public class PurchaseAccount : Account
    {
        public string PurachaseInfo{get;set;}
        public string PurchaseDetails(){
        string info=string.Empty;
        info+=base.AccountDetails();
        info+="I am purchasederived class";
        return info;

        }
        }

    }
