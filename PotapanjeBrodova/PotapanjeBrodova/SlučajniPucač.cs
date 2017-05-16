    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PotapanjeBrodova
{
    public class SlučajniPucač : Ipucač
    {
        public SlučajniPucač(Mreža mreža, int duljinaBroda)
        {
            this.mreža = mreža;
            this.duljinaBroda = duljinaBroda;

        }

        public Polje Gađaj()
        {
            var kandidati = DajKandidate();
            Debug.Assert(kandidati.Count > 0);
            gađanoPolje = kandidati[izbornik.Next(kandidati.Count)];
            return gađanoPolje;
        }

        public void ObradiGađanje(RezultatGađanja rezultat)
        {
            
        }

        private List<Polje> DajKandidate()
        {
            return mreža.DajNizoveSlobodnihPolja(duljinaBroda).SelectMany(niz => niz).ToList();
        }

        private Mreža mreža;
        private int duljinaBroda;
        private Polje gađanoPolje;
        private Random izbornik = new Random();

        public IEnumerable<Polje> PogođenaPolja
        {
            get
            {
                return new Polje[] { gađanoPolje };
            }
        }
    }
}
