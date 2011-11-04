using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ComboCheckBox
{
    public partial class MainPage : UserControl, INotifyPropertyChanged
    {

        public ObservableCollection<CheckItem> List { get; set; }


        public MainPage()
        {
            InitializeComponent();


            List = new ObservableCollection<CheckItem>();

            for (int i = 0; i < 10; i++)
            {
                var item = new CheckItem() { Text = "Item" + i.ToString(), IsChecked = false };
                item.PropertyChanged += (sd, args) => { NotifyPropertyChanged("List"); };
                List.Add(item);
            }


            
            
            

            this.DataContext = this;


        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var checkedItems = List.Where(i => i.IsChecked == true);

            checkedItems.ToList().ForEach(i => MessageBox.Show(i.Text));
        }

    }



    public class CheckItem : INotifyPropertyChanged
    {
        public string Text { get; set; }

        private bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                NotifyPropertyChanged("IsChecked");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}



