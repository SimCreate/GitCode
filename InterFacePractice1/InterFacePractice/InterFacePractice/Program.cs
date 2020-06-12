using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFacePractice
{
    // You cannot use any access modifier for any member of an interface.
    // All the members by defaults are public members.
    // Interface can only contain declaration but not implementations.

    interface IPen
    {
        bool Open(); 
        bool Close();
        void Write(string text);

    }

    class Pen : IPen
    {
        private string PenColor;

        private bool isOpen = false;

        public Pen (string pColor)
        {
            PenColor = pColor;
        }

        bool IPen.Open()
        {
            isOpen = true;
            return isOpen;
        }

        bool IPen.Close()
        {
            isOpen = false;
            return isOpen;
        }

        void IPen.Write(string pText)
        {
            if (isOpen)
            {
                Console.WriteLine(pText);
            }
            else
            {
                Console.WriteLine(PenColor + "펜을 열어주세요.");
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            IPen pen = new Pen("빨간색");
            pen.Open();
            pen.Write("test");
            pen.Close();
            pen.Write("test");
            
            Console.ReadKey();
        }
    }
}
