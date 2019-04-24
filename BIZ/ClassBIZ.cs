using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPO;
using IO;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Windows;
using System.Data.Entity.Migrations;

namespace BIZ
{
    public class ClassBIZ : ClassNotify
    {
        // Private fields
        private Car selectedCar;
        private ObservableCollection<Car> cars;
        private ObservableCollection<Brand> brands;
        private ObservableCollection<Propellant> propellants;

        /// <summary>
        /// Default constructor.
        /// Calls methods to get data from database.
        /// </summary>
        public ClassBIZ()
        {
            GetData(true);
            SelectedCar = new Car();
        }

        // Public properties
        // SelectedCar represents the car the user currently has selected
        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                if (value != selectedCar)
                {
                    selectedCar = value;
                    Notify("SelectedCar");
                }
            }
        }

        public ObservableCollection<Brand> Brands
        {
            get { return brands; }
            set
            {
                if (value != brands)
                {
                    brands = value;
                    Notify("Brands");
                }
            }
        }

        public ObservableCollection<Car> Cars
        {
            get { return cars; }
            set
            {
                if (value != cars)
                {
                    cars = value;
                    Notify("Cars");
                }
            }
        }

        public ObservableCollection<Propellant> Propellants
        {
            get { return propellants; }
            set
            {
                if (value != propellants)
                {
                    propellants = value;
                    Notify("Propellants");
                }
            }
        }

        /// <summary>
        /// Creates a database if it doesn't exist
        /// </summary>
        public void MakeDataBase()
        {
            try
            {
                using (CarContext ccx = new CarContext())
                {
                    ccx.Database.CreateIfNotExists();
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var t in ex.EntityValidationErrors)
                {
                    MessageBox.Show(t.ValidationErrors.First().ErrorMessage);
                }
            }
        }
        
        /// <summary>
        /// Gets data from Data Base.
        /// </summary>
        /// <param name="mode">True to get all data related to cars.</param>
        public void GetData(bool getAll)
        {
            if (getAll)
            {
                using (CarContext ccx = new CarContext())
                {
                    Cars = new ObservableCollection<Car>(ccx.Cars
                        .Include("Brand")
                        .Include("Propellant")
                        .ToList() as List<Car>);
                    Brands = new ObservableCollection<Brand>(ccx.Brands.ToList() as List<Brand>);
                    Propellants = new ObservableCollection<Propellant>(ccx.Propellants.ToList() as List<Propellant>);
                }
            }
            else
            {
                using (CarContext ccx = new CarContext())
                {
                    Cars = new ObservableCollection<Car>(ccx.Cars
                        .Include("Brand")
                        .Include("Propellant")
                        .ToList() as List<Car>);
                }
            }
        }

        /// <summary>
        /// Saves the new car or changes to existing car in Data Base.
        /// </summary>
        /// <param name="isEdited">True if editing an existing car, otherwise false.</param>
        public void SaveCar()
        {
            using (CarContext ccx = new CarContext())
            {
                ccx.Brands.Attach(SelectedCar.Brand);
                ccx.Propellants.Attach(SelectedCar.Propellant);
                ccx.Cars.AddOrUpdate(SelectedCar);
                ccx.SaveChanges();
            }
            if (SelectedCar.CarId == 0)
            {
                SelectedCar = new Car();
            }
            GetData(false);
        }

        /// <summary>
        /// Deletes the car the user has selected.
        /// </summary>
        public void DeleteCar()
        {
            using (CarContext ccx = new CarContext())
            {
                // Attaches SelectedCar to the DbSet
                ccx.Cars.Attach(SelectedCar);
                ccx.Cars.Remove(SelectedCar);
                ccx.SaveChanges();
            }
            SelectedCar = new Car();
            GetData(false);
        }
    }
}
