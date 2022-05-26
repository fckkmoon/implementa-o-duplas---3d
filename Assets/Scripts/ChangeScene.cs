using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string NomeDaCena;
    
    public void ChangeS()
    {
        SceneManager.LoadScene(NomeDaCena);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
