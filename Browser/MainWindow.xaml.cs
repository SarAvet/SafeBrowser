using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Xml;
using System.Collections.Generic;
using System.Windows.Resources;
using System;
using System.Resources;
using Browser.Properties;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string MTemplate = "<?xml version=\"1.0\" encoding=\"utf-8\"?>"+
                                   "\r\n<URLGroup>"+
                                          "\r\n\t<URL href = \"\" name=\"Пример кнопки\" />" +
                                          "\r\n\t<URL href = \"http://vk.com\" name=\"VK\" />" +
                                   "\r\n</URLGroup>";
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                URLGroup.initURLs();
                addURLsInToolBar();
            }
            catch(FileNotFoundException e)
            {
                if(MessageBox.Show("Файл с разметкой ссылок не найден. Создать?", "Ошибка", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        File.WriteAllText(URLGroup.FileName, MTemplate);
                        URLGroup.initURLs();
                        addURLsInToolBar();
                    }
                    catch(IOException exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                } 
            }
            catch(XmlException e)
            {
                MessageBox.Show(e.Message);
            }
            
            URLGroup.onURLsUpdate += changeButtonName;
            URLGroup.onCloseEditWindow += setEnableToolBar;
            URLGroup.onSaveAndGo += browserNavigate;
        }
        
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (browser.CanGoBack)
                browser.GoBack();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (browser.CanGoForward)
                browser.GoForward();
            
        }
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {

                ExitWindow exit = new ExitWindow();
                exit.Show();
                exit.Owner = this;
            }

            if(e.Key == Key.F1 && URLGroup.isExists(url => url.isActive))
            {
                setEnableToolBar(false);

                URL active = URLGroup.findURL(url=>url.isActive);

                EditWindow edit = new EditWindow();
                edit.urlName.Text = active.Name;
                edit.urlHref.Text = active.Href;

                edit.Show();
                edit.Owner = this;
            }
        }

        public void addURLsInToolBar()
        {
             
            foreach(URL url in URLGroup.urls)
            {
                Button newButton = new Button();
                newButton.Content = url.Name;
                newButton.MinWidth = 30;
                newButton.ToolTip = url.Href;
                newButton.Cursor = Cursors.Hand;
                newButton.Click+=click;
                toolBar.Items.Add(newButton);
            }
        }

        public void click(object sender, RoutedEventArgs e)
        {
            Button source = (Button) e.Source;
            URL findURL = URLGroup.findURL(url => url.Name == source.Content.ToString());
            browser.Navigate(findURL.Href);
            URLGroup.setActive(findURL);

            if (!refresh.IsEnabled)
                refresh.IsEnabled = true;
        }
        
        private void changeButtonName(URL old, URL newURL)
        {
            ItemCollection itCol = toolBar.Items;
            
            foreach(object item in itCol)
            {
                if(item is Button)
                {
                    Button b = (Button)item;
                    if (b.Content!=null && b.Content.ToString() == old.Name)
                    {
                        Button but = (Button)toolBar.Items.GetItemAt(toolBar.Items.IndexOf(item));
                        but.Content = newURL.Name;
                        but.ToolTip = newURL.Href;
                        break;
                    }                    
                }
            }
        }
        
        private void setEnableToolBar(bool state)
        {
            toolBar.IsEnabled = state;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            browserNavigate();
        }

        private void browserNavigate()
        {
            URL activeUrl = URLGroup.findURL(url => url.isActive);
            browser.Navigate(activeUrl.Href);
        }
    }
}
