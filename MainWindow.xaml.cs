using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prime_numbers_handler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /**
         * Check if passed number is prime number
         */
        private void isPrimeNumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (numberTextBox.Text.Length == 0 || Convert.ToInt32(numberTextBox.Text) <= 0)
            {
                return;
            }

            try
            {
                int checkedNumber = Convert.ToInt32(numberTextBox.Text);
                switch (Helper.isPrimeNumber(checkedNumber))
                {
                    case true:
                        {
                            resultTextBlock.Text = $"The number {checkedNumber} is prime number.";
                        }
                        break;
                    case false:
                        {
                            resultTextBlock.Text = $"The number {checkedNumber} is not prime number.";
                        }
                        break;
                }
            }
            catch (Exception)
            {
                resultTextBlock.Text = "Oops, something went wrong... Please enter a valid number.";
            }
                
        }

        /**
         * Spread passed number to prime factor numbers
         */
        private void spreadPrimeFactorsButton_Click(object sender, RoutedEventArgs e)
        {
            if (numberTextBox.Text.Length == 0)
            {
                return;
            }

            try
            {
                int checkNumber = Convert.ToInt32(numberTextBox.Text);
            }
            catch (Exception)
            {
                resultTextBlock.Text = "Oops, something went wrong... Please enter a valid number.";
                return;
            }

            int checkedNumber = Convert.ToInt32(numberTextBox.Text);

            if (Helper.isPrimeNumber(checkedNumber))
            {
                resultTextBlock.Text = "The given number is a prime number. It cannot be broken down into prime factors.";
                return;
            }


            List<int> primeFactorNumbersList = Helper.spreadPrimeFactors(checkedNumber);

            string resultString = $"The prime factors of {checkedNumber} are: ";

            for (int i = 0; i < primeFactorNumbersList.Count; i++)
            {
                if (i + 1 == primeFactorNumbersList.Count)
                {
                    resultString += $"{primeFactorNumbersList[i]}.";
                }
                else
                {
                    resultString += $"{primeFactorNumbersList[i]}, ";
                }
            }

            resultTextBlock.Text = resultString;

        }

        private void primeNumbersFromNumberButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Helper.isCorrectRange(numberTextBox.Text) == false)
                {
                    resultTextBlock.Text = "The specified range of numbers was invalid.";
                    return;
                }
            }
            catch (Exception)
            {
                resultTextBlock.Text = "Oops, something went wrong... Please enter a valid number.";
                return;
            }

            List<int> rangeFromToList = Helper.getRangeFromString(numberTextBox.Text);
            List<int> primeNumbersFromRange = Helper.getPrimeNumbersFromRange(numberTextBox.Text);

            int rangeFrom = rangeFromToList[0];
            int rangeTo = rangeFromToList[1];

            string resultString = $"The prime numbers between {rangeFrom} - {rangeTo} are: ";

            for (int i = 0; i < primeNumbersFromRange.Count; i++)
            {
                if (i + 1 == primeNumbersFromRange.Count)
                {
                    resultString += $"{primeNumbersFromRange[i]}.";
                }
                else
                {
                    resultString += $"{primeNumbersFromRange[i]}, ";
                }
            }

            resultTextBlock.Text = resultString;
        }

        private void drawPrimeNumberFromRangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Helper.isCorrectRange(numberTextBox.Text) == false)
                {
                    resultTextBlock.Text = "The specified range of numbers was invalid.";
                    return;
                }
            }
            catch (Exception)
            {
                resultTextBlock.Text = "Oops, something went wrong... Please enter a valid range.";
                return;
            }

            List<int> rangeFromToList = Helper.getRangeFromString(numberTextBox.Text);
            List<int> primeNumbersFromRange = Helper.getPrimeNumbersFromRange(numberTextBox.Text);

            int rangeFrom = rangeFromToList[0];
            int rangeTo = rangeFromToList[1];

            string resultString = $"The drawn prime number between {rangeFrom} - {rangeTo} is ";
            Random random = new Random();
            int randomIndex = random.Next(primeNumbersFromRange.Count);
            resultString += $"{primeNumbersFromRange[randomIndex]}.";

            resultTextBlock.Text = resultString;
        }
    }
}
