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
                            resultTextBlock.Text = $"Liczba {checkedNumber} jest liczbą pierwszą";
                        }
                        break;
                    case false:
                        {
                            resultTextBlock.Text = $"Liczba {checkedNumber} nie jest liczbą pierwszą";
                        }
                        break;
                }
            }
            catch (Exception)
            {
                resultTextBlock.Text = "Coś poszło nie tak... Proszę podać poprawną liczbę.";
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
                resultTextBlock.Text = "Coś poszło nie tak... Proszę podać poprawną liczbę.";
                return;
            }

            int checkedNumber = Convert.ToInt32(numberTextBox.Text);

            if (Helper.isPrimeNumber(checkedNumber))
            {
                resultTextBlock.Text = "Podana liczba jest liczbą pierwszą. Nie da się jej rozłożyć na czynniki pierwsze.";
                return;
            }


            List<int> primeFactorNumbersList = Helper.spreadPrimeFactors(checkedNumber);

            string resultString = $"Czynniki pierwsze liczby {checkedNumber} to: ";

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
                    resultTextBlock.Text = "Podany zakres liczb był niepoprawny.";
                    return;
                }
            }
            catch (Exception)
            {
                resultTextBlock.Text = "Coś poszło nie tak... Proszę podać poprawny zakres.";
                return;
            }

            List<int> rangeFromToList = Helper.getRangeFromString(numberTextBox.Text);
            List<int> primeNumbersFromRange = Helper.getPrimeNumbersFromRange(numberTextBox.Text);

            int rangeFrom = rangeFromToList[0];
            int rangeTo = rangeFromToList[1];

            string resultString = $"Liczby pierwsze z przedziału {rangeFrom} - {rangeTo}: ";

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
                    resultTextBlock.Text = "Podany zakres liczb był niepoprawny.";
                    return;
                }
            }
            catch (Exception)
            {
                resultTextBlock.Text = "Coś poszło nie tak... Proszę podać poprawny zakres.";
                return;
            }

            List<int> rangeFromToList = Helper.getRangeFromString(numberTextBox.Text);
            List<int> primeNumbersFromRange = Helper.getPrimeNumbersFromRange(numberTextBox.Text);

            int rangeFrom = rangeFromToList[0];
            int rangeTo = rangeFromToList[1];

            string resultString = $"Wylosowana liczba pierwsza z przedziału {rangeFrom} - {rangeTo} to ";
            Random random = new Random();
            int randomIndex = random.Next(primeNumbersFromRange.Count);
            resultString += $"{primeNumbersFromRange[randomIndex]}.";

            resultTextBlock.Text = resultString;
        }
    }
}
