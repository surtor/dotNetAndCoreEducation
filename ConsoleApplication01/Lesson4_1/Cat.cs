using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4_1
{
    class Cat
    {
        string name;
        int year;
        double weight;

        public Cat(string name, int year, double weight)
        {
            this.name = name;
            this.year = year;
            this.weight = weight;
        }

        public void Eat(double food)
        {
            this.weight = this.weight + food;
            Console.WriteLine($"Cat {this.name} ate {food} Kg of Food!");
        }

        public void Eat(Mouse OneMouse)
        {
            this.weight = this.weight + OneMouse.GetWeight();
            Console.WriteLine($"Cat {this.name} ate {OneMouse.GetName()} with weighr {OneMouse.GetWeight()} Kg of Food!");
            OneMouse.Kill(this);
        }

        public void Print()
        {
            Console.Write($"Name: {this.name}, ");
            Console.Write($"Year: {this.year}, ");
            Console.WriteLine($"Weight: {this.weight}");
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
