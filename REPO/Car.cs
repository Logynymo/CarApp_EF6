using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO
{
    public class Car : ClassNotify, ICloneable
    {
        private int carId;
        private Brand brand;
        private string model;
        private Propellant propellant;
        private string licensePlate;

        public Car()
        {
            CarId = 0;
        }

        public Car(Car toCopy)
        {
            CarId = toCopy.CarId;
            Brand = toCopy.Brand;
            Model = toCopy.Model;
            Propellant = toCopy.Propellant;
            LicensePlate = toCopy.LicensePlate;
        }

        public int CarId
        {
            get { return carId; }
            set
            {
                if (value != carId)
                {
                    carId = value;
                    Notify("CarId");
                }
            }
        }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand Brand
        {
            get { return brand; }
            set
            {
                if (value != brand)
                {
                    brand = value;
                    if (brand != null)
                    {
                        BrandId = brand.BrandId;
                    }
                    Notify("Brand");
                }
            }
        }

        public string Model
        {
            get { return model; }
            set
            {
                if (value != model)
                {
                    model = value;
                    Notify("Model");
                }
            }
        }

        [ForeignKey("Propellant")]
        public int PropellantId { get; set; }
        public Propellant Propellant
        {
            get { return propellant; }
            set
            {
                if (value != propellant)
                {
                    propellant = value;
                    if (propellant != null)
                    {
                        PropellantId = propellant.PropellantId;
                    }
                    Notify("Propellant");
                }
            }
        }

        public string LicensePlate
        {
            get { return licensePlate; }
            set
            {
                if (value != licensePlate)
                {
                    licensePlate = value;
                    Notify("LicensePlate");
                }
            }
        }

        public object Clone()
        {
            return new Car(this);
        }
    }
}
