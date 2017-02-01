using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
        }

        private void urlName_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            TextBox urlName = (TextBox) e.Source;

            if (!urlName.Text.Equals("") && !urlHref.Text.Equals(""))
                setEnableButtons(true);
            else 
                setEnableButtons(false);
                
        }

        private void setEnableButtons(bool state)
        {
            save.IsEnabled = state;
            saveAndGo.IsEnabled = state;
        }

        private void urlHref_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox urlHref = (TextBox)e.Source;
            
            if (!urlName.Text.Equals("") && !urlHref.Text.Equals(""))
            {
                if (Uri.CheckHostName(urlHref.Text)==UriHostNameType.Unknown)
                {
                    setEnableButtons(true);
                    urlHrefError.Content = "";
                }
                else
                {
                    setEnableButtons(false);
                    urlHrefError.Content = "Неправильная ссылка.";
                }
            }                
            else  
                setEnableButtons(false);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            saveActiveURL();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            URLGroup.onCloseEditWindow.Invoke(true);
        }

        private void saveActiveURL()
        {
            URL oldURL = URLGroup.findURL(url => url.isActive);
            URLGroup.updateURL(oldURL, new URL(urlName.Text, urlHref.Text));
            setEnableButtons(false);
        }

        private void saveAndGo_Click(object sender, RoutedEventArgs e)
        {
            saveActiveURL();
            URLGroup.onSaveAndGo.Invoke();
        }
    }
}
