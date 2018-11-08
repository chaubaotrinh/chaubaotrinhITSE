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
    public class Contact
    {
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }
        private string _name = "";

        public string EmailAddress
        {
            get { return _emailAddress ?? ""; }
            set { _emailAddress = value; }
        }
        private string _emailAddress = "";
    }
}
