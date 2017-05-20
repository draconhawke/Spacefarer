using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour {
    public GameObject ButtonPanel;
    public GameObject LoginPanel;
    public GameObject RegistrationPanel;
    public GameObject OptionPanel;

	void Start () {
        LoginPanel.SetActive(false);
        RegistrationPanel.SetActive(false);
        OptionPanel.SetActive(false);
	}	

    public void Login_OnClick()
    {
        ButtonPanel.SetActive(false);
        LoginPanel.SetActive(true);
        RegistrationPanel.SetActive(false);
        OptionPanel.SetActive(false);
    }
    public void Registration_OnClick()
    {
        ButtonPanel.SetActive(false);
        LoginPanel.SetActive(false);
        RegistrationPanel.SetActive(true);
        OptionPanel.SetActive(false);
    }
    public void Option_OnClick()
    {
        ButtonPanel.SetActive(false);
        LoginPanel.SetActive(false);
        RegistrationPanel.SetActive(false);
        OptionPanel.SetActive(true);
    }
}
