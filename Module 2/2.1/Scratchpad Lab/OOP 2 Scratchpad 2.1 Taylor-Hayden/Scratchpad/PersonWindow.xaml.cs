using People;
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
using System.Windows.Shapes;

namespace Scratchpad
{
    /// <summary>
    /// Interaction logic for PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        Person person;

        public PersonWindow(Person person)
        {
            this.person = person;

            InitializeComponent();

            this.ageTextBox.Text = this.person.Age.ToString();
            this.firstNameTextBox.Text = this.person.FirstName;
        }

        private void ageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            this.person.Age = int.Parse(this.ageTextBox.Text);
        }

        private void firstNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            this.person.FirstName = this.firstNameTextBox.Text;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }


    }
}
