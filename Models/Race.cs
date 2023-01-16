using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace F1Races2.Models
{ 
public class Race
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    [MaxLength(150), Unique]
    public string Name { get; set; }
    [MaxLength(250), Unique]

    public string Description { get; set; }
    public string Image { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }



}

}


