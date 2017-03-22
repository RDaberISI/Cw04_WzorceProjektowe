using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw0401
{
    //uczelnia "noramlnie"
    class Uczelnia
    {
        private string nazwa;
        private DateTime dataRekrutacji;

        public Uczelnia(string nazwa, DateTime data)
        {
            this.nazwa = nazwa;
            this.dataRekrutacji = data ;
        }

        public void RekrutujStudentow()
        {
            Console.WriteLine("Data nastepnej rekrutacji na uczelni {0} : {1}",this.nazwa, this.dataRekrutacji.ToString("dd MMMM yyyy"));
        }
    }

    //uczelnia singleton
    public sealed class UczelniaSingleton
    {
        private string nazwa;
        private DateTime dataRekrutacji;

        private static UczelniaSingleton _obiekt = null;
        private static readonly object _klodka = new object();

        private UczelniaSingleton() { }
        private UczelniaSingleton(string nazwa, DateTime data)
        {
            this.dataRekrutacji = data;
            this.nazwa = nazwa;
        }

        public static UczelniaSingleton UtworzObiekt(string nazwa, DateTime data)
        {
            {
                lock (_klodka)
                {
                    if (_obiekt == null)
                    {
                        _obiekt = new UczelniaSingleton(nazwa,data);
                    }
                    return _obiekt;
                }
            }
        }

        public void RekrutujStudentow()
        {
            Console.WriteLine("Data nastepnej rekrutacji na uczelni {0} : {1}", this.nazwa, this.dataRekrutacji.ToString("dd MMMM yyyy"));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Uczelnia uczelnia1 = new Uczelnia("UWM", DateTime.Today.AddDays(20));
            Uczelnia uczelnia2 = new Uczelnia("Stanford", DateTime.Today.AddDays(40));

            uczelnia1.RekrutujStudentow();
            uczelnia2.RekrutujStudentow();

            Console.WriteLine();

            UczelniaSingleton.UtworzObiekt("UWM", DateTime.Today.AddDays(300)).RekrutujStudentow();
            UczelniaSingleton.UtworzObiekt("Stanford", DateTime.Today.AddDays(500)).RekrutujStudentow();
            Console.ReadKey();
        }
    }
}
