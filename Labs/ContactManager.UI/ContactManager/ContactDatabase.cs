/* 
 * Student: Chau Trinh
 * Class: ITSE 1430
 * Lab 3: Contact Manager
 * Date: 5 Nov 2018
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class ContactDatabase
    {
        private Contact[] _contact = new Contact[100];

        public void Add( Contact contact )
        {
            var index = FindNextFreeIndex();
            if (index >= 0)
                _contact[index] = contact;
        }

        private int FindNextFreeIndex()
        {
            for (var index = 0; index < _contact.Length; ++index)
            {
                if (_contact[index] == null)
                    return index;
            }

            return -1;
        }

        public Contact[] GetAll()
        {
            var count = 0;
            foreach (var contact in _contact)
            {
                if (contact != null)
                    ++count;
            }

            var temp = new Contact[count];

            var index = 0;
            foreach (var contact in _contact)
            {
                if (contact != null)
                    temp[index++] = contact;
            }

            return temp;
        }

        public void Edit( string name, Contact contact )
        {
            Remove(name);

            Add(contact);
        }

        public void Remove( string name )
        {
            for (var index = 0; index < _contact.Length; ++index)
            {
                if (String.Compare(name, _contact[index]?.Name, true) == 0)
                {
                    _contact[index] = null;
                    return;
                }
            }
        }
    }
}
