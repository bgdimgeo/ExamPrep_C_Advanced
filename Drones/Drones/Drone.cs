﻿using System;

namespace Drones
{
    public class Drone
    {
        private string name;
        private string brand;
        private int range;
        private bool available = true;

        public Drone(string name, string brand, int range )
        {
            this.name = name;
            this.brand = brand;
            this.range = range;
        }
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Brand { get { return this.brand; } set { this.brand = value; } }
        public int Range { get { return this.range; } set { this.range = value; } }
        public bool Available { get { return this.available; } set { this.available = value; } }

        public override string ToString()
        {
            return $"Drone: {Name}" +
                $"{Environment.NewLine}Manufactured by: {Brand}" +
                $"{Environment.NewLine}Range: {Range} kilometers";
        }
    }
}
