using System;
using F1Races2.Data;
using System.IO;
using F1Races2;

namespace F1Races2
{
    public partial class App : Application
    {
        static RaceDatabase database;
        public static RaceDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   RaceDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "Races.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

    }
}