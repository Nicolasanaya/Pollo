using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    
    public void escena1 (string nombreescena)
    {
        SceneManager.LoadScene(1);
    }

    public void escena2(string nombreescena)
    {
        SceneManager.LoadScene(2);
    }

    public void EscenaPrincipal()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void Jugar()
    {
        Time.timeScale = 1;
    }
}
