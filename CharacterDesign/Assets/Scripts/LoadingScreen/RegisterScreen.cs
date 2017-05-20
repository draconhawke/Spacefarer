using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class RegisterScreen : MonoBehaviour {
    public GameObject accountName;
    public GameObject password;
    public GameObject email;
    public GameObject confirmPassword;
    private string AccountName;
    private string Password;
    private string Email;
    private string ConfirmPass;
    private string form;
    private bool EmailValid;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (accountName.GetComponent<InputField>().isFocused)
            {
                email.GetComponent<InputField>().Select();
            }
            if (email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
            if (password.GetComponent<InputField>().isFocused)
            {
                confirmPassword.GetComponent<InputField>().Select();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Password != string.Empty && AccountName != string.Empty && Email != string.Empty && ConfirmPass != string.Empty)
                Register();
        }
        AccountName = accountName.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        ConfirmPass = confirmPassword.GetComponent<InputField>().text;
	}
    public void Register()
    {
        Debug.Log("Registered user");
    }
}
