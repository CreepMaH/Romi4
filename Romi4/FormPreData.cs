using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Romi4
{
    public partial class FormPreData : Form
    {
        //Переменные временных показателей накопления. Присваиваются в CalcBigPlan() и используются
        //при выводе на печать
        string fullTime;
        string accumTime;
        string buyoutTime;
        string incomeTime;
        string settlementPayment;

        string diffPayment;

        public FormPreData()
        {
            InitializeComponent();
            SetRegPayPriceFromFile();
            CalcSmallPlan();
            CalcBigPlan();
        }

        //Обработчики формы

        private void FormPreData_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.OpenForms["FormAuth"].Show();
            System.Windows.Forms.Application.OpenForms["FormAuth"].Activate();
        }

        //Функции
        public void SetDiffPayment(string diffValue)
        {
            diffPayment = diffValue;
        }

        /// <summary>
        /// Считывает из текстового файла значение стоимости учётного пая и добавляет его на форму
        /// </summary>
        private void SetRegPayPriceFromFile()
        {
            string regPayPrice;

            StreamReader fs = new StreamReader("Стоимость учётного пая.txt");
            regPayPrice = fs.ReadLine();
            try
            {
                ParseStringToDouble(regPayPrice);
                textBoxRegPayPrice.Text = regPayPrice;
            }
            catch
            {
                MessageBox.Show("Проверьте значение стоимости учётного пая в файле Стоимость учётного пая.txt", "Ошибка чтения", MessageBoxButtons.OK);
            }
            finally
            {
                fs.Close();
            }
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
        /// Рассчитывает маленькую таблицу плана и значения в неизменяемых TextBox'ах, а также проверяет вводимые
        /// данные
        /// </summary>
        private void CalcSmallPlan()
        {
            try
            {
                double square = ParseStringToDouble(textBoxSquare.Text);
                double price = ParseStringToDouble(textBoxPrice.Text);
                double sqMPrice = price / square;
                double regPayPrice = ParseStringToDouble(textBoxRegPayPrice.Text);
                double firstPayment = ParseStringToDouble(textBoxFirstPayment.Text);
                double fundsNeed = price - firstPayment;
                double monthlyPaymentRegPays = ParseStringToDouble(textBoxMonthlyPaymentRegPays.Text);
                double monthlyPayment = monthlyPaymentRegPays * regPayPrice;
                short smallPlanRowsCount = Convert.ToInt16(dataGridViewSmallPlanParams.Rows.Count);

                textBoxSqMPrice.Text = Convert.ToString(Math.Round(sqMPrice, 2));
                textBoxIncomePayment.Text = Convert.ToString(Math.Round(fundsNeed * 0.005, 2));
                textBoxMonthlyPaymentSqM.Text = Convert.ToString(Math.Round(monthlyPaymentRegPays * regPayPrice / sqMPrice, 4));
                //textBoxMonthlyPaymentRubles.Text = Convert.ToString(Math.Round(monthlyPaymentRegPays * regPayPrice, 2));
                
                //Создание таблицы параметров плана
                DataTable smallTable = new DataTable();
                smallTable.Columns.Add(new DataColumn("Название характеристики", typeof(string)));
                smallTable.Columns.Add(new DataColumn("Рублей", typeof(string)));
                smallTable.Columns.Add(new DataColumn("Кв. метров", typeof(string)));
                smallTable.Columns.Add(new DataColumn("Уч. паёв", typeof(string)));

                //Заполнение таблицы параметров плана
                DataRow dr = smallTable.NewRow();
                //Строка 1
                dr["Название характеристики"] = "Параметры целевой недвижимости";
                dr["Рублей"] = price.ToString("0.00");
                dr["Кв. метров"] = square.ToString("0.0000");
                dr["Уч. паёв"] = (price / regPayPrice).ToString("0.0000");
                smallTable.Rows.Add(dr);
                //Строка 2
                dr = smallTable.NewRow();
                dr["Название характеристики"] = "Первоначальный взнос";
                dr["Рублей"] = firstPayment.ToString("0.00");
                dr["Кв. метров"] = (firstPayment / sqMPrice).ToString("0.0000");
                dr["Уч. паёв"] = (firstPayment / regPayPrice).ToString("0.0000");
                smallTable.Rows.Add(dr);
                //Строка 3
                dr = smallTable.NewRow();
                dr["Название характеристики"] = "Потребность дофинансирования";
                dr["Рублей"] = fundsNeed.ToString("0.00");
                dr["Кв. метров"] = (fundsNeed / sqMPrice).ToString("0.0000");
                dr["Уч. паёв"] = (fundsNeed / regPayPrice).ToString("0.0000");
                smallTable.Rows.Add(dr);
                //Строка 4
                dr = smallTable.NewRow();
                dr["Название характеристики"] = "Ежемесячный паевой взнос";
                dr["Рублей"] = monthlyPayment.ToString("0.00");
                dr["Кв. метров"] = (monthlyPayment / sqMPrice).ToString("0.0000");
                dr["Уч. паёв"] = monthlyPaymentRegPays.ToString("0.0000");
                smallTable.Rows.Add(dr);

                //Привязка источника данных таблицы
                bindingSourceSmallPlan.DataSource = smallTable;
                dataGridViewSmallPlanParams.DataSource = bindingSourceSmallPlan;
            }
            catch
            {
                //textBoxSqMPrice.Text = "";
                //textBoxIncomePayment.Text = "";
                return;
            }
        }

        /// <summary>
        /// Рассчитывает план накопления до заданного рейтинга
        /// </summary>
        private void CalcBigPlan()
        {
            try
            {
                double square = ParseStringToDouble(textBoxSquare.Text);
                double price = ParseStringToDouble(textBoxPrice.Text);
                double sqMPrice = price / square;
                double regPayPrice = ParseStringToDouble(textBoxRegPayPrice.Text);
                double firstPayment = ParseStringToDouble(textBoxFirstPayment.Text);
                double firstPaymentSqM = firstPayment / sqMPrice;
                double firstPaymentRegPays = firstPayment / regPayPrice;
                double monthlyPaymentRegPays = ParseStringToDouble(textBoxMonthlyPaymentRegPays.Text);
                double monthlyPaymentSqM = monthlyPaymentRegPays * regPayPrice / sqMPrice;

                //Создание таблицы плана накопления
                DataTable bigTable = new DataTable();
                //bigTable.Rows.Clear();
                DataRow dr = bigTable.NewRow();
                bigTable.Columns.Add(new DataColumn("№", typeof(string)));
                bigTable.Columns.Add(new DataColumn("Дата платежа", typeof(string)));
                bigTable.Columns.Add(new DataColumn("Паевой взнос, кв.м.", typeof(string)));
                bigTable.Columns.Add(new DataColumn("Паевой взнос, уч.п.", typeof(string)));
                bigTable.Columns.Add(new DataColumn("Накопленная площадь, кв.м.", typeof(string)));
                bigTable.Columns.Add(new DataColumn("Невыкупленный остаток, кв.м.", typeof(string)));
                bigTable.Columns.Add(new DataColumn("Рейтинг", typeof(string)));
                bigTable.Columns.Add(new DataColumn("Индивидуальная рента, кв.м.", typeof(string)));
                bigTable.Columns.Add(new DataColumn("Взнос за владение и пользование, кв.м.", typeof(string)));
                bigTable.Columns.Add(new DataColumn("Итого платежей в месяц, кв.м.", typeof(string)));
                bigTable.Columns.Add(new DataColumn("Итого платежей в месяц, уч.п.", typeof(string)));

                //Заполнение таблицы плана накопления
                int num = 1;
                double settlPaymentNum; //5%-ый взнос при заселении
                double paymentSqM;
                double paymentRegPays;
                double accumSquare;
                double restSquare;
                double rating;
                double indRent;
                double usingPayment;
                double monthlySummarySqM;
                double monthlySummaryRegPays;
                List<double> arrAccum = new List<double>();
                List<double> arrRating = new List<double>();
                List<double> arrRest = new List<double>();
                List<double> arrIndRent = new List<double>();
                List<double> arrUsingPayment = new List<double>();
                List<double> arrPaymentSqM = new List<double>();

                //Первая строка
                paymentSqM = firstPaymentSqM;
                paymentRegPays = firstPaymentRegPays;
                accumSquare = firstPaymentSqM;
                arrAccum.Add(accumSquare);
                restSquare = square - firstPaymentSqM;
                indRent = firstPaymentSqM * 0.015 / 12;
                rating = CalcRating(arrAccum, restSquare, indRent, monthlyPaymentSqM);
                usingPayment = 0.0;
                monthlySummarySqM = firstPaymentSqM;
                monthlySummaryRegPays = firstPaymentRegPays;

                arrRating.Add(rating);
                arrRest.Add(restSquare);
                arrIndRent.Add(indRent);
                arrPaymentSqM.Add(paymentSqM);

                AddRowToTable(bigTable, num, paymentSqM, paymentRegPays, accumSquare, restSquare, rating, indRent, usingPayment, monthlySummarySqM, monthlySummaryRegPays);

                //От второй строки и до заселения
                bool incTimeAdded = false;      //Индикатор присвоения значения переменной incomeTime (время заселения по реалистичному плану)

                while (rating < ParseStringToDouble(textBoxSettlementRating.Text))
                {
                    num++;
                    monthlySummarySqM = monthlyPaymentSqM;
                    monthlySummaryRegPays = monthlySummarySqM * sqMPrice / regPayPrice;
                    restSquare = arrRest.Last() - arrIndRent.Last() - monthlySummarySqM;
                    usingPayment = 0.0;
                    paymentSqM = monthlySummarySqM;
                    paymentRegPays = paymentSqM * sqMPrice / regPayPrice;
                    accumSquare = paymentSqM + arrAccum.Last() + arrIndRent.Last();
                    arrAccum.Add(accumSquare);
                    indRent = accumSquare * 0.015 / 12;
                    rating = CalcRating(arrAccum, restSquare, indRent, monthlyPaymentSqM);

                    //Время заселения по реалистичному плану (на печать)
                    if ((rating > 0.1) && (!incTimeAdded))
                    {
                        incomeTime = num.ToString();
                        incTimeAdded = true;
                    }

                    arrRating.Add(rating);
                    arrRest.Add(restSquare);
                    arrIndRent.Add(indRent);
                    arrPaymentSqM.Add(paymentSqM);

                    AddRowToTable(bigTable, num, paymentSqM, paymentRegPays, accumSquare, restSquare, rating, indRent, usingPayment, monthlySummarySqM, monthlySummaryRegPays);
                }

                //Время накопления по осмотрительному плану (на печать)
                accumTime = num.ToString();

                //Первая строка после заселения
                settlPaymentNum = arrRest.Last() * 0.05;
                settlementPayment = (settlPaymentNum * sqMPrice).ToString("0.00");

                num++;
                monthlySummarySqM = monthlyPaymentSqM;
                monthlySummaryRegPays = monthlySummarySqM * sqMPrice / regPayPrice;
                restSquare = (arrRest.Last() - arrIndRent.Last() - monthlySummarySqM) / 0.995;
                arrRest.Add(restSquare);
                usingPayment = restSquare * 0.005;
                arrUsingPayment.Add(usingPayment);
                paymentSqM = monthlySummarySqM - usingPayment;
                arrPaymentSqM.Add(paymentSqM);
                paymentRegPays = paymentSqM * sqMPrice / regPayPrice;
                accumSquare = paymentSqM + arrAccum.Last() + arrIndRent.Last();
                arrAccum.Add(accumSquare);
                indRent = 0.0;
                rating = 0.0;

                AddRowToTable(bigTable, num, paymentSqM, paymentRegPays, accumSquare, restSquare, rating, indRent, usingPayment, monthlySummarySqM, monthlySummaryRegPays);
                
                //От второй строки после заселения и до последнего платежа
                while (restSquare > monthlySummarySqM)
                {
                    num++;
                    monthlySummarySqM = monthlyPaymentSqM;
                    monthlySummaryRegPays = monthlySummarySqM * sqMPrice / regPayPrice;
                    restSquare = (arrRest.Last() - monthlySummarySqM) / 0.995;
                    arrRest.Add(restSquare);
                    usingPayment = restSquare * 0.005;
                    arrUsingPayment.Add(usingPayment);
                    paymentSqM = monthlySummarySqM - usingPayment;
                    arrPaymentSqM.Add(paymentSqM);
                    paymentRegPays = paymentSqM * sqMPrice / regPayPrice;
                    accumSquare = paymentSqM + arrAccum.Last();
                    arrAccum.Add(accumSquare);
                    indRent = 0.0;
                    rating = 0.0;

                    AddRowToTable(bigTable, num, paymentSqM, paymentRegPays, accumSquare, restSquare, rating, indRent, usingPayment, monthlySummarySqM, monthlySummaryRegPays);
                }

                //Строка последнего платежа
                num++;
                monthlySummarySqM = arrRest.Last();
                monthlySummaryRegPays = monthlySummarySqM * sqMPrice / regPayPrice;
                restSquare = (arrRest.Last() - monthlySummarySqM) / 0.995;
                arrRest.Add(restSquare);
                usingPayment = restSquare * 0.005;
                arrUsingPayment.Add(usingPayment);
                paymentSqM = monthlySummarySqM - usingPayment;
                arrPaymentSqM.Add(paymentSqM);
                paymentRegPays = paymentSqM * sqMPrice / regPayPrice;
                accumSquare = paymentSqM + arrAccum.Last();
                arrAccum.Add(accumSquare);
                indRent = 0.0;
                rating = 0.0;

                AddRowToTable(bigTable, num, paymentSqM, paymentRegPays, accumSquare, restSquare, rating, indRent, usingPayment, monthlySummarySqM, monthlySummaryRegPays);

                //Полное время финансирования (на печать)
                fullTime = num.ToString();
                //Предполагаемый период выкупа (на печать)
                buyoutTime = arrUsingPayment.Count().ToString();

                //Строка итогов
                double sumOfMonthlyPaymentsSqM = firstPaymentSqM + monthlyPaymentSqM * (num - 2) + monthlySummarySqM;
                
                dr = bigTable.NewRow();
                dr["№"] = "";
                dr["Дата платежа"] = "ИТОГО:";
                dr["Паевой взнос, кв.м."] = arrPaymentSqM.Sum().ToString("0.0000");
                dr["Паевой взнос, уч.п."] = "";
                dr["Накопленная площадь, кв.м."] = "";
                dr["Невыкупленный остаток, кв.м."] = "";
                dr["Рейтинг"] = "";
                dr["Индивидуальная рента, кв.м."] = arrIndRent.Sum().ToString("0.0000");
                dr["Взнос за владение и пользование, кв.м."] = arrUsingPayment.Sum().ToString("0.0000");
                dr["Итого платежей в месяц, кв.м."] = (sumOfMonthlyPaymentsSqM).ToString("0.0000");
                dr["Итого платежей в месяц, уч.п."] = "";
                bigTable.Rows.Add(dr);

                //Строка членского взноса
                dr = bigTable.NewRow();
                dr["№"] = "";
                dr["Дата платежа"] = "Кроме того,";
                dr["Паевой взнос, кв.м."] = "членский взнос";
                dr["Паевой взнос, уч.п."] = "(при заселении)";
                dr["Накопленная площадь, кв.м."] = "";
                dr["Невыкупленный остаток, кв.м."] = "";
                dr["Рейтинг"] = "";
                dr["Индивидуальная рента, кв.м."] = "";
                dr["Взнос за владение и пользование, кв.м."] = "";
                dr["Итого платежей в месяц, кв.м."] = settlPaymentNum.ToString("0.0000");
                dr["Итого платежей в месяц, уч.п."] = "";
                bigTable.Rows.Add(dr);

                //Строка "Всего"
                dr = bigTable.NewRow();
                dr["№"] = "";
                dr["Дата платежа"] = "ВСЕГО:";
                dr["Паевой взнос, кв.м."] = "";
                dr["Паевой взнос, уч.п."] = "";
                dr["Накопленная площадь, кв.м."] = "";
                dr["Невыкупленный остаток, кв.м."] = "";
                dr["Рейтинг"] = "";
                dr["Индивидуальная рента, кв.м."] = "";
                dr["Взнос за владение и пользование, кв.м."] = "";
                dr["Итого платежей в месяц, кв.м."] = (sumOfMonthlyPaymentsSqM + settlPaymentNum).ToString("0.0000");
                dr["Итого платежей в месяц, уч.п."] = "";
                bigTable.Rows.Add(dr);

                //Привязка источника данных таблицы
                bindingSourceBigPlan.DataSource = bigTable;
                dataGridViewBigPlan.DataSource = bindingSourceBigPlan;
                for (int i = 0; i < dataGridViewBigPlan.Columns.Count; i++)
                {
                    dataGridViewBigPlan.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

            catch
            {
                MessageBox.Show("Проверьте введённые данные", "Ошибка расчёта", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Рассчитывает рейтинг в заданный момент
        /// </summary>
        /// <param name="arrAccum">Список накопленной площади в кв.м.</param>
        /// <param name="rest">Невыкупленный остаток в данный момент в кв.м.</param>
        /// <param name="rent">Индивидуальная рента в данный момент в кв.м.</param>
        /// <param name="monthlyPay">Платёж в месяц в кв.м.</param>
        /// <returns></returns>
        private double CalcRating(List<double> arrAccum, double rest, double rent, double monthlyPay)
        {
            double rating;      //Текущий рейтинг
            List<double> arrRest = new List<double>();   //Массив невыкупленной площади
            int i = 0;

            arrRest.Add((rest - rent - monthlyPay) / 0.995);
            while (rest > 0)
            {
                rest = (arrRest[i] - monthlyPay) / 0.995;
                arrRest.Add(rest);
                i++;
            }

            rating = arrAccum.Sum() / arrRest.Sum();

            return rating;
        }

        /// <summary>
        /// Добавляет строку в таблицу плана (тип ячеек- String)
        /// </summary>
        /// <param name="dt">Таблица, куда добавляется строка</param>
        /// <param name="num">Порядковый номер строки</param>
        /// <param name="paymentSqM">Паевой взнос в кв.м.</param>
        /// <param name="paymentRegPays">Паевой взнос в уч.п.</param>
        /// <param name="accumSquare">Накопленная площадь в кв.м.</param>
        /// <param name="restSquare">Невыкупленная площадь в кв.м.</param>
        /// <param name="rating">Рейтинг</param>
        /// <param name="indRent">Индивидуальная рента в кв.м.</param>
        /// <param name="usingPayment">Взнос за владение и пользование в кв.м.</param>
        /// <param name="monthlySummarySqM">Платёж за месяц в кв.м.</param>
        /// <param name="monthlySummaryRegPays">Платёж за месяц в уч.п.</param>
        private void AddRowToTable( DataTable dt, int num, double paymentSqM, double paymentRegPays, double accumSquare,
                                    double restSquare, double rating, double indRent, double usingPayment,
                                    double monthlySummarySqM, double monthlySummaryRegPays)
        {
            DataRow dr = dt.NewRow();
            dr["№"] = Convert.ToString(num);
            dr["Дата платежа"] = System.DateTime.Today.AddMonths(num - 1).ToShortDateString();
            dr["Паевой взнос, кв.м."] = paymentSqM.ToString("0.0000");
            dr["Паевой взнос, уч.п."] = paymentRegPays.ToString("0.0000");
            dr["Накопленная площадь, кв.м."] = accumSquare.ToString("0.0000");
            dr["Невыкупленный остаток, кв.м."] = restSquare.ToString("0.0000");
            if (rating != 0.0) dr["Рейтинг"] = rating.ToString("0.0000");
            else dr["Рейтинг"] = "";
            if (indRent != 0.0) dr["Индивидуальная рента, кв.м."] = indRent.ToString("0.0000");
            else dr["Индивидуальная рента, кв.м."] = "";
            if (usingPayment != 0.0) dr["Взнос за владение и пользование, кв.м."] = usingPayment.ToString("0.0000");
            else dr["Взнос за владение и пользование, кв.м."] = "";
            dr["Итого платежей в месяц, кв.м."] = monthlySummarySqM.ToString("0.0000");
            dr["Итого платежей в месяц, уч.п."] = monthlySummaryRegPays.ToString("0.0000");
            dt.Rows.Add(dr);
        }

        //Обработчики элементов формы

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            string price_str = textBoxPrice.Text;
            try
            {
                ParseStringToDouble(price_str);
                textBoxPrice.BackColor = Color.White;
                CalcSmallPlan();
            }
            catch
            {
                textBoxPrice.BackColor = Color.Orange;
                if (price_str == "") textBoxPrice.BackColor = Color.White;
            }
        }

        private void textBoxSquare_TextChanged(object sender, EventArgs e)
        {
            string square_str = textBoxSquare.Text;
            try
            {
                ParseStringToDouble(square_str);
                textBoxSquare.BackColor = Color.White;
                CalcSmallPlan();
            }
            catch
            {
                textBoxSquare.BackColor = Color.Orange;
                if (square_str == "") textBoxSquare.BackColor = Color.White;
            }
        }

        private void textBoxRegPayPrice_TextChanged(object sender, EventArgs e)
        {
            string regPayPrice_str = textBoxRegPayPrice.Text;

            buttonChangeRegPayPriceInFile.Visible = true;
            try
            {
                ParseStringToDouble(regPayPrice_str);
                textBoxRegPayPrice.BackColor = Color.White;
                CalcSmallPlan();
            }
            catch
            {
                textBoxRegPayPrice.BackColor = Color.Orange;
                if (regPayPrice_str == "") textBoxRegPayPrice.BackColor = Color.White;
            }
        }

        private void textBoxMonthlyPaymentRegPays_TextChanged(object sender, EventArgs e)
        {
            string monthlyPaymentRegPays_str = textBoxMonthlyPaymentRegPays.Text;
            try
            {
                ParseStringToDouble(monthlyPaymentRegPays_str);
                textBoxMonthlyPaymentRegPays.BackColor = Color.White;
                CalcSmallPlan();
            }
            catch
            {
                textBoxMonthlyPaymentRegPays.BackColor = Color.Orange;
                if (monthlyPaymentRegPays_str == "") textBoxMonthlyPaymentRegPays.BackColor = Color.White;
            }
        }

        private void textBoxFirstPayment_TextChanged(object sender, EventArgs e)
        {
            string firstPayment_str = textBoxFirstPayment.Text;
            try
            {
                ParseStringToDouble(firstPayment_str);
                textBoxFirstPayment.BackColor = Color.White;
                CalcSmallPlan();
            }
            catch
            {
                textBoxFirstPayment.BackColor = Color.Orange;
                if (firstPayment_str == "") textBoxFirstPayment.BackColor = Color.White;
            }
        }

        private void buttonCalcBigPlan_Click(object sender, EventArgs e)
        {
            CalcBigPlan();
        }
        
        private void textBoxMonthlyPaymentRubles_TextChanged(object sender, EventArgs e)
        {
            string strMonthlyPaymentRubles = textBoxMonthlyPaymentRubles.Text;

            try
            {
                double monthlyPaymentRubles_dbl = ParseStringToDouble(strMonthlyPaymentRubles);
                double regPayPrice_dbl = ParseStringToDouble(textBoxRegPayPrice.Text);

                textBoxFirstPayment.BackColor = Color.White;
                textBoxMonthlyPaymentRegPays.Text = Convert.ToString(monthlyPaymentRubles_dbl / regPayPrice_dbl);
            }
            catch
            {
                textBoxFirstPayment.BackColor = Color.Orange;
                if (strMonthlyPaymentRubles == "") textBoxFirstPayment.BackColor = Color.White;
            }
        }

        private void textBoxSettlementRating_TextChanged(object sender, EventArgs e)
        {
            string settlementRating_str = textBoxSettlementRating.Text;
            try
            {
                double settlRating = ParseStringToDouble(settlementRating_str);
                textBoxSettlementRating.BackColor = Color.White;
                if ((settlRating < 0) || (settlRating > 1)) throw new Exception();
                buttonCalcBigPlan.Enabled = true;
            }
            catch
            {
                buttonCalcBigPlan.Enabled = false;
                textBoxSettlementRating.BackColor = Color.Orange;
                if (settlementRating_str == "") textBoxSettlementRating.BackColor = Color.White;
            }
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Таблица плана накопления
            DataTable bigTable = new DataTable();
            bigTable.Columns.Add(new DataColumn("№", typeof(string)));
            bigTable.Columns.Add(new DataColumn("Дата платежа", typeof(string)));
            bigTable.Columns.Add(new DataColumn("Паевой взнос, кв.м.", typeof(string)));
            bigTable.Columns.Add(new DataColumn("Паевой взнос, уч.п.", typeof(string)));
            bigTable.Columns.Add(new DataColumn("Накопленная площадь, кв.м.", typeof(string)));
            bigTable.Columns.Add(new DataColumn("Невыкупленный остаток, кв.м.", typeof(string)));
            bigTable.Columns.Add(new DataColumn("Рейтинг", typeof(string)));
            bigTable.Columns.Add(new DataColumn("Индивидуальная рента, кв.м.", typeof(string)));
            bigTable.Columns.Add(new DataColumn("Взнос за владение и пользование, кв.м.", typeof(string)));
            bigTable.Columns.Add(new DataColumn("Итого платежей в месяц, кв.м.", typeof(string)));
            bigTable.Columns.Add(new DataColumn("Итого платежей в месяц, уч.п.", typeof(string)));

            foreach (DataGridViewRow dgv in dataGridViewBigPlan.Rows)
            {
                bigTable.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value, dgv.Cells[9].Value, dgv.Cells[10].Value);
            }

            //Таблица малого плана
            DataTable smallTable = new DataTable();
            smallTable.Columns.Add(new DataColumn("Номер пункта", typeof(string)));
            smallTable.Columns.Add(new DataColumn("Название характеристики", typeof(string)));
            smallTable.Columns.Add(new DataColumn("Рублей", typeof(string)));
            smallTable.Columns.Add(new DataColumn("Кв. метров", typeof(string)));
            smallTable.Columns.Add(new DataColumn("Уч. паёв", typeof(string)));

            smallTable.Rows.Add("5.", "Стоимость учётного пая", textBoxRegPayPrice.Text, "", "");
            smallTable.Rows.Add("6.", "Стоимость квадратного метра", textBoxSqMPrice.Text, "", "");

            int paragraphNum = 7;       //Номер пункта в отчёте
            foreach (DataGridViewRow dgv in dataGridViewSmallPlanParams.Rows)
            {
                smallTable.Rows.Add(paragraphNum.ToString(), dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value);
                paragraphNum++;
            }

            smallTable.Rows.Add("11.", "Вступительный взнос", settlementPayment, "", "");

            //Список строк для шапки отчёта
            List<string> listDescribe = new List<string>();

            listDescribe.Add(textBoxName.Text);
            listDescribe.Add(textBoxLocation.Text);
            listDescribe.Add(textBoxPosAtStreet.Text);
            listDescribe.Add(textBoxRoomsNum.Text);
            listDescribe.Add(textBoxSquareRange.Text);
            listDescribe.Add(textBoxBuildingType.Text);
            listDescribe.Add(textBoxSquare.Text);
            listDescribe.Add(textBoxPrice.Text);
            listDescribe.Add((ParseStringToDouble(textBoxPrice.Text) / ParseStringToDouble(textBoxSquare.Text)).ToString("0.00"));
            listDescribe.Add(fullTime);
            listDescribe.Add(accumTime);
            listDescribe.Add(buyoutTime);
            listDescribe.Add(incomeTime);
            listDescribe.Add(textBoxContractNum.Text);

            Form fTest = new FormTestReport(bigTable, smallTable, listDescribe);
            fTest.Show();

            Cursor.Current = Cursors.Arrow;
        }

        private void textBoxRegPayPrice_Leave(object sender, EventArgs e)
        {
            buttonChangeRegPayPriceInFile.Visible = false;
        }

        private void buttonChangeRegPayPriceInFile_MouseDown(object sender, MouseEventArgs e)
        {
            StreamWriter sw = new StreamWriter("Стоимость учётного пая.txt");
            sw.Write(textBoxRegPayPrice.Text);
            sw.Close();
            MessageBox.Show("Изменения внесены успешно", "OK", MessageBoxButtons.OK);
        }

        private void checkBoxDiffPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDiffPayment.Checked)
            {
                Form formNewPayment = new FormNewPayment();
                formNewPayment.Owner = this;
                formNewPayment.ShowDialog();
            }
        }
    }
}