namespace Romi4
{
    partial class FormNewPayment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
            this.radioButtonRubles = new System.Windows.Forms.RadioButton();
            this.radioButtonRegPays = new System.Windows.Forms.RadioButton();
            this.textBoxRubles = new System.Windows.Forms.TextBox();
            this.textBoxRegPays = new System.Windows.Forms.TextBox();
            this.buttonReject = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите размер платежа после заселения:";
            // 
            // radioButtonRubles
            // 
            this.radioButtonRubles.AutoSize = true;
            this.radioButtonRubles.Checked = true;
            this.radioButtonRubles.Location = new System.Drawing.Point(18, 63);
            this.radioButtonRubles.Name = "radioButtonRubles";
            this.radioButtonRubles.Size = new System.Drawing.Size(69, 17);
            this.radioButtonRubles.TabIndex = 1;
            this.radioButtonRubles.TabStop = true;
            this.radioButtonRubles.Text = "В рублях";
            this.radioButtonRubles.UseVisualStyleBackColor = true;
            this.radioButtonRubles.CheckedChanged += new System.EventHandler(this.radioButtonRubles_CheckedChanged);
            // 
            // radioButtonRegPays
            // 
            this.radioButtonRegPays.AutoSize = true;
            this.radioButtonRegPays.Location = new System.Drawing.Point(18, 89);
            this.radioButtonRegPays.Name = "radioButtonRegPays";
            this.radioButtonRegPays.Size = new System.Drawing.Size(74, 17);
            this.radioButtonRegPays.TabIndex = 2;
            this.radioButtonRegPays.Text = "В уч. паях";
            this.radioButtonRegPays.UseVisualStyleBackColor = true;
            this.radioButtonRegPays.CheckedChanged += new System.EventHandler(this.radioButtonRegPays_CheckedChanged);
            // 
            // textBoxRubles
            // 
            this.textBoxRubles.Location = new System.Drawing.Point(109, 62);
            this.textBoxRubles.Name = "textBoxRubles";
            this.textBoxRubles.Size = new System.Drawing.Size(64, 20);
            this.textBoxRubles.TabIndex = 3;
            this.textBoxRubles.TextChanged += new System.EventHandler(this.textBoxRubles_TextChanged);
            // 
            // textBoxRegPays
            // 
            this.textBoxRegPays.Enabled = false;
            this.textBoxRegPays.Location = new System.Drawing.Point(109, 88);
            this.textBoxRegPays.Name = "textBoxRegPays";
            this.textBoxRegPays.Size = new System.Drawing.Size(64, 20);
            this.textBoxRegPays.TabIndex = 4;
            this.textBoxRegPays.TextChanged += new System.EventHandler(this.textBoxRegPays_TextChanged);
            // 
            // buttonReject
            // 
            this.buttonReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonReject.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonReject.Location = new System.Drawing.Point(18, 130);
            this.buttonReject.Name = "buttonReject";
            this.buttonReject.Size = new System.Drawing.Size(75, 23);
            this.buttonReject.TabIndex = 5;
            this.buttonReject.Text = "Отменить";
            this.buttonReject.UseVisualStyleBackColor = false;
            this.buttonReject.Click += new System.EventHandler(this.buttonReject_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAccept.Location = new System.Drawing.Point(109, 130);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 6;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = false;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // FormNewPayment
            // 
            this.AcceptButton = this.buttonAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonReject;
            this.ClientSize = new System.Drawing.Size(205, 170);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.buttonReject);
            this.Controls.Add(this.textBoxRegPays);
            this.Controls.Add(this.textBoxRubles);
            this.Controls.Add(this.radioButtonRegPays);
            this.Controls.Add(this.radioButtonRubles);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение платежа";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormNewPayment_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonRubles;
        private System.Windows.Forms.RadioButton radioButtonRegPays;
        private System.Windows.Forms.TextBox textBoxRubles;
        private System.Windows.Forms.TextBox textBoxRegPays;
        private System.Windows.Forms.Button buttonReject;
        private System.Windows.Forms.Button buttonAccept;
    }
}