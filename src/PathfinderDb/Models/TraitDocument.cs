using System;

namespace PathfinderDb.Models
{
    public sealed class TraitDocument
    {
        public string Id { get; set; }

        public string DocId
        {
            get { return "Trait/" + this.Id; }
        }

        public string Name { get; set; }
    }
}
