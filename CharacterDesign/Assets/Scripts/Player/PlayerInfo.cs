using UnityEngine;
using System.Collections.Generic;

public class PlayerInfo : MonoBehaviour {
	public static string PlayerName { get; set; }
    public static int PlayerLevel { get; set; }
    public static string PlayerGender { get; set; }
    public static string PlayerRace { get; set; }
    public static BaseClass PlayerClass { get; set; }
    public static BaseResist PlayerResist { get; set; }
    public static List<Skill> PlayerSkillList { get; set; }
    public static string PlayerSpecialization { get; set; }

    //public static int Strength { get; set; }
    //public static int Dexterity { get; set; }
    //public static int Agility { get; set; }
    //public static int Constitution { get; set; }
    //public static int Wisdom { get; set; }
    //public static int Intelligence { get; set; }
    //public static int Charisma { get; set; }

    //public static Stat FireResist { get; set; }
    //public static Stat EarthResist { get; set; }
    //public static Stat AirResist { get; set; }
    //public static Stat WaterResist { get; set; }
    //public static Stat DeathResist { get; set; }
    //public static Stat LifeResist { get; set; }

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
