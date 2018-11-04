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
    public class Message
    {
        public string EmailAddress
        {
            get { return _emailAddress ?? ""; }
            set { _emailAddress = value; }
        }
        private string _emailAddress = "";

        public string Subject
        {
            get { return _subject ?? ""; }
            set { _subject = value; }
        }
        private string _subject = "";

        public string MessageContent
        {
            get { return _messageContent ?? ""; }
            set { _messageContent = value; }
        }
        private string _messageContent = "";

        public string MessageDetail
        {
            get { return EmailAddress + "  " + Subject + "  " + MessageContent; }
        }
    }
}
