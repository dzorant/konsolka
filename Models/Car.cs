using System;
using System.Collections.Generic;

namespace konsolowe.Models
{
    public abstract class Car  //abstract - bo sam "Car" nie mam sensu a musi miec zdefiniowane dane typy samochodu np. supercar, truck
    {
        public double Speed { get; protected set; } = 100;  //protected - tak jak private ale można modyfikowac w momencie dziedziczenia
        public double Acceleration { get; protected set; } = 10;
        public void Start()
        {
            Console.WriteLine("Turning on the engine....");
            System.Console.WriteLine($"Running at : {Speed.ToString()} km/h.");
        }

        public void Stop()
        {
            System.Console.WriteLine("Stopping the car ... ");
        }

        public virtual void Accelerate() // virtual - zeby mozna bylo rozszezac metode => override
        {
            System.Console.WriteLine("Accelerating . .. ");
            Speed += Acceleration;
            System.Console.WriteLine($"Running at : {Speed} km/h. ");
        }

        public abstract void Boost();
    }

    public class Truck : Car
    {
        public override void Accelerate()
        {
           System.Console.WriteLine("Accelerating a truck . .. ");
            base.Accelerate();
        }

        public override void Boost()
        {
             System.Console.WriteLine("Boosting . .. ");
            Speed += 40;
            System.Console.WriteLine($"Running at : {Speed} km/h. ");
        }
    }

    public class SportCar : Car
    {
        public override void Accelerate()
        {
            System.Console.WriteLine("Accelerating a sport car . .. ");
            base.Accelerate();
        }

        public override void Boost()
        {
             System.Console.WriteLine("Boosting . .. ");
            Speed += 100;
            System.Console.WriteLine($"Running at : {Speed} km/h. ");
        }

        public void DisplayInfo()
        {
            System.Console.WriteLine("Sport car.");
        }
    }

    public class Race
    {
        public void Begin()
        {
            Car sportCar = new SportCar();
            Car truck = new Truck();

            List<Car> cars = new List<Car>
            {
                sportCar, truck
            };

            foreach(Car car in cars)
            {
                car.Start();
                car.Accelerate();
                car.Boost();
            }
        }

        public void Casting() // Rzutowanie 
        {
            Car sportCar = new SportCar();
            Car truck = new Truck();

            
        }
    }


}