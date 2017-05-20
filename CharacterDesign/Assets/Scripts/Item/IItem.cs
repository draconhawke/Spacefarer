using UnityEngine;

public interface IItem {
    int ItemID { get; set; }
    string ItemName { get; set; }
    string ItemDescription { get; set; }
    Sprite ItemIcon { get; set; }
    int ItemCost { get; set; }
    bool IsLore { get; set; }
    bool IsMagic { get; set; }
    bool IsTradeable { get; set; }
    ItemRarity Rarity { get; set; }
}

public enum ItemRarity { COMMON, UNCOMMON, RARE, EPIC, LEGENDARY }
