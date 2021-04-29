using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void Jogar()
    {
        SceneManager.LoadScene("nivel1");
    }
    public void Definicoes()
    {
        SceneManager.LoadScene("definicoes");
    }
    public void Sair()
    {
        Application.Quit();
    }
    public void Continuar()
    {
        var indice = PlayerPrefs.GetInt("nivel", 2);
        SceneManager.LoadScene(indice);
    }
}
