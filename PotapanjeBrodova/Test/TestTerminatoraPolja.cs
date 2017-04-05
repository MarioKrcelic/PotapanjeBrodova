using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Linq;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class TestTerminatoraPolja
    {
        private Mreža mreža;
        private TerminatoraPolja terminator;

        [TestInitialize()]
        public void PripremiMrežuTerminatora()
        {
            mreža = new Mreža(10,10);
            terminator = new TerminatoraPolja(mreža);
        }

        [TestMethod]
        public void TestTerminatorPolja_UklanjaSvaPoljaOkoBrodaUSrediniMreže()
        {
            IEnumerable<Polje> polja = new Polje[] { new Polje(3, 3), new Polje(3, 4) };
            terminator.UkloniPolja(polja);
            Assert.AreEqual(88,mreža.DajSlobodnaPolja().Count());

            //Dodaj provjeru da su izbačeni (3,3) i (3,4), (2,2), (2,5), (4,2), (4,5)
        }

        [TestMethod]
        public void TestTerminatorPolja_UklanjaSvaPoljaOkoBrodaUzGornjiRubMreže()
        {
        }

        [TestMethod]
        public void TestTerminatorPolja_UklanjaSvaPoljaOkoBrodaUGornjemDesnomKutuMreže()
        {
        }
        [TestMethod]
        public void TestTerminatorPolja_UklanjaSvaPoljaOkoBrodaUGornjemDLijevomKutuMreže()
        {
        }

        [TestMethod]
        public void TestTerminatorPolja_UklanjaSvaPoljaOkoBrodaUGDonjemDesnomKutuMreže()
        {
        }

        [TestMethod]
        public void TestTerminatorPolja_UklanjaSvaPoljaOkoBrodaUGDonjemLijevomKutuMreže()
        {
        }
    }
}
