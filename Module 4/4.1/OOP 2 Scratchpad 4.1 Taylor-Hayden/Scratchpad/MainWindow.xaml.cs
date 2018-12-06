using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Xml.Serialization;
using Airports;
using People;

namespace Scratchpad
{
    /// <summary>
    /// Contains interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The Dallas/Fort Worth Airport airport.
        /// </summary>
        private Airport dfw = new Airport();

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            this.peopleListBox.ItemsSource = this.dfw.People;

            this.dfw.AddPerson(11, "Suzi");

            this.dfw.AddPerson(23, "Sam");

        }


        private void addPersonButton_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();

            Window window = new PersonWindow(person);

            if (window.ShowDialog() == true)
            {

                this.dfw.AddPerson(person);

                this.peopleListBox.ItemsSource = null;

                this.peopleListBox.ItemsSource = this.dfw.People;
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new object called StreamWriter.
            // Writer is done once the using function is done.
            //using (StreamWriter writer = new StreamWriter(@"C:\Test\File.txt"))
            //{
            //    writer.WriteLine("Sample text 1");
            //    writer.WriteLine("Sample text 2");
            //    writer.WriteLine("Sample text 3");
            //}
            // File type for binary desrializer is .dat
            //using (Stream stream = File.Create(@"C:\Test\DFW.dat"))

            using (Stream stream = File.Create(@"C:\Test\DFW.xml"))
            {
                // Binary Serializer
                //new BinaryFormatter().Serialize(stream, this.dfw);

                // XML serializer.
                new XmlSerializer(typeof(Airport)).Serialize(stream, this.dfw);
            }

        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            //using (StreamReader reader = new StreamReader(@"C:\Test\File.txt"))
            //{
            //    string text = reader.ReadToEnd();
            //}
            // File type for binary desrializer is .dat
            // using (Stream stream = File.OpenRead(@"C:\Test\DFW.dat"))

            // File type for xml is xml...
            using (Stream stream = File.OpenRead(@"C:\Test\DFW.xml"))

            {
                // Binary deserializer.
                //this.dfw = new BinaryFormatter().Deserialize(stream) as Airport;

                this.dfw = new XmlSerializer(typeof(Airport)).Deserialize(stream) as Airport;
            }

            this.peopleListBox.ItemsSource = null;

            this.peopleListBox.ItemsSource = this.dfw.People;
        }
    }
}