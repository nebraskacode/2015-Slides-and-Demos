namespace MovieFanatic.Domain.Model
{
    public class Character : EntityBase
    {
        public Character(string name, Movie movie, Actor actor)
            : this()
        {
            Name = name;
            Movie = movie;
            Actor = actor;
        }
        private Character() { }

        public string Name { get; private set; }

        public virtual Movie Movie { get; protected set; }
        public virtual Actor Actor { get; protected set; }
    }
}