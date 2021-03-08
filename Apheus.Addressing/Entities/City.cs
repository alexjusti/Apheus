using MongoDB.Entities;

namespace Apheus.Addressing.Entities
{
    public class City : Entity
    {
        public string Name { get; set; }

        public int ZipCode { get; set; }

        public One<State> State { get; set; }
    }
}