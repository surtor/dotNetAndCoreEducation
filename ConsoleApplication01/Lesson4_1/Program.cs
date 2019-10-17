using System;

namespace Lesson4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat1 = new Cat("Tom", 5, 6);
            cat1.Print();
            cat1.Eat(1.5);
            cat1.Print();

            Mouse mouse1 = new Mouse("Jerry", 0.6);
            mouse1.Print();
            mouse1.Eat(0.4);
            mouse1.Print();

            cat1.Eat(mouse1);
            cat1.Print();
            mouse1.Print();


        }
    }
}

