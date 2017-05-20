using UnityEngine;
using System.Collections.Generic;

namespace Spacefarer.Item
{
    public class Jewelry : IItem
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
        private List<Buff> _buffs;
        private JewelrySlot _jewelrySlot;

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
        public JewelrySlot Slot
        {
            get { return _jewelrySlot; }
            set { _jewelrySlot = value; }
        }
        public List<Buff> Buffs
        {
            get { return _buffs; }
            set { _buffs = value; }
        }
        #region Constructors
        public Jewelry() { }
        public Jewelry(int ID, string name, string desc, Sprite icon, int cost, bool lore, bool magic, bool trade, ItemRarity rare, JewelrySlot slot, List<Buff> buffs)
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
            Buffs = buffs;
            Slot = slot;
        }
        #endregion
    }
}
public enum JewelrySlot { EARRING, RING, NECKLACE, CHARM }