using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System;

public class DatabaseHandler : MonoBehaviour {
    public string host, database, user, password;
    public bool pooling = true;

    private string connectionString;
    private SqlConnection conn = null;
    private SqlCommand cmd = null;
    private SqlDataReader rdr = null;

    private MD5 _md5Hash;

    void Awake()
    {
        DontDestroyOnLoad(this);
        connectionString = "Server=" + host + ";Database=" + database + ";User=" + user + ";Password=" + password + ";Pooling=";
        if (pooling)
            connectionString += "true";
        else
            connectionString += "false";
        try
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            Debug.Log("Sql State: " + conn.State);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    void OnApplicationQuit()
    {
        if(conn != null)
        {
            if(conn.State.ToString() != "Closed")
            {
                conn.Close();
                Debug.Log("SQL connection closed");
            }
            conn.Dispose();
        }
    }
    public string GetConnectionState()
    {
        return conn.State.ToString();
    }
}
