using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1Races2.Models;
namespace F1Races2.Data
{
    public class RaceDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public RaceDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Race>().Wait();
        }
        public Task<List<Race>> GetRacesAsync()
        {
            return _database.Table<Race>().ToListAsync();
        }
        public Task<Race> GetRaceAsync(int id)
        {
            return _database.Table<Race>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveRaceAsync(Race slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteRaceAsync(Race slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}