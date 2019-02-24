using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Workshop
{

    class Program
    {
        static void Main(string[] args)
        {
            Urun sakiz = new Urun(1001, "Falim", 1.20, 35);
            sakiz.StokAzaldi += new StokAzKaldiEventHandler(sakiz_StokAzaldi);

            for (int i = 0; i < 5; i++)
            {
                sakiz.StokMiktari -= 7;
                Thread.Sleep(500);
                Console.WriteLine(sakiz.Ad + "icin stok" + sakiz.StokMiktari.ToString());
            }
        }

        static void sakiz_StokAzaldi()
        {
            Console.WriteLine("Stok miktarý 10 deðerinin altýnda...Alarrrmmm!");
        }
    }

    delegate void StokAzKaldiEventHandler();

    class Urun
    {
        public int Id { get; private set; }
        public string Ad { get; private set; }
        public double BirimFiyati { get; private set; }
        private int stokMiktari;

        public event StokAzKaldiEventHandler StokAzaldi;

        public int StokMiktari
        {
            get { return stokMiktari; }
            set
            {
                stokMiktari = value;
                if (value < 10 && StokAzaldi != null)
                {
                    StokAzaldi();
                }
            }
        }

        public Urun(int id, string ad, double birimfiyati, int stokMiktari)
        {
            Id = id;
            Ad = ad;
            BirimFiyati = birimfiyati;
            StokMiktari = stokMiktari;
        }
    }

}

