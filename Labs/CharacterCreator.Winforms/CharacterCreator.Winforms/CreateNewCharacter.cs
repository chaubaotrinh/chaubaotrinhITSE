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
    public partial class CreateNewCharacter : Form
    {
        public CreateNewCharacter()
        {
            InitializeComponent();
        }

        public Character Character { get; set; }

        private void CreateNewCharacter_Load( object sender, EventArgs e )
        {
            if (Character != null)
            {
                _txtName.Text = Character.Name;
                _comboProfession.SelectedItem = Character.Profession;
                _comboRace.SelectedItem = Character.Race;
                _txtStrength.Text = Character.Strength.ToString();
                _txtIntelligence.Text = Character.Intelligence.ToString();
                _txtAgility.Text = Character.Agility.ToString();
                _txtConstitution.Text = Character.Constitution.ToString();
                _txtCharisma.Text = Character.Charisma.ToString();
                _txtDescription.Text = Character.Description;
            };

            ValidateChildren();

        }
        
        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var character = new Character();

            character.Name = _txtName.Text;
            character.Profession = _comboProfession.SelectedItem.ToString();
            character.Race = _comboRace.SelectedItem.ToString();
            character.Strength = GetInt32(_txtStrength);
            character.Intelligence = GetInt32(_txtIntelligence);
            character.Agility = GetInt32(_txtAgility);
            character.Constitution = GetInt32(_txtConstitution);
            character.Charisma = GetInt32(_txtCharisma);
            character.Description = _txtDescription.Text;

            Character = character;
            DialogResult = DialogResult.OK;
            Close();

        }

        private int GetInt32( TextBox textBox )
        {
            if (String.IsNullOrEmpty(textBox.Text))
                return -1;

            if (Int32.TryParse(textBox.Text, out var value))
                return value;

            return -1;
        }

        private void OnValidateName( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Name is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateProfession( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Profession is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateRace( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Race is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateStrength( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 1 || result > 100)
            {
                _errors.SetError(control, "Must be in the range 1 - 100");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateIntelligence( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 1 || result > 100)
            {
                _errors.SetError(control, "Must be in the range 1 - 100");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateAgility( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 1 || result > 100)
            {
                _errors.SetError(control, "Must be in the range 1 - 100");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateConstitution( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 1 || result > 100)
            {
                _errors.SetError(control, "Must be in the range 1 - 100");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateCharisma( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 1 || result > 100)
            {
                _errors.SetError(control, "Must be in the range 1 - 100");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
    }
}
