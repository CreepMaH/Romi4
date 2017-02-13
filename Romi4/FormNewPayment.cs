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
        bool type;

        /// <summary>
        /// Конструктор формы изменения платежа
        /// </summary>
        /// <param name="regPayPrice">Стоимость учётного пая</param>
        /// <param name="type">Тип события: True - изменение ежемесячного платежа, 
        /// False - изменение платежа после заселения</param>
        public FormNewPayment(string regPayPrice, bool type)
        {
            InitializeComponent();

            this.regPayPrice = ParseStringToDouble(regPayPrice);
            this.type = type;

            Width = 215;    //Задание минимальной ширины формы

            if (type) labelText.Text = "Введите размер ежемесячного платежа:";
            else
            {
                labelText.Text = "Введите размер платежа после заселения:";
                checkBoxMore.Visible = true;
            }

            InitToolTips();
        }

        //Обработчики формы
        private void FormNewPayment_Load(object sender, EventArgs e)
        {
            textBoxRegPays.Focus();
        }
        private void FormNewPayment_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormPreData formPreData = Owner as FormPreData;

            if ((DialogResult != DialogResult.OK) && !type) formPreData.checkBoxDiffPayment.Checked = false;
        }

        //Функции
        /// <summary>
        /// Задаёт всплывающие подсказки для элементов формы
        /// </summary>
        private void InitToolTips()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(checkBoxMore, "Позволяет разделить платежи после заселения на 2 периода");
            toolTip.SetToolTip(textBoxPayment, "Платёж в течение заданного периода");
            toolTip.SetToolTip(textBoxPeriod,
                "Период после заселения, в течение которого выплачивается отличный от заданного платёж");
            toolTip.SetToolTip(labelPayment, "Платёж в течение заданного периода");
            toolTip.SetToolTip(labelPeriod,
                "Период после заселения, в течение которого выплачивается отличный от заданного платёж");
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

        //Обработчики событий
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
                double diffPayment;         //Платёж после заселения
                double diffPaymentPeriod;   //Платёж в заданный период
                int period;                 //Период изменённого платежа

                if (radioButtonRegPays.Checked)
                {
                    diffPayment = ParseStringToDouble(textBoxRegPays.Text);
                }
                else
                {
                    ParseStringToDouble(textBoxRubles.Text);
                    diffPayment = ParseStringToDouble(textBoxRubles.Text) / regPayPrice;
                }

                FormPreData formPreData = Owner as FormPreData;

                if (!type)      //Если необходимо ввести изменённый платёж
                {
                    if (!checkBoxMore.Checked) formPreData.SetDiffPayment(diffPayment,
                        0.0, 0);   //Присвоение нового платежа после заселения
                    else
                    {
                        diffPaymentPeriod = ParseStringToDouble(textBoxPayment.Text);
                        period = Convert.ToInt16(textBoxPeriod.Text);

                        formPreData.SetDiffPayment(diffPayment, diffPaymentPeriod,
                        period);
                    }
                }
                else formPreData.textBoxMonthlyPaymentRegPays.Text = diffPayment.ToString();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show("Проверьте введённые данные. Значение платежа должно быть численным.", "Ошибка данных",
                    MessageBoxButtons.OK);
            }
        }

        private void textBoxRubles_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxRegPays.Text = (ParseStringToDouble(textBoxRubles.Text) / regPayPrice).ToString();
                textBoxRegPays.SelectionStart = textBoxRegPays.Text.Length;
            }
            catch
            {
                return;
            }
        }

        private void textBoxRegPays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxRubles.Text = (ParseStringToDouble(textBoxRegPays.Text) * regPayPrice).ToString();
            }
            catch
            {
                return;
            }
        }

        private void checkBoxMore_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMore.Checked) Width = 400;      //Расширение формы для показа опций
            else Width = 215;
        }

        private void checkBoxMore_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Help;
        }

        private void checkBoxMore_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void labelPayment_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Help;
        }

        private void labelPayment_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void labelPeriod_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Help;
        }

        private void labelPeriod_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}
