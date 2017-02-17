using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Romi4.Classes
{
    class InputData
    {
        private double regPayPrice;
        private double firstPayment;
        private double square;
        private double price;
        private double monthlyPaymentRegPays;
        private double sqMPrice;
        private double fundsNeed;

        public InputData()
        {

        }

        public string RegPayPrice
        {
            get
            {
                return regPayPrice.ToString();
            }
            set
            {
                try
                {
                    regPayPrice = ParseStringToDouble(value);
                }
                catch
                {
                    return;
                }
            }
        }

        public string FirstPayment
        {
            get
            {
                return firstPayment.ToString();
            }
            set
            {
                try
                {
                    firstPayment = ParseStringToDouble(value);
                }
                catch
                {
                    return;
                }
            }
        }

        public string Square
        {
            get
            {
                return square.ToString();
            }
            set
            {
                try
                {
                    square = ParseStringToDouble(value);
                }
                catch
                {
                    return;
                }
            }
        }

        public string Price
        {
            get
            {
                return price.ToString();
            }
            set
            {
                try
                {
                    price = ParseStringToDouble(value);
                }
                catch
                {
                    return;
                }
            }
        }

        public string MonthlyPaymentRegPays
        {
            get
            {
                return monthlyPaymentRegPays.ToString();
            }
            set
            {
                try
                {
                    monthlyPaymentRegPays = ParseStringToDouble(value);
                }
                catch
                {
                    return;
                }
            }
        }

        public string SqMPrice
        {
            get
            {
                return sqMPrice.ToString();
            }
        }

        public string FundsNeed
        {
            get
            {
                return fundsNeed.ToString();
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
    }
}
