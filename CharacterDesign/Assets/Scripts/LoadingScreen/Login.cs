using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Spacefarer
{
    public class Login : MonoBehaviour {
        public static string PlayerAccount;
        public InputField txtAccount;
        public InputField txtPassword;
        public Text lblMessage;
        public GameObject buttonPanel;
        public GameObject loginPanel;

        void Start()
        {
            lblMessage.text = string.Empty;
            Clear();
        }
        public void Clear()
        {
            txtAccount.text = string.Empty;
            txtPassword.text = string.Empty;
            lblMessage.text = string.Empty;
        }
        public void Enter()
        {
            if (txtAccount.text == string.Empty)
            {
                lblMessage.text = "Please enter a valid account name/password";
                return;
            }
            if (VerifyAccount(txtAccount.text, txtPassword.text))
            {
                PlayerAccount = txtAccount.text;
                SceneManager.LoadScene("CharacterCreation");
            }
        }
        public bool VerifyAccount(string account, string password)
        {
            DatabaseManager dm = new DatabaseManager();
            //check for account in database
            string SQL = "Select * from Account where AccountName='" + account + "'";
            var dt = dm.GetAccount(SQL);
            if (dt.Rows.Count == 0)
            {
                lblMessage.text = "Account does not exist. Try again";
                return false;
            }
            //check if database has account & password is correct, log into account
            SQL = "Select Password from Account where AccountName='" + account + "'and Password='" + password + "'";
            dt = dm.GetAccount(SQL);
            if (dt.Rows.Count == 1) //password is correct
                return true;
            lblMessage.text = "invalid password";
            return false;                
        }
        public void Cancel()
        {
            Clear();
            buttonPanel.SetActive(true);
            loginPanel.SetActive(false);
        }
    }
}
