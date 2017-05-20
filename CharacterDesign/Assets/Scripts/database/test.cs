using UnityEngine;
using database;

public class test : MonoBehaviour {

    void Start()     {
        GameData.Load();

        GameData.actors.Add(new ActorData("Declan", "english man", 100.0f) { id = 1 });
        GameData.actors.Add(new ActorData("Dean", "american man", 100.0f) { id = 2 });
        GameData.actors.Add(new ActorData("Lee", "japanese man", 100.0f) { id = 3 });

        GameData.items.Add(new ItemData("item 1", "this is item 1", 20) { id = 1 });
        GameData.weapons.Add(new WeaponData("weapon 1", "this is weapon 1", 20, 5) { id = 1 });
        GameData.armor.Add(new ArmorData("armor 1", "this is armor 1", 20, 20, 20) { id = 1 });


        //for (int ac = 0; ac < GameData.actors.Length; ac++)
        //    Debug.LogFormat("{0}: {1}", GameData.actors.GetAt(ac).name, GameData.actors.GetAt(ac).description);
        //for (int ac = 0; ac < GameData.items.Length; ac++)
        //    Debug.LogFormat("{0}: {1}", GameData.items.GetAt(ac).name, GameData.items.GetAt(ac).description);
        //for (int ac = 0; ac < GameData.weapons.Length; ac++)
        //    Debug.LogFormat("{0}: {1}", GameData.weapons.GetAt(ac).name, GameData.weapons.GetAt(ac).description);
        //for (int ac = 0; ac < GameData.armor.Length; ac++)
        //    Debug.LogFormat("{0}: {1}", GameData.armor.GetAt(ac).name, GameData.armor.GetAt(ac).description);

        GameData.Save();
    }
}
