using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1 {

    public class Person {
        public string Name { get; set; }
        public string Age { get; set; }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window {
        public ObservableCollection<string> Persons { get; set; }
        Person person = new Person();

        public MainWindow() {

            InitializeComponent();
            Persons = new ObservableCollection<string>();
            DataContext = person;
            listBox.ItemsSource = Persons;
        }

        private void addButton_Click(object sender, RoutedEventArgs e) {

            try {
                if (!String.IsNullOrEmpty(nameText.Text) && !String.IsNullOrEmpty(ageText.Text)) {
                    Int32.Parse(person.Age);
                    Persons.Add(string.Format("{0} | {1}", person.Name, person.Age));
                    nameText.Clear();
                    ageText.Clear();
                    image.Source = null;
                } 
                else {
                    MessageBox.Show("Please enter your credentials");
                }
            } 
            catch(FormatException) {
                MessageBox.Show("Age must be a number!");
            }
            
        }

        private void AddImage_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select a picture";
            open.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (open.ShowDialog() == true) {
                image.Source = new BitmapImage(new Uri(open.FileName));
            }
        }
    }
}