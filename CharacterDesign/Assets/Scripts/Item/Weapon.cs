using UnityEngine;

namespace Spacefarer.Item
{
    public class Weapon : IItem, Prefab
    {
        private int _itemID;
        private string _name;
        private string _description;
        private Sprite _icon;
        private int _cost;
        private bool _isLore;
        private bool _isTradeable;
        private bool _isMagic;
        private ItemRarity _rarity;
        private int _minDamage;
        private int _maxDamage;
        private float _meleeRange;
        private float _missileRange;
        private GameObject _prefab;
        private WeaponType _type;

        public bool IsLore
        {
            get { return _isLore; }
            set { _isLore = value; }
        }
        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }
        public bool IsMagic
        {
            get { return _isMagic; }
            set { _isMagic = value; }
        }
        public bool IsTradeable
        {
            get { return _isTradeable; }
            set { _isTradeable = value; }
        }
        public int ItemCost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        public string ItemDescription
        {
            get { return _description; }
            set { _description = value; }
        }
        public Sprite ItemIcon
        {
            get { return _icon; }
            set { _icon = value; }
        }
        public string ItemName
        {
            get { return _name; }
            set { _name = value; }
        }
        public ItemRarity Rarity
        {
            get { return _rarity; }
            set { _rarity = value; }
        }
        public GameObject Prefab
        {
            get { return _prefab; }
            set { _prefab = value; }
        }
        public WeaponType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int Damage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public float Melee
        {
            get { return _meleeRange; }
            set { _meleeRange = value; }
        }
        public float Missile
        {
            get { return _missileRange; }
            set { _missileRange = value; }
        }
        #region Constructor
        public Weapon() { }
        public Weapon(int ID, string name, string desc, Sprite icon, int cost, bool lore, bool magic, bool trade, ItemRarity rare, int dam, int max, float melee, float missile, WeaponType type, GameObject prefab)
        {
            ItemID = ID;
            ItemName = name;
            ItemDescription = desc;
            ItemIcon = icon;
            ItemCost = cost;
            IsLore = lore;
            IsMagic = magic;
            IsTradeable = trade;
            Rarity = rare;
            Damage = dam;
            MaxDamage = max;
            Melee = melee;
            Missile = missile;
            Type = type;
            Prefab = prefab;
        }
        #endregion
    }
}
public enum WeaponType { ONEHANDSLASH, ONEHANDBLUNT, ONEHANDPIERCE, RANGED, TWOHANDSLASH, TWOHANDBLUNT, TWOHANDPIERCE, WAND }