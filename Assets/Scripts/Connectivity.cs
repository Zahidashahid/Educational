using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Data.SqlClient;
public class Connectivity : MonoBehaviour
{
    private string connectitionstring;f

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting to database");
        connectitionstring = @"Data Source = 127.0.0.1;
        user id = sa;
        password = sdfg;
        Intial Catalog = login;";

        SqlConnection dbConnectition = new SqlConnection(connectitionstring);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
