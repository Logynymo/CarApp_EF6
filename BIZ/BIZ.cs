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

namespace BIZ
{
    public class BIZ : ClassNotify
    {
        private Car selectedCar;
        private ObservableCollection<Car> cars;
        private ObservableCollection<Brand> brands;
        private ObservableCollection<Propellant> propellants;

        public BIZ()
        {
            GetData(1);
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
        /// <param name="mode">1 for all data. 2 for just cars.</param>
        public void GetData(int mode)
        {
            if (mode == 1)
            {
                using (CarContext ccx = new CarContext())
                {
                    Cars = new ObservableCollection<Car>(ccx.Cars.ToList() as List<Car>);
                    Brands = new ObservableCollection<Brand>(ccx.Brands.ToList() as List<Brand>);
                    Propellants = new ObservableCollection<Propellant>(ccx.Propellants.ToList() as List<Propellant>);
                }
            }
            else if(mode == 2)
            {
                using (CarContext ccx = new CarContext())
                {
                    Cars = new ObservableCollection<Car>(ccx.Cars.ToList() as List<Car>);
                }
            }
        }


    }
}
