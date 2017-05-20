using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// this class is based from xOctoManx tutorial https://www.youtube.com/watch?v=509TW-Ffk38&t=1504s
/// </summary>

public class CreatePlayer : MonoBehaviour
{
    private BasePlayerClass newPlayer;
    private string playerName = string.Empty;
    private string playerGender = string.Empty;
    private string playerClass = string.Empty;
    private string playerRace = string.Empty;
    public List<Skill> playerSkillList = new List<Skill>();
    private Dictionary<string, int> factionList = new Dictionary<string, int>();
    [Header("UI Stats")]
    public Text strengthText;
    public Text agilityText; 
    public Text dexterityText;
    public Text constitutionText; 
    public Text wisdomText;
    public Text intelligenceText; 
    public Text charismaText;
    [Header("UI Vitals")]
    public Text hitPointText;
    public Text hpRegenText;
    public Text manaPointText;
    public Text manaRegenText;
    public Text staminaText;
    public Text staminaRegenText;
    public Text armorBonusText;
    public Text missileBonusText;
    public Text npcReactionText;
    public Text understandingText;
    [Header("UI Resists")]
    public Text fireResistText;
    public Text earthResistText;
    public Text airResistText;
    public Text waterResistText;
    public Text deathResistText;
    public Text lifeResistText;
    [Header("UI Controls")]
    public int pointsToSpend = 20;
    public Text pointsText;
    public Text classDescriptionText;
    public Text specialtyDescriptionText;
    public Text lblClassMessage;
    public Text lblRaceMessage;
    public Text lblSpecialtyMessage;
    public Text lblSkillMessage;
    public Text lblGenderMessage;
    [Header("UI Panels")]
    public GameObject classPanel;
    public GameObject racePanel;
    public GameObject specialtyPanel;
    public GameObject skillPanel; 
    public GameObject  finalPanel;
    public Image previewImage;
    [Header("UI Class Specialty Panels")]
    public GameObject warriorPanel;
    public GameObject roguePanel;
    public GameObject priestPanel;
    public GameObject wizardPanel;
    public Button PaladinBtn, WarlordBtn, RavagerBtn, ReaverBtn;
    public Button ArcherBtn, AssassinBtn, StalkerBtn, BardBtn;
    public Button JusticiarBtn, ClericBtn, ShamanBtn, DruidBtn;
    public Button ElementalistBtn, SorcererBtn, NecromancerBtn, CharmerBtn;
    [Header("UI Skill Panels")]
    public GameObject SpecializePanel;
    public GameObject AdvancedPanel;
    public GameObject LearnedPanel; 
    public GameObject AvailablePanel; 
    public GameObject UnavailablePanel;
    public GameObject skillTabPrefab;

    void Start()
    {
        ClearPanels();
        classPanel.SetActive(true);
        racePanel.SetActive(false);
        specialtyPanel.SetActive(false);
        skillPanel.SetActive(false);
        finalPanel.SetActive(false);
    }
    void Update()
    {
        if (playerClass == string.Empty)
            lblClassMessage.text = "CHOOSE A CLASS TO BEGIN";
        else if (playerClass != string.Empty && pointsToSpend > 0)
            lblClassMessage.text = "SPEND POINTS TO INCREASE STATS";
        else
            lblClassMessage.text = "CLICK NEXT TO CONTINUE";
        if (playerRace == string.Empty)
            lblRaceMessage.text = "NEXT, CHOOSE A RACE";
        else
            lblRaceMessage.text = "CLICK NEXT TO CONTINUE";
        if (specialtyDescriptionText.text == string.Empty)
            lblSpecialtyMessage.text = "CHOOSE A SPECIALTY";
        else
            lblSpecialtyMessage.text = "CLICK NEXT TO CONTINUE";
        if (playerSkillList == null)
            lblSkillMessage.text = "SELECT SKILLS TO CONTINUE";
        else
            lblSkillMessage.text = "CLICK NEXT TO CONTINUE";
        if (playerGender == string.Empty)
            lblGenderMessage.text = "CHOOSE A GENDER";
        else
            lblGenderMessage.text = "CLICK SAVE TO FINALIZE";
    }
    public void CreateNewPlayer()
    {
        newPlayer.PlayerName = playerName;
        newPlayer.PlayerLevel = 1;
    }
    #region Character class methods
    public void SetRogueClass()
    {
        newPlayer.PlayerClass = new BaseRogueClass();
        playerClass = "Rogue";
        classDescriptionText.text = "The Rogue is a usually stealthy and dexterous character able to disarm traps, pick locks, spy on foes, and perform backstabs from hiding. All races have some form of rogue, but not all specializations are available.";
        previewImage.sprite = Resources.Load<Sprite>("Ranger_icon");
        pointsToSpend = 20;
        UpdateStats();
        UpdateVitals();
        UpdateClassUI();
    }
    public void SetWarriorClass()
    {
        newPlayer.PlayerClass = new BaseWarriorClass();
        playerClass = "Warrior";
        classDescriptionText.text = "The Warrior is skilled in combat, and usually can make use of some of the most powerful heavy armor and weaponry in the game. As such, the warrior is a well-rounded physical combatant. All races have some form of warrior.";
        previewImage.sprite = Resources.Load<Sprite>("Warrior_icon");
        pointsToSpend = 20;
        UpdateStats();
        UpdateVitals();
        UpdateClassUI();
    }
    public void SetPriestClass()
    {
        newPlayer.PlayerClass = new BasePriestClass();
        playerClass = "Priest";
        classDescriptionText.text = "The Priest has powers to heal wounds, protect their allies and sometimes resurrect the dead, as well as banish undead. All races have some form of priest";
        previewImage.sprite = Resources.Load<Sprite>("Priest_icon");
        pointsToSpend = 20;
        UpdateStats();
        UpdateVitals();
        UpdateClassUI();
    }
    public void SetWizardClass()
    {
        newPlayer.PlayerClass = new BaseWizardClass();
        playerClass = "Wizard";
        classDescriptionText.text = "The Wizard is considered to be a spellcaster who wields powerful spells, but is often physically weak.Certain specialties are only available to particular races.";
        previewImage.sprite = Resources.Load<Sprite>("Sorcerer_icon");
        pointsToSpend = 20;
        UpdateStats();
        UpdateVitals();
        UpdateClassUI();
    }
    #endregion
    #region Character class specialization methods
    public void SetPaladin(string pClass)
    {
        specialtyDescriptionText.text = "Paladin is a holy warrior tank, who specializes in 1HD weapon type, and Plate armor & Shield, and Life Magic";
        ResetSkills();
        LoadSkillList(pClass);
    }
    public void SetWarlord(string pClass)
    {
        specialtyDescriptionText.text = "Warlord is a DPS warrior who specializes in 2HD weapons and Plate armor";
        ResetSkills();
        LoadSkillList(pClass);
    }
    public void SetRavager(string pClass)
    {
        specialtyDescriptionText.text = "Ravager is a DPS warrior who specializes in dual-wielding weapons and Plate armor";
        ResetSkills();
        LoadSkillList(pClass);
    }
    public void SetReaver(string pClass)
    {
        specialtyDescriptionText.text = "Reaver is an unholy warrior tank, who specializes in 1HD weapon type, Plate armor & Shield, and Death Magic";
        ResetSkills();
        LoadSkillList(pClass);
    }
    public void SetArcher(string pClass)
    {
        specialtyDescriptionText.text = "Archer is a rogue who specializes in bows or crossbows, and Leather armor";
        ResetSkills();
        LoadSkillList(pClass);
    }
    public void SetAssassin(string pClass)
    {
        specialtyDescriptionText.text = "Assassin is a rogue who specializes in deathly techniques and Leather armor";
        ResetSkills();
        LoadSkillList(pClass);
    }
    public void SetStalker(string pClass)
    {
        specialtyDescriptionText.text = "Stalker is a rogue who specializes in subterfage and Leather armor";
        ResetSkills();
        LoadSkillList(pClass);
    }
    public void SetBard(string pClass)
    {
        specialtyDescriptionText.text = "Bard is a rogue who specializes in musical arts and Leather armor";
        ResetSkills();
        LoadSkillList(pClass);
    }
    public void SetJusticiar(string pClass)
    {
        specialtyDescriptionText.text = "Justiciar is a battle-priest, who specializes in blunt weapons, Chain armor & Shield, and Life Magic";
        ResetSkills();
        LoadSkillList(pClass);
    }
    public void SetCleric(string pClass)
    {
        specialtyDescriptionText.text = "Cleric is a base priest, who specializes in Life Magic and Chain armor";
        ResetSkills();
        LoadSkillList(pClass);
    }
    public void SetDruid(string pClass)
    {
        specialtyDescriptionText.text = "Druid is a priest who specializes with Life Magic (nature), talismans, blunt weapons and Chain armor";
        ResetSkills();
        LoadSkillList(pClass);
    }
    public void SetShaman(string pClass)
    {
        specialtyDescriptionText.text = "Shaman is a priest, who specializes in Death Magic(DoTs) & Life Magic (HoTs), 2HD blunt weapon, and Chain armor & shield";
        ResetSkills();
        LoadSkillList(pClass);
    }
    public void SetElementalist(string pClass)
    {
        specialtyDescriptionText.text = "Elementalist is a wizard who is advanced with all 4 Elemental Magic and Cloth armor";
        ResetSkills();
        LoadSkillList(pClass);
    }
    public void SetSorcerer(string pClass)
    {
        specialtyDescriptionText.text = "Sorcerer is a wizard who is specialized in 1 Elemental Magic at double proficiency and Cloth armor";
        ResetSkills();
        LoadSkillList(pClass);
    }
    public void SetNecromancer(string pClass)
    {
        specialtyDescriptionText.text = "Necromancer is a wizard who is specialized in Death Magic and Cloth armor";
        ResetSkills();
        LoadSkillList(pClass);
    }
    public void SetCharmer(string pClass)
    {
        specialtyDescriptionText.text = "Charmer is a wizard who is specialized in Enchant Magic and Cloth armor";
        ResetSkills();
        LoadSkillList(pClass);
    }
    #endregion
    #region Create character race methods
    public void SetDwarfRace()
    {
        newPlayer.PlayerResist = new BaseDwarfResist();
        playerRace = "Dwarf";
        UpdateResists();
    }
    public void SetHalflingRace()
    {
        newPlayer.PlayerResist = new BaseHalflingResist();
        playerRace = "Halfling";
        UpdateResists();
    }
    public void SetMoonElfRace()
    {
        newPlayer.PlayerResist = new BaseMoonElfResist();
        playerRace = "Moonelf";
        UpdateResists();
    }
    public void SetKattariRace()
    {
        newPlayer.PlayerResist = new BaseKattariResist();
        playerRace = "Kattari";
        UpdateResists();
    }
    public void SetHalfElfRace()
    {
        newPlayer.PlayerResist = new BaseHalfElfResist();
        playerRace = "Halfelf";
        UpdateResists();
    }
    public void SetHumanRace()
    {
        newPlayer.PlayerResist = new BaseHumanResist();
        playerRace = "Human";
        UpdateResists();
    }
    public void SetGnomeRace()
    {
        newPlayer.PlayerResist = new BaseGnomeResist();
        playerRace = "Gnome";
        UpdateResists();
    }
    public void SetWoodElfRace()
    {
        newPlayer.PlayerResist = new BaseWoodElfResist();
        playerRace = "Woodelf";
        UpdateResists();
    }
    public void SetDarkElfRace()
    {
        newPlayer.PlayerResist = new BaseDarkElfResist();
        playerRace = "Darkelf";
        UpdateResists();
    }
    public void SetLizardManRace()
    {
        newPlayer.PlayerResist = new BaseLizardManResist();
        playerRace = "LizardMan";
        UpdateResists();
    }
    public void SetOgreRace()
    {
        newPlayer.PlayerResist = new BaseOgreResist();
        playerRace = "Ogre";
        UpdateResists();
    }
    public void SetTrollRace()
    {
        newPlayer.PlayerResist = new BaseTrollResist();
        playerRace = "Troll";
        UpdateResists();
    }
    #endregion
    //Character gender methods
    public void ChooseGender(int i)
    {
        if (i == 0)
            playerGender = "MALE";
        else if (i == 1)
            playerGender = "FEMALE";
        else
            playerGender = "";
    }
    // Panel Progression Methods
    public void Next(int i)
    {
        if (newPlayer == null) return;
        switch (i)
        {
            case 0:
                if (newPlayer.PlayerClass == null) return;
                classPanel.SetActive(false);
                racePanel.SetActive(true);
                break;
            case 1:
                racePanel.SetActive(false);
                specialtyPanel.SetActive(true);
                UpdateSpecialization();
                break;
            case 2:
                specialtyPanel.SetActive(false);
                skillPanel.SetActive(true);
                break;
            case 3:
                skillPanel.SetActive(false);
                finalPanel.SetActive(true);
                break;
        }
    }
    public void Back(int i)
    {
        if (newPlayer == null) return;
        switch (i)
        {
            case 0:                         //move panel to Class Panel
                classPanel.SetActive(true);
                racePanel.SetActive(false);
                break;
            case 1:                         //move panel to Race Panel
                racePanel.SetActive(true);
                specialtyPanel.SetActive(false);
                break;
            case 2:                         //move panel to Specialty Panel
                specialtyPanel.SetActive(true);
                skillPanel.SetActive(false);
                break;
            case 3:                         //move panel to Skill Panel
                skillPanel.SetActive(true);
                finalPanel.SetActive(false);
                break;
        }
    }
    public void Cancel() { }
    public void ClearPanels()
    {
        newPlayer = new BasePlayerClass();
        pointsToSpend = 0;
        newPlayer.Strength =
            newPlayer.Agility =
            newPlayer.Dexterity =
            newPlayer.Constitution =
            newPlayer.Wisdom =
            newPlayer.Intelligence =
            newPlayer.Charisma = 0;
        classDescriptionText.text = "";
        UpdateVitals();
        UpdateClassUI();
    }
    public void Save()
    {
        PlayerInfo.PlayerLevel = newPlayer.PlayerLevel;
        PlayerInfo.PlayerName = newPlayer.PlayerName;
        PlayerInfo.PlayerClass = newPlayer.PlayerClass;
        PlayerInfo.PlayerGender = playerGender;
        PlayerInfo.PlayerResist = newPlayer.PlayerResist;
        PlayerInfo.PlayerRace = playerRace;
    }
    //Update methods
    public void UpdateClassUI()
    {
        strengthText.text = newPlayer.Strength.ToString();
        dexterityText.text = newPlayer.Dexterity.ToString();
        agilityText.text = newPlayer.Agility.ToString();
        constitutionText.text = newPlayer.Constitution.ToString();
        wisdomText.text = newPlayer.Wisdom.ToString();
        intelligenceText.text = newPlayer.Intelligence.ToString();
        charismaText.text = newPlayer.Charisma.ToString();
        pointsText.text = pointsToSpend.ToString();
    }
    public void UpdateStats()
    {
        newPlayer.Strength = newPlayer.PlayerClass.Strength;
        newPlayer.Dexterity = newPlayer.PlayerClass.Dexterity;
        newPlayer.Agility = newPlayer.PlayerClass.Agility;
        newPlayer.Constitution = newPlayer.PlayerClass.Constitution;
        newPlayer.Wisdom = newPlayer.PlayerClass.Wisdom;
        newPlayer.Intelligence = newPlayer.PlayerClass.Intelligence;
        newPlayer.Charisma = newPlayer.PlayerClass.Charisma;
    }
    public void UpdateVitals()
    {
        hitPointText.text = (newPlayer.Constitution * 3).ToString();
        if (playerClass == "Priest")
            manaPointText.text = (newPlayer.Wisdom * 3).ToString();
        else if (playerClass == "Wizard")
            manaPointText.text = (newPlayer.Intelligence * 4).ToString();
        else
            manaPointText.text = ((newPlayer.Wisdom + newPlayer.Intelligence) / 2).ToString();
        staminaText.text = (newPlayer.Strength + newPlayer.Constitution).ToString();
        hpRegenText.text = (newPlayer.Constitution * 2 / 3).ToString();
        manaRegenText.text = ((newPlayer.Wisdom + newPlayer.Intelligence) / 2).ToString();
        staminaRegenText.text = ((newPlayer.Strength + newPlayer.Constitution) / 2).ToString();
        armorBonusText.text = (newPlayer.Dexterity * 2).ToString();
        missileBonusText.text = (newPlayer.Agility * 1.5).ToString();
        understandingText.text = (newPlayer.Intelligence * 3).ToString();
        npcReactionText.text = (newPlayer.Charisma * 3).ToString();
    }
    public void UpdateResists()
    {
        fireResistText.text = newPlayer.PlayerResist.FireResist.ToString();
        earthResistText.text = newPlayer.PlayerResist.EarthResist.ToString();
        airResistText.text = newPlayer.PlayerResist.AirResist.ToString();
        waterResistText.text = newPlayer.PlayerResist.WaterResist.ToString();
        deathResistText.text = newPlayer.PlayerResist.DeathResist.ToString();
        lifeResistText.text = newPlayer.PlayerResist.LifeResist.ToString();
    }
    //Display Specialties
    private void ResetSkills()
    {
        playerSkillList.Clear();
    }
    public void DisplayWarrior()
    {
        //All races can have the warlord specialty
        WarlordBtn.gameObject.SetActive(true);
        PaladinBtn.gameObject.SetActive(false);
        RavagerBtn.gameObject.SetActive(false);
        ReaverBtn.gameObject.SetActive(false);
        if (playerRace == "Dwarf" || playerRace == "Moonelf" || playerRace == "Human" || playerRace == "Halfling" || playerRace == "Halfelf" || playerRace == "Gnome")
            PaladinBtn.gameObject.SetActive(true);
        if (playerRace == "Darkelf" || playerRace == "Lizardman" || playerRace == "Ogre" || playerRace == "Troll" || playerRace == "Woodelf" || playerRace == "Human" || playerRace == "Kattari")
            RavagerBtn.gameObject.SetActive(true);
        if (playerRace == "Darkelf" || playerRace == "Troll" || playerRace == "Gnome" || playerRace == "Human")
            ReaverBtn.gameObject.SetActive(true);
    }
    public void DisplayRogue()
    {
        //All races can have the stalker specialty
        StalkerBtn.gameObject.SetActive(true);
        ArcherBtn.gameObject.SetActive(false);
        AssassinBtn.gameObject.SetActive(false);
        BardBtn.gameObject.SetActive(false);
        if (playerRace == "Woodelf" || playerRace == "Human" || playerRace == "Halfling" || playerRace == "Halfelf")
            ArcherBtn.gameObject.SetActive(true);
        if (playerRace == "Darkelf" || playerRace == "Human" || playerRace == "Halfling" || playerRace == "Halfelf" || playerRace == "Woodelf")
            AssassinBtn.gameObject.SetActive(true);
        if (playerRace == "Human" || playerRace == "Woodelf" || playerRace == "Halfelf" || playerRace == "Halfling" || playerRace == "Kattari")
            BardBtn.gameObject.SetActive(true);
    }
    public void DisplayPriest()
    {
        //All races can have the Cleric specialty
        ClericBtn.gameObject.SetActive(true);
        JusticiarBtn.gameObject.SetActive(false);
        DruidBtn.gameObject.SetActive(false);
        ShamanBtn.gameObject.SetActive(false);
        if (playerRace == "Human" || playerRace == "Moonelf" || playerRace == "Dwarf" || playerRace == "Darkelf")
            JusticiarBtn.gameObject.SetActive(true);
        if (playerRace == "Halfling" || playerRace == "Woodelf" || playerRace == "Kattari" || playerRace == "Halfelf")
            DruidBtn.gameObject.SetActive(true);
        if (playerRace == "Ogre" || playerRace == "Troll" || playerRace == "Lizardman" || playerRace == "Kattari")
            ShamanBtn.gameObject.SetActive(true);
    }
    public void DisplayWizard()
    {
        ElementalistBtn.gameObject.SetActive(false);
        SorcererBtn.gameObject.SetActive(false);
        NecromancerBtn.gameObject.SetActive(false);
        CharmerBtn.gameObject.SetActive(false);
        if (playerRace == "Human" || playerRace == "Moonelf" || playerRace == "Darkelf" || playerRace == "Gnome" || playerRace == "Lizardman")
            ElementalistBtn.gameObject.SetActive(true);
        if (playerRace == "Human" || playerRace == "Moonelf" || playerRace == "Darkelf" || playerRace == "Gnome")
            SorcererBtn.gameObject.SetActive(true);
        if (playerRace == "Human" || playerRace == "Gnome" || playerRace == "Darkelf" || playerRace == "Ogre" || playerRace == "Troll" || playerRace == "Lizardman")
            NecromancerBtn.gameObject.SetActive(true);
        if (playerRace == "Human" || playerRace == "Gnome" || playerRace == "Darkelf" || playerRace == "Moonelf")
            CharmerBtn.gameObject.SetActive(true);
    }
    public void UpdateSpecialization()
    {
        if (playerClass == null)
            return;
        switch (playerClass)
        {
            case "Warrior":
                warriorPanel.SetActive(true);
                roguePanel.SetActive(false);
                priestPanel.SetActive(false);
                wizardPanel.SetActive(false);
                DisplayWarrior();
                break;
            case "Rogue":
                warriorPanel.SetActive(false);
                roguePanel.SetActive(true);
                priestPanel.SetActive(false);
                wizardPanel.SetActive(false);
                DisplayRogue();
                break;
            case "Priest":
                warriorPanel.SetActive(false);
                roguePanel.SetActive(false);
                priestPanel.SetActive(true);
                wizardPanel.SetActive(false);
                DisplayPriest();
                break;
            case "Wizard":
                warriorPanel.SetActive(false);
                roguePanel.SetActive(false);
                priestPanel.SetActive(false);
                wizardPanel.SetActive(true);
                DisplayWizard();
                break;
        }
    }
    //Set stat methods
    public void SetStrength(int amt)
    {
        if (newPlayer == null) return;
        if (newPlayer.PlayerClass != null)
        {
            if (amt > 0 && pointsToSpend > 0)
            {
                newPlayer.Strength += amt;
                pointsToSpend--;
                UpdateVitals();
                UpdateClassUI();
            }
            else if (amt < 0 && newPlayer.Strength > newPlayer.PlayerClass.Strength)
            {
                newPlayer.Strength += amt;
                pointsToSpend++;
                UpdateVitals();
                UpdateClassUI();
            }
        }
        else
            Debug.Log("No class was chosen");
    }
    public void SetDexterity(int amt)
    {
        if (newPlayer == null) return;
        if (newPlayer.PlayerClass != null)
        {
            if (amt > 0 && pointsToSpend > 0)
            {
                newPlayer.Dexterity += amt;
                pointsToSpend--;
                UpdateVitals();
                UpdateClassUI();
            }
            else if (amt < 0 && newPlayer.Dexterity > newPlayer.PlayerClass.Dexterity)
            {
                newPlayer.Dexterity += amt;
                pointsToSpend++;
                UpdateVitals();
                UpdateClassUI();
            }
        }
        else
            Debug.Log("No class was chosen");
    }
    public void SetAgility(int amt)
    {
        if (newPlayer == null) return;
        if (newPlayer.PlayerClass != null)
        {
            if (amt > 0 && pointsToSpend > 0)
            {
                newPlayer.Agility += amt;
                pointsToSpend--;
                UpdateVitals();
                UpdateClassUI();
            }
            else if (amt < 0 && newPlayer.Agility > newPlayer.PlayerClass.Agility)
            {
                newPlayer.Agility += amt;
                pointsToSpend++;
                UpdateVitals();
                UpdateClassUI();
            }
        }
        else
            Debug.Log("No class was chosen");
    }
    public void SetConstitution(int amt)
    {
        if (newPlayer == null) return;
        if (newPlayer.PlayerClass != null)
        {
            if (amt > 0 && pointsToSpend > 0)
            {
                newPlayer.Constitution += amt;
                pointsToSpend--;
                UpdateVitals();
                UpdateClassUI();
            }
            else if (amt < 0 && newPlayer.Constitution > newPlayer.PlayerClass.Constitution)
            {
                newPlayer.Constitution += amt;
                pointsToSpend++;
                UpdateVitals();
                UpdateClassUI();
            }
        }
        else
            Debug.Log("No class was chosen");
    }
    public void SetWisdom(int amt)
    {
        if (newPlayer == null) return;
        if (newPlayer.PlayerClass != null)
        {
            if (amt > 0 && pointsToSpend > 0)
            {
                newPlayer.Wisdom += amt;
                pointsToSpend--;
                UpdateVitals();
                UpdateClassUI();
            }
            else if (amt < 0 && newPlayer.Wisdom > newPlayer.PlayerClass.Wisdom)
            {
                newPlayer.Wisdom += amt;
                pointsToSpend++;
                UpdateVitals();
                UpdateClassUI();
            }
        }
        else
            Debug.Log("No class was chosen");
    }
    public void SetIntelligence(int amt)
    {
        if (newPlayer == null) return;
        if (newPlayer.PlayerClass != null)
        {
            if (amt > 0 && pointsToSpend > 0)
            {
                newPlayer.Intelligence += amt;
                pointsToSpend--;
                UpdateVitals();
                UpdateClassUI();
            }
            else if (amt < 0 && newPlayer.Intelligence > newPlayer.PlayerClass.Intelligence)
            {
                newPlayer.Intelligence += amt;
                pointsToSpend++;
                UpdateVitals();
                UpdateClassUI();
            }
        }
        else
            Debug.Log("No class was chosen");
    }
    public void SetCharisma(int amt)
    {
        if (newPlayer == null) return;
        if (newPlayer.PlayerClass != null)
        {
            if (amt > 0 && pointsToSpend > 0)
            {
                newPlayer.Charisma += amt;
                pointsToSpend--;
                UpdateVitals();
                UpdateClassUI();
            }
            else if (amt < 0 && newPlayer.Charisma > newPlayer.PlayerClass.Charisma)
            {
                newPlayer.Charisma += amt;
                pointsToSpend++;
                UpdateVitals();
                UpdateClassUI();
            }
        }
        else
            Debug.Log("No class was chosen");
    }

    #region Load List methods
    //Skill List
    public void LoadSkillList(string playerClass)
    {
        if (playerClass == "")
            return;
        switch (playerClass)
        {
            #region WARRIOR CLASSES
            case "Paladin":
                SpecializeSkill("One Hand Weapons");
                AdvancedSkill("Shield");
                AdvancedSkill("Plate armor");
                AdvancedSkill("Melee Defense");
                LearnSkill("Life Magic");
                LearnSkill("Mana Conversion");
                UnavailableSkill("Death Magic");
                UnavailableSkill("Fire Magic");
                UnavailableSkill("Air Magic");
                UnavailableSkill("Water Magic");
                UnavailableSkill("Earth Magic");
                UnavailableSkill("Thrown Weapons");
                UnavailableSkill("Enchant Creaure");
                UnavailableSkill("Enchant Item");
                UnavailableSkill("Chain armor");
                UnavailableSkill("Cloth armor");
                UnavailableSkill("Leather armor");
                break;
            case "Warlord":
                SpecializeSkill("Two Hand Weapons");
                AdvancedSkill("Plate armor");
                AdvancedSkill("Melee Defense");
                UnavailableSkill("Death Magic");
                UnavailableSkill("Life Magic");
                UnavailableSkill("Enchant Creaure");
                UnavailableSkill("Enchant Item");
                UnavailableSkill("Fire Magic");
                UnavailableSkill("Air Magic");
                UnavailableSkill("Water Magic");
                UnavailableSkill("Earth Magic");
                UnavailableSkill("Mana Conversion");
                UnavailableSkill("Chain armor");
                UnavailableSkill("Cloth armor");
                UnavailableSkill("Leather armor");
                break;
            case "Ravager":
                SpecializeSkill("One Hand Weapons");
                AdvancedSkill("Duel Wield");
                AdvancedSkill("Melee Defense");
                AdvancedSkill("Plate armor");
                UnavailableSkill("Mana Conversion");
                UnavailableSkill("Death Magic");
                UnavailableSkill("Fire Magic");
                UnavailableSkill("Air Magic");
                UnavailableSkill("Water Magic");
                UnavailableSkill("Earth Magic");
                UnavailableSkill("Chain armor");
                UnavailableSkill("Cloth armor");
                UnavailableSkill("Leather armor");
                break;
            case "Reaver":
                SpecializeSkill("Two Hand Weapons");
                SpecializeSkill("Death Magic");
                AdvancedSkill("Plate armor");
                AdvancedSkill("Melee Defense");
                UnavailableSkill("Life Magic");
                UnavailableSkill("Fire Magic");
                UnavailableSkill("Air Magic");
                UnavailableSkill("Water Magic");
                UnavailableSkill("Earth Magic");
                UnavailableSkill("Thrown Weapons");
                UnavailableSkill("Chain armor");
                UnavailableSkill("Cloth armor");
                UnavailableSkill("Leather armor");
                break;
            #endregion
            #region ROGUE CLASSES
            case "Archer":
                SpecializeSkill("Missile Weapons");
                AdvancedSkill("Leather armor");
                AdvancedSkill("One Hand Weapons");
                LearnSkill("Subterfuge");
                LearnSkill("Melee Defense");
                LearnSkill("Missile Defense");
                UnavailableSkill("Life Magic");
                UnavailableSkill("Death Magic");
                UnavailableSkill("Fire Magic");
                UnavailableSkill("Air Magic");
                UnavailableSkill("Water Magic");
                UnavailableSkill("Earth Magic");
                UnavailableSkill("Creature Enchant");
                UnavailableSkill("Item Enchant");
                UnavailableSkill("Plate armor");
                UnavailableSkill("Cloth armor");
                UnavailableSkill("Chain armor");
                break;
            case "Assassin":
                SpecializeSkill("One Hand Weapons");
                AdvancedSkill("Stealth");
                AdvancedSkill("Leather armor");
                AdvancedSkill("Sneak Attack");
                LearnSkill("Melee Defense");
                LearnSkill("Missile Defense");
                LearnSkill("Poison Making");
                LearnSkill("Subterfuge");
                UnavailableSkill("Life Magic");
                UnavailableSkill("Death Magic");
                UnavailableSkill("Fire Magic");
                UnavailableSkill("Air Magic");
                UnavailableSkill("Water Magic");
                UnavailableSkill("Earth Magic");
                UnavailableSkill("Creature Enchant");
                UnavailableSkill("Item Enchant");
                UnavailableSkill("Plate armor");
                UnavailableSkill("Cloth armor");
                UnavailableSkill("Chain armor");
                break;
            case "Stalker":
                SpecializeSkill("One Hand Weapons");
                AdvancedSkill("Leather armor");
                AdvancedSkill("Stealth");
                AdvancedSkill("Sneak Attack");
                LearnSkill("Lock Pick");
                LearnSkill("Shield");
                LearnSkill("Deception");
                LearnSkill("Melee Defense");
                LearnSkill("Subterfuge");
                UnavailableSkill("Life Magic");
                UnavailableSkill("Death Magic");
                UnavailableSkill("Fire Magic");
                UnavailableSkill("Air Magic");
                UnavailableSkill("Water Magic");
                UnavailableSkill("Earth Magic");
                UnavailableSkill("Creature Enchant");
                UnavailableSkill("Item Enchant");
                UnavailableSkill("Plate armor");
                UnavailableSkill("Cloth armor");
                UnavailableSkill("Chain armor");
                break;
            case "Bard":
                SpecializeSkill("Musical Instruments");
                SpecializeSkill("One Hand Weapons");
                AdvancedSkill("Dual Wield");
                LearnSkill("Leather armor");
                LearnSkill("Melee Defense");
                UnavailableSkill("Life Magic");
                UnavailableSkill("Death Magic");
                UnavailableSkill("Fire Magic");
                UnavailableSkill("Air Magic");
                UnavailableSkill("Water Magic");
                UnavailableSkill("Earth Magic");
                UnavailableSkill("Creature Enchant");
                UnavailableSkill("Item Enchant");
                UnavailableSkill("Plate armor");
                UnavailableSkill("Cloth armor");
                UnavailableSkill("Chain armor");
                break;
            #endregion
            #region PRIEST CLASSES
            case "Justiciar":
                SpecializeSkill("One Hand Weapons");
                AdvancedSkill("Chain armor");
                AdvancedSkill("Life Magic");
                LearnSkill("Mana Conversion");
                LearnSkill("Melee Defense");
                LearnSkill("Shield");
                UnavailableSkill("Death Magic");
                UnavailableSkill("Fire Magic");
                UnavailableSkill("Air Magic");
                UnavailableSkill("Water Magic");
                UnavailableSkill("Earth Magic");
                UnavailableSkill("Creature Enchant");
                UnavailableSkill("Item Enchant");
                UnavailableSkill("Missile Weapons");
                UnavailableSkill("Plate armor");
                UnavailableSkill("Cloth armor");
                UnavailableSkill("Leather armor");
                break;
            case "Cleric":
                SpecializeSkill("Life Magic");
                AdvancedSkill("One Hand Weapons");
                AdvancedSkill("Mana Conversion");
                AdvancedSkill("Chain armor");
                LearnSkill("Talismans");
                UnavailableSkill("Death Magic");
                UnavailableSkill("Fire Magic");
                UnavailableSkill("Air Magic");
                UnavailableSkill("Water Magic");
                UnavailableSkill("Earth Magic");
                UnavailableSkill("Creature Enchant");
                UnavailableSkill("Item Enchant");
                UnavailableSkill("Missile Weapons");
                UnavailableSkill("Plate armor");
                UnavailableSkill("Cloth armor");
                UnavailableSkill("Leather armor");
                break;
            case "Shaman":
                SpecializeSkill("Two Hand Weapons");
                AdvancedSkill("Chain armor");
                AdvancedSkill("Shield");
                AdvancedSkill("Mana Conversion");
                LearnSkill("Life Magic");
                LearnSkill("Death Magic");
                UnavailableSkill("Fire Magic");
                UnavailableSkill("Air Magic");
                UnavailableSkill("Water Magic");
                UnavailableSkill("Earth Magic");
                UnavailableSkill("Creature Enchant");
                UnavailableSkill("Item Enchant");
                UnavailableSkill("Missile Weapons");
                UnavailableSkill("Plate armor");
                UnavailableSkill("Cloth armor");
                UnavailableSkill("Leather armor");
                break;
            case "Druid":
                SpecializeSkill("One Hand Weapons");
                AdvancedSkill("Chain armor");
                AdvancedSkill("Life Magic");
                AdvancedSkill("Mana Conversion");
                LearnSkill("Talismans");
                UnavailableSkill("Death Magic");
                UnavailableSkill("Fire Magic");
                UnavailableSkill("Air Magic");
                UnavailableSkill("Water Magic");
                UnavailableSkill("Earth Magic");
                UnavailableSkill("Creature Enchant");
                UnavailableSkill("Item Enchant");
                UnavailableSkill("Missile Weapons");
                UnavailableSkill("Plate armor");
                UnavailableSkill("Cloth armor");
                UnavailableSkill("Leather armor");
                break;
            #endregion
            #region WIZARD CLASSES
            case "Elementalist":
                AdvancedSkill("Fire Magic");
                AdvancedSkill("Air Magic");
                AdvancedSkill("Water Magic");
                AdvancedSkill("Earth Magic");
                AdvancedSkill("Mana Conversion");
                AdvancedSkill("Magic Defense");
                LearnSkill("Cloth armor");
                UnavailableSkill("Death Magic");
                UnavailableSkill("Life Magic");
                UnavailableSkill("Creature Enchant");
                UnavailableSkill("Item Enchant");
                UnavailableSkill("Finesse Weapons");
                UnavailableSkill("One Hand Weapons");
                UnavailableSkill("Missile Weapons");
                UnavailableSkill("Plate armor");
                UnavailableSkill("Chain armor");
                UnavailableSkill("Leather armor");
                break;
            case "Sorcerer":
                AdvancedSkill("Mana Conversion");
                AdvancedSkill("Magic Defense");
                AdvancedSkill("Wands");
                LearnSkill("Cloth armor");
                UnavailableSkill("Death Magic");
                UnavailableSkill("Life Magic");
                UnavailableSkill("Creature Enchant");
                UnavailableSkill("Item Enchant");
                UnavailableSkill("Finesse Weapons");
                UnavailableSkill("Missile Weapons");
                UnavailableSkill("Plate armor");
                UnavailableSkill("Chain armor");
                UnavailableSkill("Leather armor");
                break;
            case "Necromancer":
                SpecializeSkill("Death Magic");
                AdvancedSkill("Mana Conversion");
                AdvancedSkill("Magic Defense");
                AdvancedSkill("Trinkets");
                LearnSkill("Cloth armor");
                LearnSkill("One Hand Weapons");
                UnavailableSkill("Life Magic");
                UnavailableSkill("Fire Magic");
                UnavailableSkill("Air Magic");
                UnavailableSkill("Water Magic");
                UnavailableSkill("Earth Magic");
                UnavailableSkill("Creature Enchant");
                UnavailableSkill("Item Enchant");
                UnavailableSkill("Missile Weapons");
                UnavailableSkill("Plate armor");
                UnavailableSkill("Chain armor");
                UnavailableSkill("Leather armor");
                break;
            case "Charmer":
                SpecializeSkill("Creature Enchant");
                SpecializeSkill("Item Enchant");
                AdvancedSkill("Mana Conversion");
                AdvancedSkill("Magic Defense");
                LearnSkill("Cloth armor");
                UnavailableSkill("Death Magic");
                UnavailableSkill("Life Magic");
                UnavailableSkill("Fire Magic");
                UnavailableSkill("Air Magic");
                UnavailableSkill("Water Magic");
                UnavailableSkill("Earth Magic");
                UnavailableSkill("Missile Weapons");
                UnavailableSkill("Plate armor");
                UnavailableSkill("Chain armor");
                UnavailableSkill("Leather armor");
                break;
                #endregion
        }
        AssignSkill();
    }
    private void DoubleSpecSkill(string skill)
    {
        for (int i = 0; i < GameManager.MasterSkillList.Count; i++)
        {
            if (GameManager.MasterSkillList[i].SkillName == skill)
            {
                Skill newSkill = new Skill(skill, GameManager.MasterSkillList[i].SkillCostAdvance, GameManager.MasterSkillList[i].SkillCostSpec, 1, GameManager.MasterSkillList[i].SkillIcon, Skill.Category.SPECIALIZED);
                newSkill.SkillProficiency = 24;
                playerSkillList.Add(newSkill);
                return;
            }
        }
    }
    private void SpecializeSkill(string skill)
    {
        for (int i = 0; i < GameManager.MasterSkillList.Count; i++)
        {
            if (GameManager.MasterSkillList[i].SkillName == skill)
            {
                Skill newSkill = new Skill(skill,  GameManager.MasterSkillList[i].SkillCostAdvance, GameManager.MasterSkillList[i].SkillCostSpec, 1, GameManager.MasterSkillList[i].SkillIcon, Skill.Category.SPECIALIZED);
                newSkill.SkillProficiency = 16;
                playerSkillList.Add(newSkill); return;
            }                
        }
    }
    private void AdvancedSkill(string skill)
    {
        for (int i = 0; i < GameManager.MasterSkillList.Count; i++)
        {
            if (GameManager.MasterSkillList[i].SkillName == skill)
            {
                Skill newSkill = new Skill(skill,  GameManager.MasterSkillList[i].SkillCostAdvance, GameManager.MasterSkillList[i].SkillCostSpec, 1, GameManager.MasterSkillList[i].SkillIcon, Skill.Category.ADVANCED);
                newSkill.SkillProficiency = 8;
                playerSkillList.Add(newSkill); return;
            }
        }
    }
    private void LearnSkill(string skill)
    {
        for (int i = 0; i < GameManager.MasterSkillList.Count; i++)
        {
            if (GameManager.MasterSkillList[i].SkillName == skill)
            {
                Skill newSkill = new Skill(skill,  GameManager.MasterSkillList[i].SkillCostAdvance, GameManager.MasterSkillList[i].SkillCostSpec, 1, GameManager.MasterSkillList[i].SkillIcon, Skill.Category.LEARNED);
                newSkill.SkillProficiency = 1;
                playerSkillList.Add(newSkill);
                return;
            }
        }
    }
    private void UnavailableSkill(string skill)
    {
        for (int i = 0; i < GameManager.MasterSkillList.Count; i++)
        {
            if (GameManager.MasterSkillList[i].SkillName == skill)
            {
                Skill newSkill = new Skill(skill,  GameManager.MasterSkillList[i].SkillCostAdvance, GameManager.MasterSkillList[i].SkillCostSpec, -1, GameManager.MasterSkillList[i].SkillIcon, Skill.Category.UNAVAILABLE);
                newSkill.SkillProficiency = 0;
                playerSkillList.Add(newSkill);
                return;
            }
        }
    }
    public void AssignSkill() {
        for (int i = 0; i < playerSkillList.Count; i++) {
            GameObject go = Instantiate(skillTabPrefab);
            go.name = playerSkillList[i].SkillName + " Skill";
            //go.GetComponentInChildren<Image>().sprite = playerSkillList[i].SkillIcon.sprite;
            go.GetComponentInChildren<Text>().text = playerSkillList[i].SkillName;
            if (playerSkillList[i].SkillCategory == Skill.Category.SPECIALIZED)
            {
                go.transform.SetParent(SpecializePanel.transform);               
            }
            else if (playerSkillList[i].SkillCategory == Skill.Category.ADVANCED)
            {
                go.transform.SetParent(AdvancedPanel.transform);
            }
            else if (playerSkillList[i].SkillCategory == Skill.Category.LEARNED)
            {
                go.transform.SetParent(LearnedPanel.transform);
            }
            else if (playerSkillList[i].SkillCategory == Skill.Category.AVAILABLE)
            {
                go.transform.SetParent(AvailablePanel.transform);
            }
            else
            {
                go.transform.SetParent(UnavailablePanel.transform);
            }
        }
    }
    #endregion
}
    //#region Faction Dictionary
    //void FactionInit() {
    //    if (factionList != null) return;
    //    factionList = new Dictionary<string, int>();
    //}
    //public int GetFaction(string faction) {
    //    FactionInit();
    //    if (factionList.ContainsKey(faction) == false)
    //        return 0;
    //    return factionList[faction];
    //}
    //public void SetFaction(string faction, int value) {
    //    FactionInit();
    //    if (factionList.ContainsKey(faction) == false)
    //        return;
    //    factionList[faction] = value;
    //}
    //public void ChangeFaction(string faction, int value) {
    //    FactionInit();
    //    int currFaction = GetFaction(faction);
    //    SetFaction(faction, currFaction + value);
    //}
    //#endregion