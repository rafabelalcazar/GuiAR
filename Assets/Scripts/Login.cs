using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class Login : MonoBehaviour
{
    public InputField usuarioTxt;
    public InputField passTxt;
    public Text msg;

    public void Logear()
    {
        Debug.Log(usuarioTxt.text);
        Debug.Log(passTxt.text);
        string query = "`users` WHERE `mail` LIKE '" + usuarioTxt.text + "' AND `password` LIKE '" + passTxt.text + "'"; 
        DBHandler adminMYSQL = GameObject.Find("DBManager").GetComponent<DBHandler>();
        MySqlDataReader resultado = adminMYSQL.Select(query);

        if (resultado.HasRows)
        {
            Debug.Log("Usuario encontrado");
            msg.text = "Bienvenido";
            resultado.Close();
        }
        else
        {
            Debug.Log("Usuario o contraseña incorrecto");
            msg.text = "Usuario o contraseña incorrectos";
            resultado.Close();
        }


    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
