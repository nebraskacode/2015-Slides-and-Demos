using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MovieFanatic.Domain.Model
{
    public class Actor : EntityBase
    {
        public Actor(string name)
            : this()
        {
            Name = name;
        }
        private Actor()
        {
            Characters = new Collection<Character>();
        }

        public string Name { get; private set; }

        public virtual ICollection<Character> Characters { get; protected set; }
    }
}