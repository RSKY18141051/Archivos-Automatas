using System;
using System.IO;

namespace Archivos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (Lexico0 l = new Lexico0())
                {
                    //l.Display();
                    //l.Load();
                    //l.Encrypt();
                    //l.Palabra();
                    //l.Display2();
                    //l.Encrypt2();
                    l.Mosca('a');
                    /*
                    while (!l.FinArchivo())
                    {
                        l.Token();
                    }
                    */
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
