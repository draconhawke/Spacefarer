using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public static List<Skill> MasterSkillList = new List<Skill>();
    public static List<Skill> MasterCraftList = new List<Skill>();
    public static List<Skill> MasterSecondaryList = new List<Skill>();
    //string path;
    //string skillString;

    void Awake() {
        BuildMasterSkillList();
        BuildCraftingSkills();
        BuildSecondarySkills();
    }
    void BuildMasterSkillList() {
        //rewrite this build file into a save to json file
        //MasterSkillList.Add(new Skill("Arcane Lore", 0, 2, 1, Resources.Load("arcane_lore.jpg"), Skill.Category.LEARNED));
        //MasterSkillList.Add(new Skill("Salvaging", 0, -1, 1, Resources.Load("salvaging.jpg"), Skill.Category.LEARNED));
        //MasterSkillList.Add(new Skill("Magic Defense", 0, 12, 1, Resources.Load("magic_defense.jpg"), Skill.Category.LEARNED));
        //Weapon skills
        MasterSkillList.Add(new Skill("One Hand Weapons", 4, 4, 0));
        MasterSkillList.Add(new Skill("Two Hand Weapons", 8, 8, 0));
        MasterSkillList.Add(new Skill("Finesse Weapons", 4, 4, 0));
        MasterSkillList.Add(new Skill("Thrown Weapons", 4, 4, 0));
        MasterSkillList.Add(new Skill("Missile Weapons", 6, 6, 0));
        MasterSkillList.Add(new Skill("Dual Wield", 2, 2, 0));
        MasterSkillList.Add(new Skill("Sneak Attack", 4, 2, 0));
        MasterSkillList.Add(new Skill("Musical Instruments", 6, 6, 0));
        //Utility skills
        MasterSkillList.Add(new Skill("Deception", 4, 2, 0));
        MasterSkillList.Add(new Skill("First Aid", 6, 4, 0));
        MasterSkillList.Add(new Skill("Lock Pick", 6, 4, 0));
        MasterSkillList.Add(new Skill("Melee Defense", 10, 10, 0));
        MasterSkillList.Add(new Skill("Missile Defense", 6, 4, 0));
        MasterSkillList.Add(new Skill("Shield", 2, 2, 0));
        MasterSkillList.Add(new Skill("Animal Lore", 6, 12, 0));
        MasterSkillList.Add(new Skill("Appraising", 4, 4, 0));
        MasterSkillList.Add(new Skill("PoisonMaking", 4, 6, 0));
        MasterSkillList.Add(new Skill("Subterfuge", 6, 6, 0));
        MasterSkillList.Add(new Skill("Stealth", 6, 6, 0));
        MasterCraftList.Add(new Skill("Talismans", 2, 4, 0));
        MasterCraftList.Add(new Skill("Trinkets", 2, 4, 0));
        //Magic skills
        MasterSkillList.Add(new Skill("Mana Conversion", 6, 6, 0));
        MasterSkillList.Add(new Skill("Life Magic", 12, 8, 0));
        MasterSkillList.Add(new Skill("Death Magic", 16, 12, 0));
        MasterSkillList.Add(new Skill("Fire Magic", 16, 12, 0));
        MasterSkillList.Add(new Skill("Air Magic", 16, 12, 0));
        MasterSkillList.Add(new Skill("Water Magic", 16, 12, 0));
        MasterSkillList.Add(new Skill("Earth Magic", 16, 12, 0));
        MasterSkillList.Add(new Skill("Item Enchantment", 8, 8, 0));
        MasterSkillList.Add(new Skill("Creature Enchantment", 8, 8, 0));
    }
    //crafting skills
    public void BuildCraftingSkills() { 
        MasterSkillList.Add(new Skill("Alchemy", 6, 6, 0));
        MasterSkillList.Add(new Skill("Cooking", 4, 4, 0));
        MasterSkillList.Add(new Skill("Fletching", 4, 4, 0));
        MasterSkillList.Add(new Skill("Magic Item Tinkering", 4, -1, 0));
        MasterSkillList.Add(new Skill("Armor Tinkering", 4, 6, 0));
        MasterSkillList.Add(new Skill("Weapon Tinkering", 4, -1, 0));
        MasterSkillList.Add(new Skill("Blacksmith", 4, -1, 0));
        MasterSkillList.Add(new Skill("Mining", 4, -1, 0));
        MasterSkillList.Add(new Skill("Forestry", 4, -1, 0));
        MasterSkillList.Add(new Skill("Butchery", 4, -1, 0));
        MasterSkillList.Add(new Skill("Carpentry", 4, -1, 0));
        MasterSkillList.Add(new Skill("Weaving", 4, -1, 0));
        MasterSkillList.Add(new Skill("Leatherwork", 4, -1, 0));
        MasterSkillList.Add(new Skill("Tailoring", 4, -1, 0));
        MasterSkillList.Add(new Skill("Jewelcrafting", 4, -1, 0));
    }
    //secondary skills
    public void BuildSecondarySkills() { 
        MasterSkillList.Add(new Skill("Cartography", 6, 6, 0));
        MasterSkillList.Add(new Skill("Heraldry", 8, 8, 0));
        MasterSkillList.Add(new Skill("Navigation", 6, 6, 0));
        MasterSkillList.Add(new Skill("Planetology", 6, 6, 0));
        MasterSkillList.Add(new Skill("Shipwright", 4, 6, 0));
        MasterSkillList.Add(new Skill("Siege Weapons", 4, 6, 0));
        MasterSkillList.Add(new Skill("Spacemanship", 4, 5, 0));
        MasterSkillList.Add(new Skill("Spelljamming", 12, 18, 0));
        MasterSkillList.Add(new Skill("Stonemason", 4, 6, 0));
    }
    //void BuildQuestList() {
    //    path = Application.streamingAssetsPath + "/QuestList.json";
    //    questString = File.ReadAllText(path);
    //    Quest quest = JsonUtility.FromJson<Quest>(questString);
    //    MasterQuestList.Add(quest);
    //}
    //void BuildCreatureList() {
    //    path = Application.streamingAssetsPath + "/CreatureList.json";
    //    creatureString = File.ReadAllText(path);
    //    Creature creature = JsonUtility.FromJson<Creature>(creatureString);
    //    MasterCreatureList.Add(creature);
    //}
    //void BuildFactionList() {
    //    path = Application.streamingAssetsPath + "/FactionList.json";
    //    factionString = File.ReadAllText(path);
    //    string faction = JsonUtility.FromJson<string>(factionString);
    //    MasterFactionList.Add(faction);
    //}
}