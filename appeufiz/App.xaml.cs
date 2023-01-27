using appeufiz.Services;
using appeufiz.Views;
using System;
using System.IO;
using Xamarin.Forms;
using appeufiz.Data;
using Xamarin.Forms.Xaml;

namespace appeufiz
{
    public partial class App : Application
    {
        static EufizDatabase database;

        // Create the database connection as a singleton.
        public static EufizDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new EufizDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

    protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
