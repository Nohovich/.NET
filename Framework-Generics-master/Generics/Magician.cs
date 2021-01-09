using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Magician : INameable, IComparable<Magician>
    {
        public string Name { get; private set; }
        public string BirthTown { get; private set; }
        public string FavoriteSpell { get; private set; }

        // index string
        public string this[string fieldName]
        {
            get
            {
                switch (fieldName)
                {
                    case "Name":
                        return this.Name;
                    case "BirthTown":
                        return this.BirthTown;
                    case "FavoriteSpell":
                        return this.FavoriteSpell;
                }
                return null;
            }
            set
            {
                switch (fieldName)
                {
                    case "Name":
                        this.Name = value;
                        break;
                    case "BirthTown":
                        this.BirthTown = value;
                        break;
                    case "FavoriteSpell":
                        this.FavoriteSpell = value;
                        break;
                }
            }
        }
        public Magician(string favoriteSpella, string birthTown, string name)
        {
            this.BirthTown = favoriteSpella;
            this.FavoriteSpell = birthTown;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"Magician Name: {Name} BirthTown: {BirthTown} Title: {FavoriteSpell}";
        }

        int IComparable<Magician>.CompareTo(Magician other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
    class Knight : INameable, IComparable<Knight>
    {
        public string Name { get; private set; }
        public string BirthTown { get; private set; }
        public string Title { get; private set; }

        public string this[string fieldName]
        {
            get
            {
                switch (fieldName)
                {
                    case "Name":
                        return this.Name;
                    case "BirthTown":
                        return this.BirthTown;
                    case "Title":
                        return this.Title;
                }
                return null;
            }
            set
            {
                switch (fieldName)
                {
                    case "Name":
                        this.Name = value;
                        break;
                    case "BirthTown":
                        this.BirthTown = value;
                        break;
                    case "Title":
                        this.Title = value;
                        break;
                }
            }
        }
        public Knight(string name, string birthTown, string title)
        {
            this.Name = name;
            this.Title = title;
            this.BirthTown = birthTown;
        }
        public override string ToString()
        {
            return $"Knight Name: {Name} BirthTown: {BirthTown} Title: {Title}";
        }

        int IComparable<Knight>.CompareTo(Knight other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
