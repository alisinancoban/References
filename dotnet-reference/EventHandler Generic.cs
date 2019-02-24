using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Workshop
{
    /*The Generic 'event delegate Type (available since .NET 2.0) that uses <T> where
	'T may be a Type that inherits from (whose base class is) EventArgs is used when
	you need to pass custom data from the context in which the Event is triggered to the
	"consumers" of the Event who create EventHandlers for the Event and add those 
	EventHandlers to the Invocation List of the Event.*/
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock("THPW");
            stock.Price = 27.10M;    // Register with the PriceChanged event    
            stock.PriceChanged += stock_PriceChanged;
            stock.Price = 31.59M;
        }
        static void stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
                Console.WriteLine("Alert, 10% stock price increase!");
        }

    }

    public class PriceChangedEventArgs : EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;
        public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
        {
            LastPrice = lastPrice; NewPrice = newPrice;
        }
    }

    public class Stock
    {
        string symbol; decimal price;
        public Stock(string symbol) { this.symbol = symbol; }
        public event EventHandler<PriceChangedEventArgs> PriceChanged;
        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        { PriceChanged?.Invoke(this, e);
        }
        public decimal Price
        {
            get { return price; }
            set { if (price == value) return;
                decimal oldPrice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price)); }
        }
    }

}