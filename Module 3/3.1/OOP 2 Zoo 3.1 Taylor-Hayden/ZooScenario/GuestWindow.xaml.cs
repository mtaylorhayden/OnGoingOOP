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

namespace ZooScenario
{
    /// <summary>
    /// Interaction logic for GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
    {

        /// <summary>
        /// The guest for the guest window.
        /// </summary>
        private Guest guest;

        /// <summary>
        /// The window to contorl the guests.
        /// </summary>
        public GuestWindow(Guest guest)
        {
            this.guest = guest;

            InitializeComponent();
        }

        /// <summary>
        /// Allows the user to change the age of the guest.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Set the value as the guests age.
            try
            {
                guest.Age = int.Parse(this.ageTextBox.Text);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Allows you to select the gender of the guest.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void genderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Sets the gender to the selected value.
            guest.Gender = (Gender)genderComboBox.SelectedItem;
        }

        /// <summary>
        /// Allows you to enter a name for the guest.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Set the value as the guests name.
            try
            {
                guest.Name = this.nameTextBox.Text;
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the windows dialog true.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }



        /// <summary>
        /// Allows you to select the color of the guest's wallet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void walletColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Sets the wallet color to the selected value.
            guest.Wallet.WalletColor = (WalletColor)walletColorComboBox.SelectedItem;
        }

        /// <summary>
        /// Creates things when the window is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Sets the name text box to the name of the animal.
            this.nameTextBox.Text = this.guest.Name;

            // Grabs the list of genders and fills the gender combo box.
            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(Gender));

            // Sets the age text box to the animals age.
            this.ageTextBox.Text = this.guest.Age.ToString();

            // Grabs the list of wallet colors and fill the combo box.
            this.walletColorComboBox.ItemsSource = Enum.GetValues(typeof(WalletColor));

            // Changes the label to the money balance.
            this.moneyBalanceLabel.Content = guest.Wallet.MoneyBalance;

            // Revist, adding values to the combos list box.
            this.moneyAmountComboBox.Items.Add(1);
            this.moneyAmountComboBox.Items.Add(5);
            this.moneyAmountComboBox.Items.Add(10);
            this.moneyAmountComboBox.Items.Add(20);

            // Sets the account balance label to the guests checking account money balance.
            this.accountBalanceLabel.Content = guest.CheckingAccount.MoneyBalance;

            // Revist, adding values to combo box array..? Adds values to the combo box.
            this.accountComboBox.Items.Add(1);
            this.accountComboBox.Items.Add(5);
            this.accountComboBox.Items.Add(10);
            this.accountComboBox.Items.Add(20);
        }

        /// <summary>
        /// Adds money to the money balance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            // Store the combo box amount in a string variable.
            string amount = moneyAmountComboBox.Text;

            // Add the combo box text to the money balance using a parse.
            guest.Wallet.AddMoney(decimal.Parse(amount));

            // Set the label content to the current wallet money balance.
            this.moneyBalanceLabel.Content = guest.Wallet.MoneyBalance;
        }

        /// <summary>
        /// Subtracts money from the money balance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void subtractMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            // Store the combo box amount in a string variable.
            string amount = moneyAmountComboBox.Text;

            // Subtract the combo box text to the money balance using a parse.
            guest.Wallet.RemoveMoney(decimal.Parse(amount));

            // Set the label content to the current wallet money balance.
            this.moneyBalanceLabel.Content = guest.Wallet.MoneyBalance;
        }

        /// <summary>
        /// Adds money to the guests account.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addAccountButton_Click(object sender, RoutedEventArgs e)
        {
            // Store the combo box amount in a string variable.
            string accountAmount = accountComboBox.Text;

            // Adds the combo text box to the money balance using a parse.
            guest.CheckingAccount.AddMoney(decimal.Parse(accountAmount));

            // Set the label content to the current checking account money balance.
            accountBalanceLabel.Content = guest.CheckingAccount.MoneyBalance;
        }

        /// <summary>
        /// Subtracts money from the guests account.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void subtractAccountButton_Click(object sender, RoutedEventArgs e)
        {
            // Store the combo box amount in a string variable.
            string accountAmount = accountComboBox.Text;

            // Subtracts the checking account money balance by the combo text box amount. 
            guest.CheckingAccount.RemoveMoney(decimal.Parse(accountAmount));

            // Set the label content to the current checking account money balance.
            accountBalanceLabel.Content = guest.CheckingAccount.MoneyBalance;
        }
    }
}
