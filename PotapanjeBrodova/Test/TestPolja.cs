using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapljanjeBrodova;

namespace Test
{
    [TestClass]
    public class TestPolja
    {
        [TestMethod]
        public void Polje_RedakIStupacJednakiSuArgumentimaKonstruktora()
        {
            Polje p = new Polje(2, 3);
            Assert.AreEqual(2, p.Redak);
            Assert.AreEqual(3, p.Stupac);
        }

        [TestMethod]
        public void Polje_ZaDvaPoljaKojaImajuIsteKoordinateMetodaEqualsVracaTrue()
        {
            Polje p1 = new Polje(2, 3);
            Polje p2 = new Polje(2, 3);
            Assert.AreEqual(2, p2.Redak);
            Assert.AreEqual(3, p2.Stupac);

        }
    }
}
