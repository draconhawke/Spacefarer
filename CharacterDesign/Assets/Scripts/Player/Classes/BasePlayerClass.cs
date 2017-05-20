public class BasePlayerClass {
    private string playerName;
    private int playerLevel;
    private BaseClass playerClass;
    private BaseResist playerResist;

    private int strength;
    private int agility;
    private int dexterity;
    private int constitution;
    private int wisdom;
    private int intelligence;
    private int charisma;

    private int fireResist;
    private int earthResist;
    private int airResist;
    private int waterResist;
    private int deathResist;
    private int lifeResist;

    #region Setters & Getters
    public BaseClass PlayerClass {
        get { return playerClass; }
        set { playerClass = value; }
    }
    public BaseResist PlayerResist {
        get { return playerResist; }
        set { playerResist = value; }
    }
    public string PlayerName {
        get { return playerName; }
        set { playerName = value; }
    }
    public int PlayerLevel {
        get { return playerLevel; }
        set { playerLevel = value; }
    }
    //attributes
    public int Strength {
        get { return strength; }
        set { strength = value; }
    }
    public int Agility {
        get { return agility; }
        set { agility = value; }
    }
    public int Dexterity {
        get { return dexterity; }
        set { dexterity = value; }
    }
    public int Constitution {
        get { return constitution; }
        set { constitution = value; }
    }
    public int Wisdom  {
        get { return wisdom; }
        set { wisdom = value; }
    }
    public int Intelligence {
        get { return intelligence; }
        set { intelligence = value; }
    }
    public int Charisma {
        get { return charisma; }
        set { charisma = value; }
    }
    //resists
    public int FireResist {
        get { return fireResist; }
        set { fireResist = value; }
    }
    public int EarthResist {
        get { return earthResist; }
        set { earthResist = value; }
    }
    public int AirResist {
        get { return airResist; }
        set { airResist = value; }
    }
    public int WaterResist {
        get { return waterResist; }
        set { waterResist = value; }
    }
    public int DeathResist {
        get { return deathResist; }
        set { deathResist = value; }
    }
    public int LifeResist {
        get { return lifeResist; }
        set { lifeResist = value; }
    }
    #endregion
    public BasePlayerClass() { }
}