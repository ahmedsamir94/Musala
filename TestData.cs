using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MusalaFrameWork
{
    public class TestData
    {
        public TestContext testcontext;
        public string SetMail(TestContext testcontext)
        {
            string Email = testcontext.DataRow["Email"].ToString();
            return Email;
        }        
        public string SetName(TestContext testcontext)
        {
            string Name = testcontext.DataRow["Name"].ToString();
            return Name;
        }        
        public string SetPhoneNumber(TestContext testcontext)
        {
            string MobileNumber = testcontext.DataRow["MobileNumber"].ToString();
            return MobileNumber;
        }        
        public string SetMessage(TestContext testcontext)
        {
            string Message = testcontext.DataRow["Message"].ToString();
            return Message;
        }       
        public string SetSubject(TestContext testcontext)
        {
            string Subject = testcontext.DataRow["Subject"].ToString();
            return Subject;
        }        

    }
}
