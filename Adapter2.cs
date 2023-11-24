using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Pattern
{

    // Target interface
    public interface IPrinter
    {
        void Print();
    }

    // Adaptee (existing class)
    public class LegacyPrinter
    {
        public void PrintUsingParallelPort()
        {
            Console.WriteLine("Printing using parallel port");
        }
    }

    // Adapter
    public class ModernComputerAdapter : IPrinter
    {
        private readonly LegacyPrinter legacyPrinter;

        public ModernComputerAdapter(LegacyPrinter legacyPrinter)
        {
            this.legacyPrinter = legacyPrinter;
        }

        public void Print()
        {
            legacyPrinter.PrintUsingParallelPort();
        }
    }

    // Client code
    class Program
    {
        static void Main()
        {
            LegacyPrinter legacyPrinter = new LegacyPrinter();
            IPrinter modernComputerAdapter = new ModernComputerAdapter(legacyPrinter);
            modernComputerAdapter.Print();

            Console.ReadLine();
        }
    }

}
