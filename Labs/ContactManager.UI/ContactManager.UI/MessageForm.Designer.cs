namespace ContactManager.UI
{
    partial class MessageForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._txtEmailAddress = new System.Windows.Forms.TextBox();
            this._txtSubject = new System.Windows.Forms.TextBox();
            this._txtMessageContent = new System.Windows.Forms.TextBox();
            this._btnSend = new System.Windows.Forms.Button();
            this._errors = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._errors)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Subject";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Message Content";
            // 
            // _txtName
            // 
            this._txtName.Enabled = false;
            this._txtName.Location = new System.Drawing.Point(239, 49);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(505, 26);
            this._txtName.TabIndex = 4;
            // 
            // _txtEmailAddress
            // 
            this._txtEmailAddress.Enabled = false;
            this._txtEmailAddress.Location = new System.Drawing.Point(239, 102);
            this._txtEmailAddress.Name = "_txtEmailAddress";
            this._txtEmailAddress.Size = new System.Drawing.Size(505, 26);
            this._txtEmailAddress.TabIndex = 5;
            // 
            // _txtSubject
            // 
            this._txtSubject.Location = new System.Drawing.Point(239, 150);
            this._txtSubject.Name = "_txtSubject";
            this._txtSubject.Size = new System.Drawing.Size(505, 26);
            this._txtSubject.TabIndex = 6;
            this._txtSubject.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidatingSubject);
            // 
            // _txtMessageContent
            // 
            this._txtMessageContent.Location = new System.Drawing.Point(239, 200);
            this._txtMessageContent.Multiline = true;
            this._txtMessageContent.Name = "_txtMessageContent";
            this._txtMessageContent.Size = new System.Drawing.Size(505, 143);
            this._txtMessageContent.TabIndex = 7;
            // 
            // _btnSend
            // 
            this._btnSend.Location = new System.Drawing.Point(608, 362);
            this._btnSend.Name = "_btnSend";
            this._btnSend.Size = new System.Drawing.Size(136, 39);
            this._btnSend.TabIndex = 8;
            this._btnSend.Text = "Send";
            this._btnSend.UseVisualStyleBackColor = true;
            this._btnSend.Click += new System.EventHandler(this.OnSend);
            // 
            // _errors
            // 
            this._errors.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errors.ContainerControl = this;
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._btnSend);
            this.Controls.Add(this._txtMessageContent);
            this.Controls.Add(this._txtSubject);
            this.Controls.Add(this._txtEmailAddress);
            this.Controls.Add(this._txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Message";
            this.Load += new System.EventHandler(this.MessageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.TextBox _txtEmailAddress;
        private System.Windows.Forms.TextBox _txtSubject;
        private System.Windows.Forms.TextBox _txtMessageContent;
        private System.Windows.Forms.Button _btnSend;
        private System.Windows.Forms.ErrorProvider _errors;
    }
}