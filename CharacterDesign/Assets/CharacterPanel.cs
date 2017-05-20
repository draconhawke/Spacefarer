using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spacefarer;

public class CharacterPanel : MonoBehaviour {
    public int activePlayer = -1;
    public Button[] playerAccount;
    public Button enterBtn, actionBtn;

    void Start()
    {        
        LoadCharacterList();
    }
    void LoadCharacterList()
    {
        DatabaseManager dm = new DatabaseManager();
        //check for account in database
        string SQL = "Select * from CharacterList where AccountName='" + Login.PlayerAccount  + "'";
        var dt = dm.GetAccount(SQL);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if(dt.Rows[i]["CharacterName"] == null)
                playerAccount[i].GetComponent<Text>().text = "\n\n CREATE PLAYER";
            else
            {
                string charName = dt.Rows[i]["CharacterName"].ToString();
                string charRace = dt.Rows[i]["CharacterRace"].ToString();
                string charLevel = dt.Rows[i]["CharacterLevel"].ToString();
                string charGender = dt.Rows[i]["CharacterGender"].ToString();
                string charZone = dt.Rows[i]["CharacterZone"].ToString();
                playerAccount[i].GetComponent<Text>().text = string.Format("{0}\n{1}\n{2}\n{3}\n{4}", charName, charRace,charLevel,charGender,charZone);
            }
        }
    }
    void EnterWorld(int c)
    {
        Debug.Log("Loading player #"+activePlayer);
    }
}
