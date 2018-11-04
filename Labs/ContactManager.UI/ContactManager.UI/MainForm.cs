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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            MessageBox.Show(this, "Lab 3: Contact Manager by Chau Trinh - Course ITSE 1430", "About", MessageBoxButtons.OK);
        }

        private void OnContactAdd( object sender, EventArgs e )
        {
            var form = new ContactForm();
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            _contactDatabase.Add(form.Contact);

            RefreshContacts();
        }

        private void RefreshContacts()
        {
            var contacts = _contactDatabase.GetAll();

            _listContacts.Items.Clear();
            _listContacts.Items.AddRange(contacts);
        }

        private ContactDatabase _contactDatabase = new ContactDatabase();

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);
            _listContacts.DisplayMember = "Name";
           
            RefreshContacts();
        }

        private void OnContactEdit( object sender, EventArgs e )
        {
            EditContact();
        }

        private void EditContact()
        {
            var item = GetSelectedContact();
            if (item == null)
                return;

            var form = new ContactForm();
            form.Text = "Edit Contact";

            form.Contact = item;
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            _contactDatabase.Edit(item.Name, form.Contact);
            RefreshContacts();
        }

        private Contact GetSelectedContact()
        {
            return _listContacts.SelectedItem as Contact;
        }
        
        private void OnContactDoubleClick( object sender, EventArgs e )
        {
            EditContact();
        }

        private void OnContactDelete( object sender, EventArgs e )
        {
            DeleteContact();
        }

        private void DeleteContact()
        {
            var item = GetSelectedContact();
            if (item == null)
                return;

            if (MessageBox.Show($"Are you sure you want to delele " + _listContacts.DisplayMember + "?", 
                "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            
            _contactDatabase.Remove(item.Name);
            RefreshContacts();
        }

        private void OnSend( object sender, EventArgs e )
        {
            var item = GetSelectedContact();
            if (item == null)
                return;

            var form = new MessageForm(item);

            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;
        }
        //
       
    }
}
