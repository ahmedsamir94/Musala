using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MusalaFrameWork
{
    [TestClass]
    public class ContactUsTest : BaseTest
    {

        [TestMethod]
        [Description("Validate that user is able to fill out the form successfully")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Employees.xml", "Employee", DataAccessMethod.Sequential)]
        public void A001_Test()
        {
            Home.GoTo();
            Home.ClickContactUs();
            contactUs.FillContactUs(tests.SetName(TestContext), tests.SetMail(TestContext), tests.SetPhoneNumber(TestContext), tests.SetSubject(TestContext), tests.SetMessage(TestContext));

        }




    }
}
