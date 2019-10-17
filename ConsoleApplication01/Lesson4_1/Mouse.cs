using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4_1
{
    class Mouse
    {
        string name;
        double weight;
        bool alive;
        Cat killer;

        public Mouse(string name, double weight)
        {
            this.name = name;
            this.weight = weight;
            this.alive = true;
        }

        public void Eat(double food)
        {
            this.weight = this.weight + food;
            Console.WriteLine($"Mouse {this.name} ate {food} Kg of Food!");
        }

        public void Print()
        {
            if (alive)
            {
                Console.Write($"Name: {this.name}, ");
                Console.WriteLine($"Weight: {this.weight}");
            }
            else
            {
                Console.WriteLine($"{this.name} mouse is DEAD!");
                Console.WriteLine($"Ate by {this.killer.GetName()}");
            }

        }

        public void Kill(Cat KillerCat)
        {
            this.alive = false;
            this.killer = KillerCat;
        }

        public string GetName()
        {
            return this.name;
        }

        public double GetWeight()
        {
            return this.weight;
        }
    }
}
