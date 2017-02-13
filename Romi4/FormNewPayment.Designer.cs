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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewPayment));
            this.labelText = new System.Windows.Forms.Label();
            this.radioButtonRubles = new System.Windows.Forms.RadioButton();
            this.radioButtonRegPays = new System.Windows.Forms.RadioButton();
            this.textBoxRubles = new System.Windows.Forms.TextBox();
            this.textBoxRegPays = new System.Windows.Forms.TextBox();
            this.buttonReject = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.checkBoxMore = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelMore = new System.Windows.Forms.Label();
            this.labelPayment = new System.Windows.Forms.Label();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.textBoxPayment = new System.Windows.Forms.TextBox();
            this.textBoxPeriod = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelText
            // 
            this.labelText.Location = new System.Drawing.Point(12, 9);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(169, 30);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "Введите размер платежа после заселения:";
            // 
            // radioButtonRubles
            // 
            this.radioButtonRubles.AutoSize = true;
            this.radioButtonRubles.Checked = true;
            this.radioButtonRubles.Location = new System.Drawing.Point(15, 54);
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
            this.radioButtonRegPays.Location = new System.Drawing.Point(15, 80);
            this.radioButtonRegPays.Name = "radioButtonRegPays";
            this.radioButtonRegPays.Size = new System.Drawing.Size(74, 17);
            this.radioButtonRegPays.TabIndex = 2;
            this.radioButtonRegPays.Text = "В уч. паях";
            this.radioButtonRegPays.UseVisualStyleBackColor = true;
            this.radioButtonRegPays.CheckedChanged += new System.EventHandler(this.radioButtonRegPays_CheckedChanged);
            // 
            // textBoxRubles
            // 
            this.textBoxRubles.Location = new System.Drawing.Point(106, 53);
            this.textBoxRubles.Name = "textBoxRubles";
            this.textBoxRubles.Size = new System.Drawing.Size(64, 20);
            this.textBoxRubles.TabIndex = 0;
            this.textBoxRubles.TextChanged += new System.EventHandler(this.textBoxRubles_TextChanged);
            // 
            // textBoxRegPays
            // 
            this.textBoxRegPays.Enabled = false;
            this.textBoxRegPays.Location = new System.Drawing.Point(106, 79);
            this.textBoxRegPays.Name = "textBoxRegPays";
            this.textBoxRegPays.Size = new System.Drawing.Size(64, 20);
            this.textBoxRegPays.TabIndex = 1;
            this.textBoxRegPays.TextChanged += new System.EventHandler(this.textBoxRegPays_TextChanged);
            // 
            // buttonReject
            // 
            this.buttonReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonReject.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonReject.Location = new System.Drawing.Point(15, 128);
            this.buttonReject.Name = "buttonReject";
            this.buttonReject.Size = new System.Drawing.Size(75, 23);
            this.buttonReject.TabIndex = 3;
            this.buttonReject.Text = "Отменить";
            this.buttonReject.UseVisualStyleBackColor = false;
            this.buttonReject.Click += new System.EventHandler(this.buttonReject_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAccept.Location = new System.Drawing.Point(106, 128);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 4;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = false;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // checkBoxMore
            // 
            this.checkBoxMore.AutoSize = true;
            this.checkBoxMore.Location = new System.Drawing.Point(15, 105);
            this.checkBoxMore.Name = "checkBoxMore";
            this.checkBoxMore.Size = new System.Drawing.Size(115, 17);
            this.checkBoxMore.TabIndex = 2;
            this.checkBoxMore.Text = "Добавить период";
            this.checkBoxMore.UseVisualStyleBackColor = true;
            this.checkBoxMore.Visible = false;
            this.checkBoxMore.CheckedChanged += new System.EventHandler(this.checkBoxMore_CheckedChanged);
            this.checkBoxMore.MouseEnter += new System.EventHandler(this.checkBoxMore_MouseEnter);
            this.checkBoxMore.MouseLeave += new System.EventHandler(this.checkBoxMore_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(199, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 112);
            this.panel1.TabIndex = 8;
            // 
            // labelMore
            // 
            this.labelMore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelMore.Location = new System.Drawing.Point(215, 9);
            this.labelMore.Name = "labelMore";
            this.labelMore.Size = new System.Drawing.Size(157, 30);
            this.labelMore.TabIndex = 9;
            this.labelMore.Text = "Введите параметры периода:";
            // 
            // labelPayment
            // 
            this.labelPayment.AutoSize = true;
            this.labelPayment.Location = new System.Drawing.Point(215, 57);
            this.labelPayment.Name = "labelPayment";
            this.labelPayment.Size = new System.Drawing.Size(77, 13);
            this.labelPayment.TabIndex = 10;
            this.labelPayment.Text = "Платёж, уч.п.:";
            this.labelPayment.MouseEnter += new System.EventHandler(this.labelPayment_MouseEnter);
            this.labelPayment.MouseLeave += new System.EventHandler(this.labelPayment_MouseLeave);
            // 
            // labelPeriod
            // 
            this.labelPeriod.AutoSize = true;
            this.labelPeriod.Location = new System.Drawing.Point(215, 83);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(77, 13);
            this.labelPeriod.TabIndex = 11;
            this.labelPeriod.Text = "Период, мес.:";
            this.labelPeriod.MouseEnter += new System.EventHandler(this.labelPeriod_MouseEnter);
            this.labelPeriod.MouseLeave += new System.EventHandler(this.labelPeriod_MouseLeave);
            // 
            // textBoxPayment
            // 
            this.textBoxPayment.Location = new System.Drawing.Point(298, 54);
            this.textBoxPayment.Name = "textBoxPayment";
            this.textBoxPayment.Size = new System.Drawing.Size(74, 20);
            this.textBoxPayment.TabIndex = 12;
            this.textBoxPayment.TabStop = false;
            // 
            // textBoxPeriod
            // 
            this.textBoxPeriod.Location = new System.Drawing.Point(298, 80);
            this.textBoxPeriod.Name = "textBoxPeriod";
            this.textBoxPeriod.Size = new System.Drawing.Size(74, 20);
            this.textBoxPeriod.TabIndex = 13;
            this.textBoxPeriod.TabStop = false;
            // 
            // FormNewPayment
            // 
            this.AcceptButton = this.buttonAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonReject;
            this.ClientSize = new System.Drawing.Size(384, 162);
            this.Controls.Add(this.textBoxPeriod);
            this.Controls.Add(this.textBoxPayment);
            this.Controls.Add(this.labelPeriod);
            this.Controls.Add(this.labelPayment);
            this.Controls.Add(this.labelMore);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBoxMore);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.buttonReject);
            this.Controls.Add(this.textBoxRegPays);
            this.Controls.Add(this.textBoxRubles);
            this.Controls.Add(this.radioButtonRegPays);
            this.Controls.Add(this.radioButtonRubles);
            this.Controls.Add(this.labelText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(215, 200);
            this.Name = "FormNewPayment";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение платежа";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormNewPayment_FormClosed);
            this.Load += new System.EventHandler(this.FormNewPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.RadioButton radioButtonRubles;
        private System.Windows.Forms.RadioButton radioButtonRegPays;
        private System.Windows.Forms.TextBox textBoxRubles;
        private System.Windows.Forms.TextBox textBoxRegPays;
        private System.Windows.Forms.Button buttonReject;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.CheckBox checkBoxMore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelMore;
        private System.Windows.Forms.Label labelPayment;
        private System.Windows.Forms.Label labelPeriod;
        private System.Windows.Forms.TextBox textBoxPayment;
        private System.Windows.Forms.TextBox textBoxPeriod;
    }
}