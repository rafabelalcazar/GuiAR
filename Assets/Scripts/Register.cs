using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class Register : MonoBehaviour
{
    public InputField nombreTxt;
    public InputField apellidoTxt;
    public InputField emailTxt;
    public InputField passwordTxt;
    public InputField paisTxt;

    public void Registrar()
    {
        Debug.Log(nombreTxt);
        Debug.Log(apellidoTxt);
        Debug.Log(emailTxt);
        Debug.Log(passwordTxt);
        Debug.Log(paisTxt); 

        string query = "`users` WHERE `mail` LIKE '" + emailTxt.text + "'";
        DBHandler adminMYSQL = GameObject.Find("DBManager").GetComponent<DBHandler>();
        MySqlDataReader Resultado = adminMYSQL.Select(query);

        if (Resultado.HasRows)
        {
            Debug.Log("El usuario ya existe");
            Resultado.Close();
        }
        else
        {
            Resultado.Close();
            query = "`users` (`id`, `name`, `last_name`, `mail`, `password`, `pais`, `preferences`) VALUES (NULL, '"+ nombreTxt.text + "', '" + apellidoTxt.text + "', '" + emailTxt.text + "', '" + passwordTxt.text + "', '" + paisTxt.text + "', NULL)";
            Resultado = adminMYSQL.Insert(query);
            Debug.Log("El nuevo usuario ha sido creado");
            Resultado.Close();
            //AbrirCerrarRegistro();
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
