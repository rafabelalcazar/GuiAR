﻿using UnityEngine;
using MySql.Data.MySqlClient;

public class DBHandler : MonoBehaviour
{
    public string DBServer;
    public string DBName;
    public string DBUser;
    public string DBPass;

    private string conectData;
    private MySqlConnection conexion;
    // Start is called before the first frame update
    void Start()
    {
        conectData = "Server=" + DBServer 
                +";Database=" + DBName
                +";User=" + DBUser
                +";Pwd="+ DBPass
                +";";
        conectMyServer();
    }

    private void conectMyServer()
    {
        conexion = new MySqlConnection(conectData);
        try
        {
            conexion.Open();
            Debug.Log("Conexion exitosa con DB");
        }
        catch (System.Exception err)
        {
            Debug.Log(err);
            Debug.LogError("Imposible conectar con DB" + err);
        }
    }

    public MySqlDataReader Select(string select)
    {
        MySqlCommand cmd = conexion.CreateCommand();
        cmd.CommandText = "SELECT * FROM" + select;
        MySqlDataReader resultado = cmd.ExecuteReader();
        return resultado;
    }
}
