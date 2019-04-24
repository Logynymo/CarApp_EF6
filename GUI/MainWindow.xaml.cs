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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BIZ;
using REPO;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Instances of ClassBIZ
        ClassBIZ CB = new ClassBIZ();
        ClassBIZ CBTemp = new ClassBIZ();

        /// <summary>
        /// Sets DataContext and calls MakeDataBase from ClassBIZ.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            gridMain.DataContext = CB;
            CB.MakeDataBase();
        }

        /// <summary>
        /// Enables and disables relevant objects on UI.
        /// Sets SelectedCar to a new instance of car if the Create button is pressed.
        /// Copies SelectedCar from CB to CBTemp.
        /// Sets DataContext of gridInfo to CBTemp.
        /// </summary>
        /// <param name="sender">Invoked Button as a generic object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void ButtonCreateCar_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Tag.ToString() == "1")
            {
                CB.SelectedCar = new Car();
            }

            buttonCreateCar.Visibility = Visibility.Collapsed;
            buttonEditCar.Visibility = Visibility.Collapsed;
            buttonDeleteCar.Visibility = Visibility.Collapsed;

            buttonSaveCar.Visibility = Visibility.Visible;
            buttonDiscardChanges.Visibility = Visibility.Visible;

            textBoxCarModel.IsEnabled = true;
            comboBoxCarBrand.IsEnabled = true;
            comboBoxCarPropellant.IsEnabled = true;
            textBoxCarLicensePlate.IsEnabled = true;
            listViewCars.IsEnabled = false;

            CopyCar(CBTemp, CB);
            gridInfo.DataContext = CBTemp;
        }

        /// <summary>
        /// Copies car from CBTemp to CB.
        /// Calls SaveCar() from CB.
        /// Sets DataContext of gridInfo to CB.
        /// Enables and disables relevant objects on UI.
        /// </summary>
        /// <param name="sender">Invoked Button as a generic object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void ButtonSaveCar_Click(object sender, RoutedEventArgs e)
        {
            CopyCar(CB, CBTemp);
            CB.SaveCar();
            gridInfo.DataContext = CB;

            buttonCreateCar.Visibility = Visibility.Visible;
            buttonEditCar.Visibility = Visibility.Visible;
            buttonDeleteCar.Visibility = Visibility.Visible;

            buttonSaveCar.Visibility = Visibility.Collapsed;
            buttonDiscardChanges.Visibility = Visibility.Collapsed;

            textBoxCarModel.IsEnabled = false;
            comboBoxCarBrand.IsEnabled = false;
            comboBoxCarPropellant.IsEnabled = false;
            textBoxCarLicensePlate.IsEnabled = false;
            listViewCars.IsEnabled = true;
        }

        /// <summary>
        /// Prompts the user with a YesNo MessageBox.
        /// If user hits yes, calls DeleteCar() from CB.
        /// </summary>
        /// <param name="sender">Invoked Button as a generic object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void ButtonDeleteCar_Click(object sender, RoutedEventArgs e)
        {
            if (CB.SelectedCar.CarId != 0)
            {
                if (MessageBox.Show("Vil du slette bilen fra databasen?", "Advarsel", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    CB.DeleteCar();
                }
            }
        }

        /// <summary>
        /// Sets DataContext of gridInfo to CB.
        /// Enables and disables relevant objects on UI.
        /// </summary>
        /// <param name="sender">Invoked Button as a generic object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void ButtonDiscardChanges_Click(object sender, RoutedEventArgs e)
        {
            gridInfo.DataContext = CB;

            buttonCreateCar.Visibility = Visibility.Visible;
            buttonEditCar.Visibility = Visibility.Visible;
            buttonDeleteCar.Visibility = Visibility.Visible;

            buttonSaveCar.Visibility = Visibility.Collapsed;
            buttonDiscardChanges.Visibility = Visibility.Collapsed;

            textBoxCarModel.IsEnabled = false;
            comboBoxCarBrand.IsEnabled = false;
            comboBoxCarPropellant.IsEnabled = false;
            textBoxCarLicensePlate.IsEnabled = false;
            listViewCars.IsEnabled = true;
        }

        /// <summary>
        /// Clones SelectedCar from one ClassBIZ to another.
        /// </summary>
        /// <param name="toBIZ">ClassBIZ to copy to.</param>
        /// <param name="fromBIZ">ClassBIZ to copy from.</param>
        private void CopyCar(ClassBIZ toBIZ, ClassBIZ fromBIZ)
        {
            toBIZ.SelectedCar = (Car)fromBIZ.SelectedCar.Clone();
        }

        /// <summary>
        /// Casts the selected item from listview to Car and sets
        /// SelectedCar to the selected item.
        /// If the CarId of SelectedCar is not 0, the Edit Car button is enabled.
        /// </summary>
        /// <param name="sender">Invoked ListView as a generic object</param>
        /// <param name="e">SelectionChangedEventArgs</param>
        private void ListViewCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.SelectedItem != null)
            {
                CB.SelectedCar = null;
                CB.SelectedCar = (Car)lv.SelectedItem;

                if (CB.SelectedCar.CarId != 0)
                {
                    buttonEditCar.IsEnabled = true;
                }

                else
                {
                    buttonEditCar.IsEnabled = false;
                }
            }
        }
    }
}
