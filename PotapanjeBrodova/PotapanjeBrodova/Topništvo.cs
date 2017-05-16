using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PotapanjeBrodova
{
    public enum TaktikaGađanja
    {
        Nasumično,
        Kružno,
        Linijsko
    }

    public class Topništvo
    {

        public Topništvo(int redaka, int stupaca, IEnumerable<int> duljineBrodova)
        {

            mreža = new Mreža(redaka, stupaca);
            this.duljineBrodova = new List<int>(duljineBrodova);
            TaktikaGađanja = TaktikaGađanja.Nasumično;
            pucač = new SlučajniPucač(mreža,duljineBrodova.First());
        }

        public void ObradiGađanje(RezultatGađanja rezultat)
        {
            if (rezultat == RezultatGađanja.Promašaj)
                return;
            if(rezultat == RezultatGađanja.Pogodak)
            {
                switch(TaktikaGađanja)
                {

                    case TaktikaGađanja.Nasumično:
                        PromijeniTaktikuUKružnu();
                        return;
                    case TaktikaGađanja.Kružno:
                        PromijeniTaktikuULinijsku();
                        return;
                    case TaktikaGađanja.Linijsko:
                        return;
                    default:
                        Debug.Assert(false);
                        break;
                        
                }
            }

            Debug.Assert(rezultat == RezultatGađanja.Potopljen);
            PromijeniTaktikuUNasumično();

        }

       void PromijeniTaktikuUKružnu()
        {
            TaktikaGađanja = TaktikaGađanja.Kružno;

            Polje pogođeno = pucač.PogođenaPolja.First();
            pucač = new KružniPucač(mreža, pogođeno, duljineBrodova.First());
        }

        void PromijeniTaktikuULinijsku()
        {
            TaktikaGađanja = TaktikaGađanja.Linijsko;
            var pogođeno = pucač.PogođenaPolja;
            pucač = new LinijskiPucač(mreža, pogođeno, duljineBrodova.First());
        }

        void PromijeniTaktikuUNasumično()
        {
            TaktikaGađanja = TaktikaGađanja.Nasumično;
            pucač = new SlučajniPucač(mreža, duljineBrodova.First());
        }


        public TaktikaGađanja TaktikaGađanja { get; private set; }

        private Mreža mreža;
        private List<int> duljineBrodova;
        Ipucač pucač;
        
    }
}
