using System.IO;
using UnityEngine;

namespace database {
    public static class GameData {
        public static readonly string ACTOR_PATH = Path.Combine(Application.dataPath + "/data", "actors.xml");
        public static readonly string ITEM_PATH = Path.Combine(Application.dataPath + "/data", "items.xml");
        public static readonly string WEAPON_PATH = Path.Combine(Application.dataPath + "/data", "weapons.xml");
        public static readonly string ARMOR_PATH = Path.Combine(Application.dataPath + "/data", "armor.xml");

        public static Database<ActorData> actors;
        public static Database<ItemData> items;
        public static Database<WeaponData> weapons;
        public static Database<ArmorData> armor;

        public static void Save() {
            actors.Save<Database<ActorData>>(ACTOR_PATH);
            items.Save<Database<ItemData>>(ITEM_PATH);
            weapons.Save<Database<WeaponData>>(WEAPON_PATH);
            armor.Save<Database<ArmorData>>(ARMOR_PATH);
        }
        public static void Load() {
            actors = Database<ActorData>.Load<Database<ActorData>>(ACTOR_PATH);
            items = Database<ItemData>.Load<Database<ItemData>>(ITEM_PATH);
            weapons = Database<WeaponData>.Load<Database<WeaponData>>(WEAPON_PATH);
            armor = Database<ArmorData>.Load<Database<ArmorData>>(ARMOR_PATH);
        }
    }
}