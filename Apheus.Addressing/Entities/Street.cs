using MongoDB.Entities;

namespace Apheus.Addressing.Entities
{
    public class Street : Entity
    {
        public string Name { get; set; }

        public One<City> City { get; set; }
    }
}