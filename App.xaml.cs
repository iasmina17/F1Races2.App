using System;
using F1Races2.Data;
using System.IO;
using F1Races2;

namespace F1Races2
{
    public partial class App : Application
    {
        static RaceListDatabase database;
        public static RaceListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   RaceListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "RaceList.db3"));
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