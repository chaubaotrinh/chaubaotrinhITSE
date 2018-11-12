namespace ITSE1430.MovieLib.UI
{
    partial class MovieForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._ReleasedYear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._RunLength = new System.Windows.Forms.TextBox();
            this._bttSave = new System.Windows.Forms.Button();
            this._bttCancel = new System.Windows.Forms.Button();
            this._chkOwned = new System.Windows.Forms.CheckBox();
            this._errors = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._errors)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // _txtName
            // 
            this._txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtName.Location = new System.Drawing.Point(136, 40);
            this._txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(742, 26);
            this._txtName.TabIndex = 0;
            this._txtName.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateName);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // _txtDescription
            // 
            this._txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDescription.Location = new System.Drawing.Point(136, 80);
            this._txtDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._txtDescription.Multiline = true;
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Size = new System.Drawing.Size(742, 105);
            this._txtDescription.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 196);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Released Year";
            // 
            // _ReleasedYear
            // 
            this._ReleasedYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._ReleasedYear.Location = new System.Drawing.Point(136, 196);
            this._ReleasedYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._ReleasedYear.Name = "_ReleasedYear";
            this._ReleasedYear.Size = new System.Drawing.Size(132, 26);
            this._ReleasedYear.TabIndex = 2;
            this._ReleasedYear.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateReleaseYear);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 236);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Run Length";
            // 
            // _RunLength
            // 
            this._RunLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._RunLength.Location = new System.Drawing.Point(136, 236);
            this._RunLength.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._RunLength.Name = "_RunLength";
            this._RunLength.Size = new System.Drawing.Size(132, 26);
            this._RunLength.TabIndex = 3;
            this._RunLength.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateRunLength);
            // 
            // _bttSave
            // 
            this._bttSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._bttSave.Location = new System.Drawing.Point(647, 330);
            this._bttSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._bttSave.Name = "_bttSave";
            this._bttSave.Size = new System.Drawing.Size(112, 35);
            this._bttSave.TabIndex = 5;
            this._bttSave.Text = "Save";
            this._bttSave.UseVisualStyleBackColor = true;
            this._bttSave.Click += new System.EventHandler(this.OnSave);
            // 
            // _bttCancel
            // 
            this._bttCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._bttCancel.CausesValidation = false;
            this._bttCancel.Location = new System.Drawing.Point(768, 330);
            this._bttCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._bttCancel.Name = "_bttCancel";
            this._bttCancel.Size = new System.Drawing.Size(112, 35);
            this._bttCancel.TabIndex = 6;
            this._bttCancel.Text = "Cancel";
            this._bttCancel.UseVisualStyleBackColor = true;
            this._bttCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // _chkOwned
            // 
            this._chkOwned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._chkOwned.AutoSize = true;
            this._chkOwned.Location = new System.Drawing.Point(136, 278);
            this._chkOwned.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._chkOwned.Name = "_chkOwned";
            this._chkOwned.Size = new System.Drawing.Size(94, 24);
            this._chkOwned.TabIndex = 4;
            this._chkOwned.Text = "Owned?";
            this._chkOwned.UseVisualStyleBackColor = true;
            // 
            // _errors
            // 
            this._errors.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errors.ContainerControl = this;
            // 
            // MovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(944, 425);
            this.ControlBox = false;
            this.Controls.Add(this._chkOwned);
            this.Controls.Add(this._bttCancel);
            this.Controls.Add(this._bttSave);
            this.Controls.Add(this._RunLength);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._ReleasedYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._txtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txtName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(577, 459);
            this.Name = "MovieForm";
            this.ShowInTaskbar = false;
            this.Text = "Movie Details";
            this.Load += new System.EventHandler(this.MovieForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _ReleasedYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _RunLength;
        private System.Windows.Forms.Button _bttSave;
        private System.Windows.Forms.Button _bttCancel;
        private System.Windows.Forms.CheckBox _chkOwned;
        private System.Windows.Forms.ErrorProvider _errors;
    }
}