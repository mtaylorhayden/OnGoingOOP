using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Scratchpad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Bob Brooks.
        /// </summary>
        private Person bob = new Person { FirstName = "Bob", LastName = "Brooks", Age = 25, Salary = 40000m };

        /// <summary>
        /// Frank Fernandez.
        /// </summary>
        private Person frank = new Person { FirstName = "Frank", LastName = "Fernandez", Age = 32, Salary = 50000m };

        /// <summary>
        /// The Washington Post.
        /// </summary>
        private Publisher washingtonPost = new Publisher();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The method that will be attached to the delegate.
        /// </summary>
        /// <param name="radius">The radius of the circle (in inches).</param>
        /// <returns>The area of the circle (in square inches).</returns>
        public double CalculateArea(int radius)
        {
            // pi*r2
            return 3.14 * radius * radius;
        }

        /// <summary>
        /// Calls a method directly.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void directMethodWithDoubleReturnButton_Click(object sender, RoutedEventArgs e)
        {
            // Call method.
            double area = this.CalculateArea(42);

            // Call method again.
            area = this.CalculateArea(17);
        }

        /// <summary>
        /// Calls a method via a delegate.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void delegateButton_Click(object sender, RoutedEventArgs e)
        {
            // Define a variable of type "delegate" and set it.
            // This does not call the method, it simply plugs it in.. You can use it later..
            CalculateAreaDelegate calculateArea = this.CalculateArea;

            // Call delegate.
            double area = calculateArea(42);

            // Call delegate again.
            area = calculateArea(17); 
        }

        /// <summary>
        /// Calls an anonymous method via a delegate.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void delegateWithAnonymousMethodButton_Click(object sender, RoutedEventArgs e)
        {
            // Define a variable of type "delegate" and set to a value (an on-the-fly method).

            // Call delegate.

            // Call delegate again.
        }

        /// <summary>
        /// Calls a lambda expression via a delegate.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void delegateWithLambdaButton_Click(object sender, RoutedEventArgs e)
        {
            // Define a variable of type "delegate" and set to a value (an on-the-fly method).

            // Call delegate.

            // Call delegate again.
        }

        /// <summary>
        /// Calls a method via a Func.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void funcButton_Click(object sender, RoutedEventArgs e)
        {
            // Define a variable of type "delegate" and set it.
            Func<int, double> calculateArea = this.CalculateArea;

            // Call delegate.
            double area = calculateArea(42);

            // Call delegate again.
            area = calculateArea(17);
        }

        /// <summary>
        /// Calls an anonymous method via a Func.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void funcWithAnonymousMethodButton_Click(object sender, RoutedEventArgs e)
        {
            // Define a variable of type "delegate" and set to a value (an on-the-fly method).

            // Call delegate.

            // Call delegate again.
        }

        /// <summary>
        /// Calls a lambda via a Func.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void funcWithLambdaButton_Click(object sender, RoutedEventArgs e)
        {
            // Define a variable of type "delegate" and set to a value (an on-the-fly method).

            // Call delegate.

            // Call delegate again.
        }

        /// <summary>
        /// Writes a line of text to the console.
        /// </summary>
        /// <param name="s">The text to write.</param>
        private void WriteToConsole(string s)
        {
            Console.WriteLine(s);
        }

        /// <summary>
        /// Calls a method via an Action.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void directMethodWithoutReturnButton_Click(object sender, RoutedEventArgs e)
        {
            // Call method directly.
            this.WriteToConsole("Hello, world!");

            this.WriteToConsole("Goodbye.");
        }

        /// <summary>
        /// Calls an anonymous method via an Action.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void actionWithMethodButton_Click(object sender, RoutedEventArgs e)
        {
            // Plugs in the method into the myAction variable.
            // Define an action and set it.
            Action<string> myAction = this.WriteToConsole;
            myAction += this.WriteToConsole;
            myAction += this.WriteToConsole;

            // Call the action.
            myAction("Hello world.");
            myAction("Goodbye.");
        }

        /// <summary>
        /// Calls an anonymous method via an Action.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void actionWithAnonymousMethodButton_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Calls a lambda via an Action.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void actionWithLambdaButton_Click(object sender, RoutedEventArgs e)
        {
            // Define an action (like delegate without a return) and assign a lambda to the action.

            // Call lambda via the action.

            // Call lambda again.
        }

        /// <summary>
        /// Tests whether or not a string is longer than five characters.
        /// </summary>
        /// <param name="s">The string to test.</param>
        /// <returns>A value indicating whether or not the specified string is longer than five characters.</returns>
        private bool IsLongerThan5(string s)
        {
            return s.Length > 5;
        }

        /// <summary>
        /// Calls a method with a boolean result.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void directMethodWithBoolReturnButton_Click(object sender, RoutedEventArgs e)
        {
            bool isMatch = this.IsLongerThan5("Hello");

            isMatch = this.IsLongerThan5("Goodbye");
        }

        /// <summary>
        /// Calls a method using a predicate.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void predicateWithMethodButton_Click(object sender, RoutedEventArgs e)
        {
            // Define and set a predicate.
            // String in, bool out.
            // Func<string, bool> isLongString = this.IsLongerThan5;

            // Predicates automatically return a bool. This code is that same as 244.
            Predicate<string> isLongString = this.IsLongerThan5;

            // Call predicate.
            bool isMatch = isLongString("Hello");

            // Call again.
            isMatch = isLongString("Goodbye.");
        }

        /// <summary>
        /// Calls an anonymous method using a predicate.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void predicateWithAnonymousMethodButton_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Calls a lambda expression using a predicate.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void predicateWithLambdaButton_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Find items in a list using a predicate.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void findPredicate1Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> strings = new List<string>()
                {
                    "car",
                    "van",
                    "jukebox",
                    "beat",
                    "airplane",
                    "top",
                    "carrot",
                    "stick"
                };

            // option 1 - pred with method (variable)

            // option 2 - pred with method directly

            // option 3 - pred with anonymous method

            // option 3 - pred with anonymous method (collapsed)

            // option 4 = pred with lambda
        }

        /// <summary>
        /// Find more items in a list using a predicate.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void findPredicate2Button_Click(object sender, RoutedEventArgs e)
        {
            List<Person> customers = new List<Person>()
            {
                new Person() { Age = 15, LastName = "Johnson", Salary = 1000m },
                new Person() { Age = 16, LastName = "Gritz", Salary = 20000m },
                new Person() { Age = 15, LastName = "Zink", Salary = 15000m },
                new Person() { Age = 16, LastName = "Smith", Salary = 22000m },
                new Person() { Age = 15, LastName = "Zastrow", Salary = 40000m },
                new Person() { Age = 22, LastName = "Fritz", Salary = 10000m }
            };
        }

        /// <summary>
        /// The first extra button.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void extra1Button_Click(object sender, RoutedEventArgs e)
        {
            this.extra3Button.Click += this.extra2Button_Click;
        }

        /// <summary>
        /// A second extra button.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void extra2Button_Click(object sender, RoutedEventArgs e)
        {
            // Define a variable of type "delegate" and set to a value (an on-the-fly method).

            // Call delegate.
        }

        /// <summary>
        /// A third extra button.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void extra3Button_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Read the news using "polling".
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void paperDirectMethodButton_Click(object sender, RoutedEventArgs e)
        {
            this.washingtonPost.UpdateNews("Calvin Gives All Students an A!");

            this.bob.ReadNews(this.washingtonPost.News);
            this.bob.ReadNews(this.washingtonPost.News);
            this.bob.ReadNews(this.washingtonPost.News);
            this.bob.ReadNews(this.washingtonPost.News);
            this.frank.ReadNews(this.washingtonPost.News);

            this.washingtonPost.UpdateNews("Calvin fails all students!");

            this.bob.ReadNews(this.washingtonPost.News);
            this.bob.ReadNews(this.washingtonPost.News);
            this.bob.ReadNews(this.washingtonPost.News);
            this.bob.ReadNews(this.washingtonPost.News);
            this.frank.ReadNews(this.washingtonPost.News);
        }

        /// <summary>
        /// Notify subscribers of the news using the observer pattern.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void paperObserverPatternButton_Click(object sender, RoutedEventArgs e)
        {
            this.washingtonPost.RegisterObserver(this.bob);
            this.washingtonPost.RegisterObserver(this.frank);

            this.washingtonPost.UpdateNews("Calvin Gives All Students an A!");
        }

        /// <summary>
        /// Notify subscribers of the news using delegates (actions).
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void paperActionButton_Click(object sender, RoutedEventArgs e)
        {
            this.washingtonPost.BroadcastNewsAction += this.bob.ReadNews;
            this.washingtonPost.BroadcastNewsAction += this.frank.ReadNews;
        }
    }
}