﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();

                string model = inputInfo[0];
                int engineSpeed = int.Parse(inputInfo[1]);
                int enginePower = int.Parse(inputInfo[2]);
                int cargoWeight = int.Parse(inputInfo[3]);
                string cargoType = inputInfo[4];


                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[4];

                int counter = 0;
                for (int j = 5; j < inputInfo.Length; j += 2)
                {

                    double tirePressure = double.Parse(inputInfo[j]);
                    int tireAge = int.Parse(inputInfo[j + 1]);

                    Tire tire = new Tire(tireAge, tirePressure);
                    tires[counter++] = tire;
                }

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                var fragileCars = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(p => p.Pressure < 1)).ToList();
                foreach (var car in fragileCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flamable")
            {
                var flamableCars = cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250).ToList();
                foreach (var car in flamableCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
