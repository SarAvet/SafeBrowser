using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для ExitWindow.xaml
    /// </summary>
    public partial class ExitWindow : Window
    {
        public ExitWindow()
        {
            InitializeComponent();
            oldPas.IsEnabled = Browser.Password.Exist();
            button.IsEnabled = Browser.Password.Exist();
            passwordBox.IsEnabled = Browser.Password.Exist();

            if (Browser.Password.Exist())
                pasChange.Content = "Изменить";
            else
                pasChange.Content = "Установить";  
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            logOut();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key.Equals(Key.Enter))
                logOut();
        }

        private void logOut()
        {

            if (Browser.Password.GetHash(passwordBox.Password).ToLower() == Browser.Password.Get().ToLower())
                Owner.Close();
            else
                passwordBox.Focus();
        }


        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            if (setPasPane.IsVisible)
            {
                Height = 180;
                setPasPane.Visibility = Visibility.Hidden;
                
            }
            else
            {
                setPasPane.Visibility = Visibility.Visible;
                Height += setPasPane.ActualHeight;
            }
        }
        

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (password.Password.Length < 6)
                setPas.IsEnabled = false;
        }

        private void passwordRep_PasswordChanged(object sender, RoutedEventArgs e)
        {
             setPas.IsEnabled = password.Password.Equals(passwordRep.Password);
        }

        private void setPas_Click(object sender, RoutedEventArgs e)
        {
            Browser.Password.Set(password.Password.Trim());
            passwordBox.IsEnabled = true;
            oldPas.IsEnabled = true;
            string action = "установлен";
            if (Browser.Password.Exist())
                action = "изменен";
            MessageBox.Show("Пароль успешно "+action+".");
        }

        private void oldPas_PasswordChanged(object sender, RoutedEventArgs e)
        {
             setPas.IsEnabled = Browser.Password.GetHash(oldPas.Password) == Browser.Password.Get() &&
                                    password.Password.Equals(passwordRep.Password) &&
                                        password.Password.Length >= 6;
        }
    }
}
