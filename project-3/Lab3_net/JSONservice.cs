using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
namespace Lab3_net
{
    public class JSONservice
    {
        public static ShopData ReadData(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<ShopData>(json);
        }
    }
    

public class Game
    {
        public int id { get; set; }
        public bool Itinstai { get; set; }
        public List<string> GetImages { get; set; }
        public double Version { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Part { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        public int Category { get; set; }
    }

    public class Library
    {
        public List<Game> Game { get; set; }
    }

    public class User
    {
        public double Balance { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Library Library { get; set; }
    }

    public class ShopData
    {
        public List<Game> GetGames { get; set; }
        public List<User> GetUsers { get; set; }
    }

    
}
