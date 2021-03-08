using MongoDB.Entities;

namespace Apheus.Addressing.Entities
{
    public enum UnitType
    {
        Apt,
        Unit,
        Ste,
        Bldg
    }
    public class Address : Entity
    {
        public string Alias { get; set; }

        public int Number { get; set; }

        public UnitType UnitType { get; set; }

        public string Unit { get; set; }

        public One<Street> Street { get; set; }
    }
}