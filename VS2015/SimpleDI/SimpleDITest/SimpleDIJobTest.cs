using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleDIBusinessLogic;
using SimpleLog;
using StructureMap;

namespace SimpleDITest
{
    [TestClass]
    public class SimpleDIJobTest
    {
        [TestMethod]
        public void TestImportant()
        {
            var container = new Container(_ =>
            {
                _.For<ILog>().Use<NullLogger>();

            });
            var d = new DoImportantJob(container);
            d.ImportantJob();
        }
    }
}
