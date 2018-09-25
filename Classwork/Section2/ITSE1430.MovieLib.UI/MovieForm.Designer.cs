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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(91, 27);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(181, 20);
            this._txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // _txtDescription
            // 
            this._txtDescription.Location = new System.Drawing.Point(91, 68);
            this._txtDescription.Multiline = true;
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Size = new System.Drawing.Size(181, 89);
            this._txtDescription.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Released Year";
            // 
            // _ReleasedYear
            // 
            this._ReleasedYear.Location = new System.Drawing.Point(91, 178);
            this._ReleasedYear.Name = "_ReleasedYear";
            this._ReleasedYear.Size = new System.Drawing.Size(55, 20);
            this._ReleasedYear.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Run Length";
            // 
            // _RunLength
            // 
            this._RunLength.Location = new System.Drawing.Point(91, 214);
            this._RunLength.Name = "_RunLength";
            this._RunLength.Size = new System.Drawing.Size(55, 20);
            this._RunLength.TabIndex = 7;
            // 
            // _bttSave
            // 
            this._bttSave.Location = new System.Drawing.Point(91, 266);
            this._bttSave.Name = "_bttSave";
            this._bttSave.Size = new System.Drawing.Size(75, 23);
            this._bttSave.TabIndex = 8;
            this._bttSave.Text = "Save";
            this._bttSave.UseVisualStyleBackColor = true;
            this._bttSave.Click += new System.EventHandler(this.OnSave);
            // 
            // _bttCancel
            // 
            this._bttCancel.Location = new System.Drawing.Point(172, 266);
            this._bttCancel.Name = "_bttCancel";
            this._bttCancel.Size = new System.Drawing.Size(75, 23);
            this._bttCancel.TabIndex = 9;
            this._bttCancel.Text = "Cancel";
            this._bttCancel.UseVisualStyleBackColor = true;
            this._bttCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // MovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 416);
            this.ControlBox = false;
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
            this.Name = "MovieForm";
            this.ShowInTaskbar = false;
            this.Text = "Movie Details";
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
    }
}