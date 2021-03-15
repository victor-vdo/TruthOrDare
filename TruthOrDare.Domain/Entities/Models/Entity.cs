using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDare.Domain.Entities.Models
{
    public class Entity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
