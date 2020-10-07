using System;

/*
 * Constructor for flight object. Along with getters and setters.
 */

namespace Lab3
{
    public class Flight :  IComparable<Flight>
    {
        public string origin;
        public string destination;
        public string identifier;
        public string passengers;

        public Flight(string Origin, string Destination, string Identifier, string Passengers)
        {
            this.origin = Origin;
            this.destination = Destination;
            this.identifier = Identifier;
            this.passengers = Passengers;
        }

        public string GetOrigin()
        {
            return origin;
        }

        public string GetDestination()
        {
            return destination;
        }

        public string GetIdentifier()
        {
            return identifier;
        }

        public string GetPassengers()
        {
            return passengers;
        }

        public void SetOrigin(string origin)
        {
            this.origin = origin;
        }

        public void SetDestination(string destination)
        {
            this.destination = destination;
        }

        public void SetPassengers(string passengers)
        {
            this.passengers = passengers;
        }

        public int CompareTo(Flight obj)
        {
            return this.identifier.CompareTo(obj.identifier);
        }

    }
}
