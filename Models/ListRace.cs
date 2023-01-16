using SQLite;
using SQLiteNetExtensions.Attributes;
namespace F1Races2.Models
{
    public class ListRace
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(RaceList))]
        public int RaceListID { get; set; }
        public int RaceID { get; set; }
    }
}
