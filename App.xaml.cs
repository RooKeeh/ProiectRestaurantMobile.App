using System;
using ProiectRestaurantMobile.Data;
using System.IO;

namespace ProiectRestaurantMobile;

public partial class App : Application
{
    static RestaurantListDatabase database;
    public static RestaurantListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               RestaurantListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "RestaurantList.db3"));
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
