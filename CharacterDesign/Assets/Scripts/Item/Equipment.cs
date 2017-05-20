using UnityEngine;

namespace Spacefarer.Item
{
    public class Equipment : IItem, Prefab
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
        private int _armorRating;
        private int _durability;
        private int _maxDurability;
        private GameObject _prefab;
        private EquipmentSlot _equipmentSlot;

        public bool IsLore
        {
            get { return _isLore; }
            set { _isLore = value; }
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
        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
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
        public EquipmentSlot Slot
        {
            get { return _equipmentSlot; }
            set { _equipmentSlot = value; }
        }
        public int ArmorRating
        {
            get { return _armorRating; }
            set { _armorRating = value; }
        }
        public int Durability
        {
            get { return _durability; }
            set { _durability = value; }
        }
        public int MaxDurability
        {
            get { return _maxDurability; }
            set { _maxDurability = value; }
        }
        #region Constructor
        public Equipment() { }
        public Equipment(int ID, string name, string desc, Sprite icon, int cost, bool lore, bool magic, bool trade, ItemRarity rare, int rate, int dur, int max, EquipmentSlot slot, GameObject prefab)
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
            ArmorRating = rate;
            Durability = dur;
            MaxDurability = max;
            Slot = slot;
            Prefab = prefab;
        }
        #endregion
    }
}
public enum EquipmentSlot { HEAD, CHEST, LEGS, BELT, FEET, SHOULDERS, ARMS, HANDS, BACK }