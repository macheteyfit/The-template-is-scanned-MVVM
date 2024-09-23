using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
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

namespace The_template_is_scanned_MVVM
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class PersonContext
    {
        public Person Person { get; set; }
        public ICommand ChangePerson { get; set; }
        public PersonContext()
        {
            Person = new Person()
            {
                Age = 30,
                Name = "John"
            };
            ChangePerson = new DelegateCommand(ChangePersonToJane);
        }
        public void ChangePersonToJane(object obj)
        {
            Person = new Person()
            {
                Age = 24,
                Name = "Jane"
            };
            OnPropertyChanged("Person");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }    

    public partial class MainWindow : Window
    {
        public ICommand MyCommand { get; set; }
        public MainWindow()
        {
            //PersonContext context = new PersonContext();
            InitializeComponent();
            MyCommand = new DelegateCommand(ShowMessage);
            //this.DataContext = this;
        }
        public void ShowMessage(Object obj)
        {
            if(obj is string) MessageBox.Show(obj as string);
        }
    }
}
