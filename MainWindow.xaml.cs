using System;
using System.Windows;
using System.Windows.Controls;

namespace LABA6
{
    public partial class MainWindow : Window
    {
        private double _currentNumber;
        private double _storedNumber;
        private string _currentOperation;
        private bool _isNewNumber = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var number = button.Content.ToString();

            if (_isNewNumber)
            {
                if (number == "0" && Display.Text == "0")
                    return;

                Display.Text = number == "0" ? "0" : number;
                _isNewNumber = false;
            }
            else
            {
                if (Display.Text == "0")
                    Display.Text = number;
                else
                    Display.Text += number;
            }

            if (!double.TryParse(Display.Text, out _currentNumber))
            {
                Display.Text = "Ошибка";
                _currentNumber = 0;
            }
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (_isNewNumber)
            {
                Display.Text = "0.";
                _isNewNumber = false;
                return;
            }

            if (!Display.Text.Contains("."))
            {
                Display.Text += ".";
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            _currentNumber = 0;
            _storedNumber = 0;
            _currentOperation = null;
            _isNewNumber = true;
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            if (!_isNewNumber)
            {
                Equals_Click(sender, e);
                _isNewNumber = true;
            }

            var button = (Button)sender;
            _currentOperation = button.Tag.ToString();
            _storedNumber = _currentNumber;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (_currentOperation == null) return;

            try
            {
                switch (_currentOperation)
                {
                    case "Add":
                        _currentNumber = _storedNumber + _currentNumber;
                        break;
                    case "Subtract":
                        _currentNumber = _storedNumber - _currentNumber;
                        break;
                    case "Multiply":
                        _currentNumber = _storedNumber * _currentNumber;
                        break;
                    case "Divide":
                        if (_currentNumber == 0) throw new DivideByZeroException();
                        _currentNumber = _storedNumber / _currentNumber;
                        break;
                }

                Display.Text = _currentNumber.ToString();
            }
            catch (DivideByZeroException)
            {
                Display.Text = "Ошибка: деление на 0";
            }
            catch (Exception)
            {
                Display.Text = "Ошибка вычисления";
            }
            finally
            {
                _isNewNumber = true;
            }
        }
    }
}