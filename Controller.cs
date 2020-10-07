using System.Collections.Generic;

/*
 * Keeps database seperate from ui. Uses an interface to keep seperate. 
 * Creator: Matt Heider
 */


namespace Lab3

{
    public class Controller
    {
        IDatabase DB;  // Controller unaffected by changes to Database 

        public Controller(IDatabase DB)
        {
            this.DB = DB;
        }

        public void Add(string origin, string destination, string identifier, string passengers)
        {
            DB.Add(origin, destination, identifier, passengers);
        }

        public void Update(string origin, string destination, string identifier, string passengers)
        {
            DB.Update(origin, destination, identifier, passengers);
        }

        public void Destroy(string identifier)
        {
            DB.Destroy(identifier);
        }

        public string Display()
        {
            return DB.Display();
        }

    }

}
