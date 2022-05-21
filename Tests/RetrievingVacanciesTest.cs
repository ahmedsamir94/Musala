using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MusalaFrameWork
{

    [TestClass]
    public class RetrievingVacanciesTest : BaseTest
    {
        
        [TestMethod]
        [Description("SignIn to the QA")]


        public void A004_Test()
        {
            Home.GoTo();
            Home.ClickCareers();
            careers.CLickOpenPosistions();
            vacancy.SelectSofiaLocation();
            vacancy.PrintVacancies();
            vacancy.SelectSkopjeLocation();
            vacancy.PrintVacancies();

        }
    }
}
