using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProiectRestaurantMobile.Models;

namespace ProiectRestaurantMobile.Data
{
    public class RestaurantListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public RestaurantListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<RestaurantList>().Wait();
            _database.CreateTableAsync<Food>().Wait();
            _database.CreateTableAsync<ListFood>().Wait();
        }
        public Task<int> SaveFoodAsync(Food food)
        {
            if (food.ID != 0)
            {
                return _database.UpdateAsync(food);
            }
            else
            {
                return _database.InsertAsync(food);
            }
        }
        public Task<int> SaveListFoodAsync(ListFood listf)
        {
            if (listf.ID != 0)
            {
                return _database.UpdateAsync(listf);
            }
            else
            {
                return _database.InsertAsync(listf);
            }
        }
        public Task<List<Food>> GetListFoodsAsync(int restaurantlistid)
        {
            return _database.QueryAsync<Food>(
            "select F.ID, F.Description from Food F"
            + " inner join ListFood LF"
            + " on F.ID = LF.FoodID where LF.RestaurantListID = ?",
            restaurantlistid);
        }
        public Task<int> DeleteFoodAsync(Food food)
        {
            return _database.DeleteAsync(food);
        }
        public Task<List<Food>> GetFoodsAsync()
        {
            return _database.Table<Food>().ToListAsync();
        }
        public Task<List<RestaurantList>> GetRestaurantListsAsync()
        {
            return _database.Table<RestaurantList>().ToListAsync();
        }
        public Task<RestaurantList> GetRestaurantListAsync(int id)
        {
            return _database.Table<RestaurantList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveRestaurantListAsync(RestaurantList rlist)
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
        public Task<int> DeleteRestaurantListAsync(RestaurantList rlist)
        {
            return _database.DeleteAsync(rlist);
        }
    }
}
