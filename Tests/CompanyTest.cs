using Microsoft.VisualStudio.TestTools.UnitTesting;
//[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.ClassLevel)]

namespace MusalaFrameWork
{

    [TestClass]
    public class CompanyTest : BaseTest
    {
        
        [TestMethod]
        [Description("SignIn to the QA")]

        public void A002_Test()
        {
            Home.GoTo();
            Home.ClickCompany();
            company.VerifyLeaderShipVisibility();
            company.CLickFacebook();
        }
    }
}
