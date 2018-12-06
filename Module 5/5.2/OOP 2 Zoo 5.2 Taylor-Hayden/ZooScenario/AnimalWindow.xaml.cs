using Animals;
using People;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ZooScenario
{
    /// <summary>
    /// Interaction logic for AnimalWindow.xaml
    /// </summary>
    public partial class AnimalWindow : Window
    {

        /// <summary>
        /// The animal in the animal window.
        /// </summary>
        private Animal animal;

        /// <summary>
        /// The window used to make animal.s
        /// </summary>
        public AnimalWindow(Animal animal)
        {
            // Set the field to the passed in parameter value.
            this.animal = animal;

            InitializeComponent();
        }

        /// <summary>
        /// Creates things when the window is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Sets the name text box to the name of the animal.
            this.nameTextBox.Text = this.animal.Name;

            // Grabs the list of genders and fills the gender combo box.
            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(Gender));

            // Sets the age text box to the animals age.
            this.ageTextBox.Text = this.animal.Age.ToString();

            // Sets the weight text box to animals weight.
            this.weightTextBox.Text = this.animal.Weight.ToString();

            // Sets the content to true if the animal is pregnant, and no if it's not.
            this.makePregnantButton.Content = true ? true : false;
        }

        /// <summary>
        /// When you click the ok button, this happens.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            // When you hit enter, it closes the Animal window, and adds the animal to the animal list box.
            this.DialogResult = true;
        }

        /// <summary>
        /// Sets the animals name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Sets the animal's name unless its out of the limits.
            try
            {
                // Sets the animals name to the text entered in the text box.
                animal.Name = nameTextBox.Text;
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the animals age using the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Sets the animals age unless its out of the limits.
            try
            {
                // Sets the animals age, parses the string into an int.
                animal.Age = int.Parse(ageTextBox.Text);
            }
            catch(IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Sets the weight of the animal using the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void weightTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Sets the animal weight unless its out of the limits.
            try
            {
                // Sets the animals weight, parses the string into a double.
                animal.Weight = double.Parse(weightTextBox.Text);
            }
            catch(IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Sets the gender of the animal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void genderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Sets the gender of the animal using the gender combo box.
            animal.Gender = (Gender)genderComboBox.SelectedItem;

            // If the gender of the animal is male it cannt get pregnant.
            if(animal.Gender == Gender.Female)
            {
                makePregnantButton.IsEnabled = true;
            }
            else
            {
                // Disable the button.
                makePregnantButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Makes the animal pregnant.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void makePregnantButton_Click(object sender, RoutedEventArgs e)
        {
            animal.MakePregnant();

            // Changes the label from No, to yes.
            pregnancyStatusLabel.Content = "Yes";
        }
    }
}
