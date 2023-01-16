using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Races2.Models
{
    public class Country
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CountryName { get; set; }
        public string Address { get; set; }
        public string CountryDetails
        {
            get
            {
                return CountryName + " "+Address;} }
        [OneToMany]
        public List<RaceList> RaceLists { get; set; }

    }

}
