using Animals;
using CagedItems;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Utilities;
using Zoos;
using Timer = System.Timers.Timer;

namespace ZooScenario
{
    /// <summary>
    /// Interaction logic for CageWindow.xaml
    /// </summary>
    public partial class CageWindow : Window
    {
        /// <summary>
        /// The animal in the cage window.
        /// </summary>
        private IEnumerable<Animal> animals;

        /// <summary>
        /// The cage for the cage window.
        /// </summary>
        private Cage cage;

        /// <summary>
        /// The timer for the cage.
        /// </summary>
        private Timer redrawTimer;

        /// <summary>
        /// Initializes a new instance of the CageWindow.
        /// </summary>
        public CageWindow(Cage cage)
        {
            this.cage = cage;

            // New timer with a 100 millisecond interval.
            this.redrawTimer = new Timer(100);

            // Attch the method to the timer elapsed event.
            this.redrawTimer.Elapsed += this.RedrawHandler;

            this.redrawTimer.Start();

            InitializeComponent();
        }

        /// <summary>
        /// The method that draws all of the animals.
        /// </summary>
        private void DrawAllItems()
        {
            this.cageGrid.Children.Clear();

            // Draw each item in the cages collection of items.
            foreach(ICageable i in cage.CagedItems)
            {
                this.DrawItem(i);
            }
        }

        /// <summary>
        /// Draws the animal where it's coordinates specifiy.
        /// </summary>
        private void DrawItem(ICageable item)
        {
            // Gets the name and type of the animal.
            //string resourceKey = item.GetType().Name;

            // Ternary operator. If the condition is true, name is baby, otherwise, adult.
            // resourceKey += (animal.Age == 0) ? "Baby" : "Adult";

            // Create a new Canvas. Use the resource key to grab the correct animal inmage.
            // Canvas canvas = Application.Current.Resources[resourceKey] as Canvas;

            // Create a new view box.
            Viewbox viewBox = GetViewBox(800, 400, item.XPosition, item.YPosition, item.ResourceKey, item.DisplaySize);

            // Set the view box allignment.
            viewBox.HorizontalAlignment = HorizontalAlignment.Left;
            viewBox.VerticalAlignment = VerticalAlignment.Top;

            // If the animal is moving to the left
            if (item.XDirection == HorizontalDirection.Left)
            {
                // Set the origin point of the transformation to the middle of the viewbox.
                viewBox.RenderTransformOrigin = new Point(0.5, 0.5);

                // Initialize a ScaleTransform instance.
                ScaleTransform flipTransform = new ScaleTransform();

                // Flip the viewbox horizontally so the animal faces to the left
                flipTransform.ScaleX = -1;

                // Apply the ScaleTransform to the viewbox
                viewBox.RenderTransform = flipTransform;
            }

            // Attach the view box to the cage grid.
            this.cageGrid.Children.Add(viewBox);
        }

        /// <summary>
        /// Gets the view box container.
        /// </summary>
        /// <param name="maxXPosition"> The allowed left/right positions.</param>
        /// <param name="maxYPosition"> The allowed up/down position.</param>
        /// <param name="xPosition"> The left/right position.</param>
        /// <param name="yPosition"> The up/down position.</param>
        /// <param name="canvas"> The blank space where the image will be displayed.</param>
        /// <returns></returns>
        private Viewbox GetViewBox(double maxXPosition, double maxYPosition, int xPosition, int yPosition, string resourceKey, double displayScale)
        {
            // Create a new Canvas. Use the resource key to grab the correct animal inmage.
            Canvas canvas = Application.Current.Resources[resourceKey] as Canvas;

            // Finished viewbox.
            Viewbox finishedViewBox = new Viewbox();

            // Gets image ratio.
            double imageRatio = canvas.Width / canvas.Height;

            // Sets width to a percent of the window size based on it's scale.
            double itemWidth = this.cageGrid.ActualWidth * 0.2 * displayScale;

            // Sets the height to the ratio of the width.
            double itemHeight = itemWidth / imageRatio;

            // Sets the width of the viewbox to the size of the canvas.
            finishedViewBox.Width = itemWidth;
            finishedViewBox.Height = itemHeight;

            // Sets the animals location on the screen.
            double xPercent = (this.cageGrid.ActualWidth - itemWidth) / maxXPosition;
            double yPercent = (this.cageGrid.ActualHeight - itemHeight) / maxYPosition;

            int posX = Convert.ToInt32(xPosition * xPercent);
            int posY = Convert.ToInt32(yPosition * yPercent);

            finishedViewBox.Margin = new Thickness(posX, posY, 0, 0);

            // Adds the canvas to the view box.
            finishedViewBox.Child = canvas;

            // Returns the finished viewbox.
            return finishedViewBox;
        }

        /// <summary>
        /// Draws the animal into the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drawAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            this.DrawAllItems();
        }

        /// <summary>
        /// The redraw timer for the cage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RedrawHandler(object sender, ElapsedEventArgs e)
        {
            // Prents threading issues betwen the timer and drawing.
            this.Dispatcher.Invoke(new Action(delegate ()
            {
                this.DrawAllItems();
            }));
        }

        /// <summary>
        /// When the cage window is loaded, the following things will intilialize.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DrawAllItems();
        }
    }
}
