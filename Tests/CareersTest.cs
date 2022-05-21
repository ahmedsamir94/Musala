using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MusalaFrameWork
{

    [TestClass]
    public class CareersTest : BaseTest
    {
        
        [TestMethod]
        [Description("SignIn to the QA")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Employees.xml", "Applier", DataAccessMethod.Sequential)]



        public void A003_Test()
        {
            Home.GoTo();
            Home.ClickCareers();
            careers.CLickOpenPosistions();
            careers.SelectLocation();
            careers.selectVacancy();
            careers.CheckVisibiltyOfJobSections();
            careers.CheckVisibiltyOfApplyButton();
            careers.ClickApplyButton();
            careers.FillApplyForm(tests.SetName(TestContext), tests.SetMail(TestContext), tests.SetPhoneNumber(TestContext));

        }
    }
}
