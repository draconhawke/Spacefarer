using Spacefarer.Utility;
using System.IO;
using UnityEngine;

namespace Spacefarer {
    public static class Game {
        private static Database _database;
        private static readonly string database_location = Path.Combine(Application.streamingAssetsPath, "Data/Database.asset");

        //public static void Initialize()
        //{
        //    _database = LoadDatabase();
        //}
        public static void CreateDatabase()
        {
            ScriptableObjectManager.CreateAsset<Database>(database_location);
        }
        //public static Database LoadDatabase()
        //{
        //    //return ScriptableObjectManager.LoadAsset<Database>(database_location);
        //}
    }
}
