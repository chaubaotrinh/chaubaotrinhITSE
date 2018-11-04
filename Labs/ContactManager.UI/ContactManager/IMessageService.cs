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
    public interface IMessageService
    {
        void Send( string emailAddress, string subject, string message );
    }
}
