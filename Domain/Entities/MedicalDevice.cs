using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DigitalHealth.Domain.Entities
{
    public class MedicalDevice : IEntity<Guid>
    {
        public Guid Id { get;init; }
        public string ModelName { get; private set; } = null!;
        public string JsonContract { get; private set; } = null!;
        
    }
}
