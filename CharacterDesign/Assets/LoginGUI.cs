using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginGUI : MonoBehaviour {
    public DatabaseHandler SQLHandler;

	void OnGUI() {
        GUI.Label(new Rect(10, 10, 300, 30), "SQL State: "+SQLHandler.GetConnectionState());
	}
	
	// Update is called once per frame
	void Update () {
		
	}  
}
