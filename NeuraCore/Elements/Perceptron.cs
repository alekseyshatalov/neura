using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeuraCore.Elements
{

    class Perceptron
    {
        private List<List<Neuron>> neurons = new List<List<Neuron>>();
        public List<Connection> connections = new List<Connection>();

        public Perceptron(List<int> layers)
        {
            foreach(int layerSize in layers)
            {
                List<Neuron> neurons = new List<Neuron>();
                for (int i = 0; i < layerSize; i++) neurons.Add(new Neuron());
                this.neurons.Add(neurons);
            }
            for(int i = 0; i < neurons.Count - 1; i++)
            {
                List<Neuron> currentLayer = neurons[i];
                List<Neuron> nextLayer = neurons[i + 1];
                for(int j = 0; j < currentLayer.Count; j++)
                {
                    for(int k = 0; k < nextLayer.Count; k++)
                    {
                        Connection connection = new Connection(currentLayer[j], nextLayer[k], 0.5f);
                        currentLayer[j].outputConnections.Add(connection);
                        nextLayer[k].inputConnections.Add(connection);
                        connections.Add(connection);
                    }
                }
            }
        }

        public List<float> Process(List<float> inputSignals)
        {
            for(int i = 0; i < inputSignals.Count; i++) neurons[0][i].Process(inputSignals[i]);
            bool completed = false;
            do
            {
                List<float> outputSignals = new List<float>();
                foreach(Neuron outputNeuron in neurons[neurons.Count - 1])
                {
                    if (outputNeuron.result != 0) outputSignals.Add(outputNeuron.result);
                    if (outputSignals.Count == neurons[neurons.Count - 1].Count)
                    {
                        completed = true;
                        return outputSignals;
                    }
                }
            }
            while (!completed);
            return null;
        }

        public override string ToString()
        {
            int neuronsCount = 0;
            string sheme = "{";
            foreach (List<Neuron> layer in neurons)
            {
                sheme += layer.Count.ToString() + ",";
                neuronsCount += layer.Count;
            }
            sheme = sheme.Remove(sheme.Length - 1);
            sheme += "}";
            return $"sheme: {sheme}\n" +
                $"total: {neuronsCount} neurons in {neurons.Count} layers and {connections.Count} connections";
        }

    }

}
