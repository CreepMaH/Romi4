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
        double regPayPrice;

        public FormNewPayment(string exRegPayPrice)
        {
            InitializeComponent();

            regPayPrice = ParseStringToDouble(exRegPayPrice);
        }

        /// <summary>
        /// Преобразует строку в число формата "double" независимо от символа разделителя
        /// </summary>
        /// <param name="str">Входная строка</param>
        /// <returns></returns>
        private double ParseStringToDouble(string str)
        {
            double value;
            return
                double.TryParse(str.Replace(",", "."), out value)
                ? value
                : double.Parse(str.Replace(".", ","));
        }

        /// <summary>
        /// Делает активным то поле ввода, где установлен RadioButton, а второе деактивирует
        /// </summary>
        private void ChangeType()
        {
            if (radioButtonRegPays.Checked == true)
            {
                textBoxRegPays.Enabled = true;
                textBoxRubles.Enabled = false;
            }
            else
            {
                textBoxRubles.Enabled = true;
                textBoxRegPays.Enabled = false;
            }
        }

        private void radioButtonRubles_CheckedChanged(object sender, EventArgs e)
        {
            ChangeType();
        }

        private void radioButtonRegPays_CheckedChanged(object sender, EventArgs e)
        {
            ChangeType();
        }

        private void buttonReject_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                double diffValue;

                if (radioButtonRegPays.Checked)
                {
                    ParseStringToDouble(textBoxRegPays.Text);
                    diffValue = ParseStringToDouble(textBoxRegPays.Text);
                }
                else
                {
                    ParseStringToDouble(textBoxRubles.Text);
                    diffValue = ParseStringToDouble(textBoxRubles.Text) / regPayPrice;
                }

                FormPreData formPreData = Owner as FormPreData;
                formPreData.SetDiffPayment(diffValue);
                
                Close();
            }
            catch
            {
                MessageBox.Show("Проверьте введённые данные. Значение платежа должно быть численным.", "Ошибка данных",
                    MessageBoxButtons.OK);
            }
        }

        private void FormNewPayment_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormPreData formPreData = Owner as FormPreData;
            formPreData.checkBoxDiffPayment.Checked = false;
        }
    }
}
