﻿using MongoDB.Entities;

namespace Apheus.Addressing.Entities
{
    public class State : Entity
    {
        public string Name { get; set; }

        public string Abbreviation { get; set; }
    }
}