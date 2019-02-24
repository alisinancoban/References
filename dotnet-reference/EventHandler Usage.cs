using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Workshop
{
    //delegate void StokAzKaldiEventHandler();
    class Program
    {
        static void Main(string[] args)
        {
            Urun sakiz = new Urun(1001, "Falim", 1.20, 35);
            sakiz.StokAzaldi += sakiz_StokAzaldi;

            for (int i = 0; i < 5; i++)
            {
                sakiz.StokMiktari -= 7;
                Thread.Sleep(500);
                Console.WriteLine(sakiz.Ad + "icin stok miktari" + sakiz.StokMiktari.ToString());

            }
        }

        static void sakiz_StokAzaldi(object sender, StokAzaldiEventArgs e)
        {
            Console.WriteLine("Stok miktarý 10 deðerinin altýnda...Alarrrmmm!");
        }
    }

    public class StokAzaldiEventArgs : EventArgs
    {
        public readonly int StokMiktari;
        public StokAzaldiEventArgs(int stokMiktari)
        {
            StokMiktari = stokMiktari;
        }
    }


    class Urun
    {
        public int Id { get; private set; }
        public string Ad { get; private set; }
        public double BirimFiyati { get; private set; }
        private int stokMiktari;
        public event EventHandler<StokAzaldiEventArgs> StokAzaldi;

        protected virtual void StokDegisince(StokAzaldiEventArgs e)
        {
            StokAzaldi?.Invoke(this, e);
        }

        public int StokMiktari
        {
            get { return stokMiktari; }
            set
            {
                stokMiktari = value;
                if (value < 10 && StokAzaldi != null)
                {
                    StokDegisince(new StokAzaldiEventArgs(stokMiktari));
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

