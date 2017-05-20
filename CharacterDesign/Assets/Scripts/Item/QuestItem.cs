using UnityEngine;
using System.Collections;

namespace Spacefarer.Item
{
    public class QuestItem : IItem
    {
        private int _itemID;
        private int _questID;
        private string _name;
        private string _description;
        private Sprite _icon;
        private int _cost;
        private bool _isLore;
        private bool _isTradeable;
        private bool _isMagic;
        private ItemRarity _rarity;

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
        public int QuestID
        {
            get { return _questID; }
            set { _questID = value; }
        }
        public QuestItem(int ID, int questID, string name, string desc, Sprite icon, int cost, bool lore, bool magic, bool trade, ItemRarity rare)
        {
            QuestID = questID;
            ItemID = ID;
            ItemName = name;
            ItemDescription = desc;
            ItemIcon = icon;
            ItemCost = cost;
            IsLore = lore;
            IsMagic = magic;
            IsTradeable = trade;
            Rarity = rare;
        }
    }
}