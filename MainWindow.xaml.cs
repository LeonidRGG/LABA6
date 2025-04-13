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
            if (_isNewNumber)
            {
                Display.Text = "";
                _isNewNumber = false;
            }

            var button = (Button)sender;
            Display.Text += button.Content.ToString();
            _currentNumber = double.Parse(Display.Text);
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
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
            var button = (Button)sender;
            _currentOperation = button.Tag.ToString();
            _storedNumber = _currentNumber;
            _isNewNumber = true;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (_currentOperation == "Add")
            {
                _currentNumber = _storedNumber + _currentNumber;
                Display.Text = _currentNumber.ToString();
                _isNewNumber = true;
            }
            else
            {
                Display.Text = "Выберите операцию";
            }
        }
    }
}