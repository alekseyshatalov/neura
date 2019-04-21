using NeuraCore.Elements.Interfaces;
using System;

namespace NeuraCore.Elements
{

    public class Connection
    {

        IConnactable from;
        IConnactable to;
        public float weight;

        public Connection(IConnactable from, IConnactable to, float weight)
        {
            this.from = from;
            this.to = to;
            this.weight = weight;
        }

        public void Deliver(float signal) => to.Recieve(signal * weight);

    }

}