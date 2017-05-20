using UnityEngine;

public class Stat : MonoBehaviour {
    protected string statName;
    protected int statValue;

    public string StatName {
        get { return statName; }
        set { statName = value; }
    }
    public int StatValue {
        get { return statValue; }
        set { statValue = value; }
    }
    public Stat(int value)
    {
        statValue = value;
    }
    public Stat(string name, int value)
    {
        statName = name;
        statValue = value;
    }
}
