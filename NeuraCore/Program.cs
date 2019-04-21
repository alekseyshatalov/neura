using NeuraCore.Elements;
using System;
using System.Collections.Generic;

namespace NeuraCore
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> layers = new List<int>() { 2, 2, 1 };
            Perceptron perceptron = new Perceptron(layers);
            Console.WriteLine(perceptron.ToString());
            

            Teacher teacher = new Teacher(0.001f);
            for(int i = 0; i < 100; i++)
            {
                Random random = new Random();
                float first = random.Next(10);
                float second = random.Next(10);
                float sum = first + second;
              
                for(int j = 0; j < 100; j++)
                {
                    teacher.Teach(perceptron, new List<float> { first, second }, new List<float> { sum });
                }
            }

            List<float> control = new List<float> { 1, 1 };
            Console.WriteLine(perceptron.Process(control)[0]);
            control = new List<float> { 2, 2 };
            Console.WriteLine(perceptron.Process(control)[0]);
            control = new List<float> { 3, 3 };
            Console.WriteLine(perceptron.Process(control)[0]);
            control = new List<float> { 5, 5 };
            Console.WriteLine(perceptron.Process(control)[0]);
            control = new List<float> { 7, 8 };
            Console.WriteLine(perceptron.Process(control)[0]);
        }

    }
}