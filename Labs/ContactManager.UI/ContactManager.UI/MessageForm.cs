/* 
 * Student: Chau Trinh
 * Class: ITSE 1430
 * Lab 3: Contact Manager
 * Date: 5 Nov 2018
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager.UI
{
    public partial class MessageForm : Form
    {
        Contact receiver;
        public MessageForm(Contact item )
        {
            InitializeComponent();
            receiver = item;
        }

        public Message Message { get; set; }

        private void OnSend( object sender, EventArgs e )
        {
            var message = new Message();
            message.EmailAddress = _txtEmailAddress.Text;
            message.Subject = _txtSubject.Text;
            message.MessageContent = _txtMessageContent.Text;

            Message = message;
            if (String.IsNullOrEmpty(message.Subject))
            {
                MessageBox.Show("Please enter the Subject", "Warning", MessageBoxButtons.OK);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void MessageForm_Load( object sender, EventArgs e )
        {
            _txtName.Text = receiver.Name;
            _txtEmailAddress.Text = receiver.EmailAddress;
            

            //ValidateChildren();
        }

        private void OnValidatingSubject( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Subject is required!");
            } else
                _errors.SetError(control, "");
        }
    }
}
