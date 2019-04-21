using NeuraCore.Elements.Interfaces;
using System;
using System.Collections.Generic;

namespace NeuraCore.Elements
{
    class Neuron : IConnactable
    {
        private List<float> recievedSignals = new List<float>();
        public List<Connection> inputConnections = new List<Connection>();
        public List<Connection> outputConnections = new List<Connection>();
        public float result = 0;

        private float ProcessFunction(List<float> signals)
        {
            float result = 0;
            foreach (float signal in signals) result += signal;
            return result;
        }

        public void Process(float signal)
        {
            foreach (Connection connection in outputConnections) connection.Deliver(signal);
        }

        public void Process()
        {
            if (outputConnections.Count != 0)
            {
                foreach (Connection connection in outputConnections) connection.Deliver(ProcessFunction(recievedSignals));
                recievedSignals.Clear();
            }
            else
            { 
                result = ProcessFunction(recievedSignals);
                recievedSignals.Clear();
            }
        }

        public void Recieve(float signal)
        {
            recievedSignals.Add(signal);
            if (recievedSignals.Count == inputConnections.Count) Process();
        }
    }
}