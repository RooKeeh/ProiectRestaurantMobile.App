using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProiectRestaurantMobile.Models
{
    public class ListFood
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(RestaurantList))]
        public int RestaurantListID { get; set; }
        public int FoodID { get; set; }
    }
}
