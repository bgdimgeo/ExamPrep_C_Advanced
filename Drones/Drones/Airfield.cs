using System;
using System.Collections.Generic;
using System.Linq;


namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;
        private string name;
        private int capacity;
        private double landingStrip;
        private int count;

        public Airfield( string name, int capacity, double landingStrip)
        {
            this.name = name;
            this.capacity = capacity;
            this.landingStrip = landingStrip;
            this.drones = new List<Drone>();
        }

        public int Count { get { return this.count; } }
        public string AddDrone(Drone drone)
        {
            if (count != capacity)
            {
                if (drone.Name != null || drone.Brand != null)
                {
                    if (drone.Range >= 5 && drone.Range <= 15)
                    {
                        this.drones.Add(drone);
                        return $"Successfully added {drone.Name} to the airfield.";
                    }
                    else
                    {
                        return "Invalid drone.";
                    }
                }
                else
                {
                    return "Invalid drone.";
                }
            }
            else
            {
                return "Airfield is full.";
            }

        }

        public bool RemoveDrone(string name)
        {
            if( this.drones.Find(x => x.Name == name) != null)
            { 

                this.drones.Remove(this.drones.Find(x => x.Name == name));
                return true;
            }
            else
            {
                return false;
            }
        }
        public int RemoveDroneByBrand(string brand)
        {

            foreach (var kvp in this.drones.Where(x => x.Brand == brand)) 
            {
                count++;
            }

            this.drones.RemoveAll(x => x.Brand == brand);
         
            return count;
        }


        public Drone FlyDrone(string name)
        {

            if (this.drones.Find(x => x.Name == name) != null)
            {
                this.drones.Find(x => x.Name == name).Available = false;
                return this.drones.Find(x => x.Name == name);
            }
            else
            {
                return null;
            }
        }
        public List<Drone> FlyDronesByRange(int range) 
        {
            List<Drone> dronesRange = new List<Drone>();
            foreach (var kvp in this.drones) 
            {
                if (kvp.Range >= range) 
                {
                    kvp.Available = false;
                    dronesRange.Add(kvp);

                }
            }
            
            return dronesRange;
        }

        public string Report() 
        {
            string returnString = string.Empty;

            returnString = $"Drones available at {this.name}:";
            foreach (var kvp in this.drones.Where(x => x.Available == true)) 
            {
                returnString = returnString + $"{Environment.NewLine}{kvp.ToString()}";
            }
            return returnString;
        }
    }
}
