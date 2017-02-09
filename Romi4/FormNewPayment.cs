using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Romi4
{
    public partial class FormNewPayment : Form
    {
        public FormNewPayment()
        {
            InitializeComponent();
        }

        private void RublesChosen()
        {
            radioButtonRegPays.Checked = false;
            textBoxRegPays.Enabled = false;
        }

        private void RegPaysChosen()
        {
            radioButtonRubles.Checked = false;
            textBoxRubles.Enabled = false;
        }

        private void radioButtonRubles_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRubles.Checked) RublesChosen();
            else RegPaysChosen();
        }

        private void radioButtonRegPays_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRubles.Checked) RegPaysChosen();
            else RublesChosen();
        }

        private void buttonReject_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            string diffValue;

            if (radioButtonRegPays.Checked) diffValue = textBoxRegPays.Text;
            else diffValue = textBoxRubles.Text;

            FormPreData formPreData = Owner as FormPreData;
            //formPreData.SetDiffPayment(tex)
        }
    }
}
