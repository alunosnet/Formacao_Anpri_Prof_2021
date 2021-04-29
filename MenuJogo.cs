using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuJogo : MonoBehaviour
{
    [SerializeField] GameObject _menuJogo;
    [SerializeField] FirstPersonController _player;
    [SerializeField] GameObject _menuPerdeu;
    public void Recomecar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Continuar()
    {
        ContinuarJogo();
    }
    public void Sair()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void NivelSeguinte()
    {
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<FirstPersonController>();
        Time.timeScale = 1;
        //guardar o index do nível
        var ultimoindice = PlayerPrefs.GetInt("nivel", 2);
        var indice = SceneManager.GetActiveScene().buildIndex;
        if (indice > ultimoindice)
        {
            PlayerPrefs.SetInt("nivel", indice);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null)
        {
            _menuPerdeu.SetActive(true);
            Time.timeScale = 0;
            _player.m_MouseLook.SetCursorLock(false);
            return;
        }
        if (Input.GetButtonDown("Cancel"))
        {
            if (_menuJogo.activeSelf)
            {
                ContinuarJogo();
            }
            else
            {
                PausarJogo();
            }
        }
    }

    private void PausarJogo()
    {
        _menuJogo.SetActive(true);
        Time.timeScale = 0;
        _player.m_MouseLook.SetCursorLock(false);
    }

    private void ContinuarJogo()
    {
        _menuJogo.SetActive(false);
        Time.timeScale = 1;
        _player.m_MouseLook.SetCursorLock(true);
    }
}
