using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using F1Races2.Models;



namespace F1Races2.Data
{
    public class RaceListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public RaceListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<RaceList>().Wait();
            _database.CreateTableAsync<Race>().Wait();
            _database.CreateTableAsync<ListRace>().Wait();
            _database.CreateTableAsync<Country>().Wait();
        }

        public Task<int> SaveRaceAsync(Race race)
        {
            if (race.ID != 0)
            {
                return _database.UpdateAsync(race);
            }
            else
            {
                return _database.InsertAsync(race);
            }
        }
        public Task<int> DeleteRaceAsync(Race race)
        {
            return _database.DeleteAsync(race);
        }
        public Task<List<Race>> GetRacesAsync()
        {
            return _database.Table<Race>().ToListAsync();
        }

        public Task<List<RaceList>> GetRaceListsAsync()
        {
            return _database.Table<RaceList>().ToListAsync();
        }
        public Task<RaceList> GetRaceListAsync(int id)
        {
            return _database.Table<RaceList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveRaceListAsync(RaceList rlist)
        {
            if (rlist.ID != 0)
            {
                return _database.UpdateAsync(rlist);
            }
            else
            {
                return _database.InsertAsync(rlist);
            }
        }
        public Task<int> DeleteRaceListAsync(RaceList rlist)
        {
            return _database.DeleteAsync(rlist);
        }

        public Task<int> SaveListRaceAsync(ListRace listr)
        {
            if (listr.ID != 0)
            {
                return _database.UpdateAsync(listr);
            }
            else
            {
                return _database.InsertAsync(listr);
            }
        }
        public Task<List<Race>> GetListRacesAsync(int racelistid)
        {
            return _database.QueryAsync<Race>(
            "select R.ID, R.Description from Race R"
            + " inner join ListRace LR"
            + " on R.ID = LR.RaceID where LR.RaceListID = ?",
            racelistid);
        }
        public Task<List<Country>> GetCountrysAsync()
        {
            return _database.Table<Country>().ToListAsync();
        }
        public Task<int> SaveCountryAsync(Country country)
        {
            if (country.ID != 0)
            {
                return _database.UpdateAsync(country);
            }
            else
            {
                return _database.InsertAsync(country);
            }
        }


    }
}