using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Tests
{
    [TestClass()]
    public class Geometry2DTests
    {
        Geometry2D geometry = new Geometry2D();
        double[] X ={ 0, 0,6, 6 };
        double[] Y ={ 0, 6,6, 0 };
        //ініціалізація двомірних масивів
        [TestMethod()]
        public void FindTiangleAreaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FindPolygonAreaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AreaTest()
        {
            ITask t = geometry;
            double r = geometry.Area(X, Y);
            Assert.AreEqual(36, Math.Round(r));
        }
    }
}