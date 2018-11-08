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
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
        }
        public Contact Contact { get; set; }

        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var contact = new Contact();

            contact.Name = _txtName.Text;
            contact.EmailAddress = _txtEmailAddress.Text;

            Contact = contact;
            Contact = contact;
            if (IsValidEmail(contact.EmailAddress) == false)
            {
                MessageBox.Show("You enter an invalid email address. Please put the valid email address", "Warning", MessageBoxButtons.OK);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool IsValidEmail( string source )
        {
            try
            {
                new System.Net.Mail.MailAddress(source);
                return true;
            } catch
            { };
            return false;
        }

        private void ContactForm_Load( object sender, EventArgs e )
        {
            if (Contact != null)
            {
                _txtName.Text = Contact.Name;
                _txtEmailAddress.Text = Contact.EmailAddress;
            }

            ValidateChildren();
        }

        private void OnValidatingName( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Name is required!");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidatingEmailAddress( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Email Address is required!");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
    }
}
