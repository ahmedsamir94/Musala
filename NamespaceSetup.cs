using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MusalaFrameWork
{
    [TestClass]
    public static class NamespaceSetup
    {
        [AssemblyInitialize]
        public static void ExecuteForCreatingReportsNamespace(TestContext testContext)
        {
            Reporter.StartReporter();
        }
    }
}
