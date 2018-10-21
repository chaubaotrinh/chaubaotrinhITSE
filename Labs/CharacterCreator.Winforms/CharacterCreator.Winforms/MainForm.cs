using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Close", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            Close();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            var form = new About();
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;
        }

        private void OnCharacterNew( object sender, EventArgs e )
        {
            var form = new CreateNewCharacter();
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            _database.Add(form.Character);

            RefreshCharacters();
        }

        private void RefreshCharacters()
        {
            var characters = _database.GetAll();

            _listCharacters.Items.Clear();
            _listCharacters.Items.AddRange(characters);
        }


        private CharacterDatabase _database = new CharacterDatabase();

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);
            _listCharacters.DisplayMember = "Name";
            RefreshCharacters();
        }

        private void OnCharacterEdit( object sender, EventArgs e )
        {
            EditCharacter();
        }

        private void EditCharacter()
        {
            var item = GetSelectedCharacter();
            if (item == null)
                return;

            var form = new CreateNewCharacter();
            form.Text = "Edit Character";

            form.Character = item;
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            _database.Edit(item.Name, form.Character);
            RefreshCharacters();
        }

        private Character GetSelectedCharacter()
        {
            return _listCharacters.SelectedItem as Character;

        }

        private void OnCharacterDelete( object sender, EventArgs e )
        {
            DeleteCharacter();
        }

        private void DeleteCharacter()
        {
            var item = GetSelectedCharacter();
            if (item == null)
                return;

            if (MessageBox.Show($"Are you sure you want to delete {item.Name} ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            _database.Remove(item.Name);
            RefreshCharacters();
        }
    }
}
