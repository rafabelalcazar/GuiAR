using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class escena : MonoBehaviour

{

    public string nombre;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cargarescena() {
        SceneManager.LoadScene(nombre);

    }
}
