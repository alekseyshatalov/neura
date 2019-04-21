using NeuraCore.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuraCore
{
    class Teacher
    {
        private float delta;

        public Teacher(float delta)
        {
            this.delta = delta;
        }

        public void Teach(Perceptron perceptron, List<float> inputSignals, List<float> outputSignals)
        {
            float startValue = perceptron.Process(inputSignals)[0];

            int connectionIndex = new Random().Next(0, perceptron.connections.Count);
            perceptron.connections[connectionIndex].weight += delta;
            float newValue = perceptron.Process(inputSignals)[0];

            if(Math.Abs(startValue - outputSignals[0]) < Math.Abs(newValue - outputSignals[0]))
            {
                perceptron.connections[connectionIndex].weight -= delta*2;
            }
        }

    }
}
