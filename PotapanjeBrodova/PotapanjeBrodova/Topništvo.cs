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
            if (rezultat == RezultatGađanja.Promašaj) return;

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
        }

        void PromijeniTaktikuULinijsku()
        {
            TaktikaGađanja = TaktikaGađanja.Linijsko;
        }

        void PromijeniTaktikuUNasumično()
        {
            TaktikaGađanja = TaktikaGađanja.Nasumično;
        }


        public TaktikaGađanja TaktikaGađanja { get; private set; }

        private Mreža mreža;
        private List<int> duljineBrodova;
        Ipucač pucač;
        
    }
}
