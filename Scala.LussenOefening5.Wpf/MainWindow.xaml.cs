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

namespace Scala.LussenOefening5.Wpf
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartUp();
        }
        private void StartUp()
        {
            cmbBaseNumber.Items.Clear();
            cmbExponent.Items.Clear();
            cmbFibonacci.Items.Clear();
            cmbPrimNumber.Items.Clear();
            for (int r = 1; r <= 20; r++)
            {
                cmbBaseNumber.Items.Add(r);
                cmbExponent.Items.Add(r);
            }
            for (int r = 3; r <= 50; r++)
            {
                cmbFibonacci.Items.Add(r);
            }
            for (int r = 1; r <= 50; r++)
            {
                cmbPrimNumber.Items.Add(r);
            }
        }
        private void cmbBaseNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Exponentiation();
        }

        private void cmbExponent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Exponentiation();
        }
        private void Exponentiation()
        {
            lstPower.Items.Clear();
            if (cmbBaseNumber.SelectedItem == null) return;
            if (cmbExponent.SelectedItem == null) return;
            int baseNumber = int.Parse(cmbBaseNumber.SelectedItem.ToString());
            int upperLimit = int.Parse(cmbExponent.SelectedItem.ToString());
            for (int r = 1; r <= upperLimit; r++)
            {
                double result = Math.Pow(baseNumber, r);
                lstPower.Items.Add($"{baseNumber}^{r} = {result}");
            }
        }
        private void cmbFibonacci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int count = int.Parse(cmbFibonacci.SelectedItem.ToString());
            MakeFibonacci(count);
        }
        private void MakeFibonacci(int aantal)
        {
            lstFibonacci.Items.Clear();
            lstFibonacci.Items.Add(0);
            lstFibonacci.Items.Add(1);
            long secondLast = 0;
            long last = 1;
            long newOne;
            for (int r = 3; r <= aantal; r++)
            {
                newOne = last + secondLast;
                lstFibonacci.Items.Add(newOne);
                secondLast = last;
                last = newOne;
            }
        }
        private void cmbPrimNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int requestedNumber = int.Parse(cmbPrimNumber.SelectedItem.ToString());
            MakePrimeNumbers(requestedNumber);
        }
        private void MakePrimeNumbers(int requestedNumber)
        {
            lstPrimeNumber.Items.Clear();
            lstPrimeNumber.Items.Add(2);
            int numberOfPrimes = 1;
            int counter = 3;  // afspraak : 0 en 1 zijn GEEN priemgetallen, 2 WEL, de rest berekenen we
            while (numberOfPrimes < requestedNumber)
            {
                int remainder = counter % 2;
                int division = counter / 2;
                if (remainder == 0)
                {
                    counter++;
                }
                else
                {
                    bool ispriem = true;
                    for (int r = division; r > 1; r--)
                    {
                        if (counter % r == 0)
                        {
                            ispriem = false;
                            counter++;
                            break;
                        }
                    }
                    if (ispriem)
                    {
                        numberOfPrimes++;
                        lstPrimeNumber.Items.Add(counter);
                        counter++;
                    }
                }
            }
        }
    }
}
