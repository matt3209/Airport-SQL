using System;
using System.Collections.Generic;
using System.Text;

/*
 * Interface allows controller to not know database. 
 * Creator: Matt Heider
 */

namespace Lab3
{
    public interface IDatabase
    {
      
        public void Add(string origin, string destination, string identifier, string passengers);
        public void Update(string origin, string destination, string identifier, string passengers);
        public void Destroy(string identifier);

        public string Display();
    }
}
