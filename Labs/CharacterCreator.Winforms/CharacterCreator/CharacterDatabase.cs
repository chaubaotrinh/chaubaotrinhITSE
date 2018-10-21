using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class CharacterDatabase
    {
        private Character[] _character = new Character[100];

        public void Add( Character character )
        {
            var index = FindNextFreeIndex();
            if (index >= 0)
                _character[index] = character;
        }

        private int FindNextFreeIndex()
        {
            for (var index = 0; index < _character.Length; ++index)
            {
                if (_character[index] == null)
                    return index;
            }

            return -1;
        }

        public Character[] GetAll()
        {
            var count = 0;
            foreach (var character in _character)
            {
                if (character != null)
                    ++count;
            }

            var temp = new Character[count];

            var index = 0;
            foreach (var character in _character)
            {
                if (character != null)
                    temp[index++] = character;
            }

            return temp;
        }

        public void Edit( string name, Character character )
        {
            Remove(name);

            Add(character);
        }

        public void Remove( string name )
        {
            for (var index = 0; index < _character.Length; ++index)
            {
                if (String.Compare(name, _character[index]?.Name, true) == 0)
                {
                    _character[index] = null;
                    return;
                }
            }
        }
    }
}
