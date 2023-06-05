// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System;
using Classes;

namespace Classes
{
    interface IAnimal
    {
        public void Speak();
    }
    class Animal: IAnimal
    {
        public string Name { get; set; }

        public void Speak()
        {
            Console.WriteLine("Speak");
        }
    }

    interface IDog: IAnimal { 
        public void Smell();
    }

    class Dog : Animal, IDog
    {
        public string Breed { get; set; }

        public void Smell()
        {
            Console.WriteLine("Sniff");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating an Animal instance with the Dog class
        Animal animalInstance = new Dog
        {
            Name = "Buddy",
            Breed = "Golden Retriever"
        };

        // Accessing properties using polymorphism with 'as' keyword
        Console.WriteLine(animalInstance.Name);

        // Accessing dog-specific properties using 'as' keyword
        IDog dogInstance = animalInstance as IDog;
        if (dogInstance != null)
        {
            //Console.WriteLine(dogInstance.);
            dogInstance.Smell();
        }
    }
}