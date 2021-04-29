using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuDefinicoes : MonoBehaviour
{
    [SerializeField] Dropdown ddQualidadeGrafica;
    [SerializeField] Dropdown ddResolucao;
    [SerializeField] Toggle tgFullScreen;

    public void NovaResolucao(int i)
    {
        string resolucaoEscolhida = ddResolucao.options[i].text;
        string[] items = resolucaoEscolhida.Split('x');
        int largura = int.Parse(items[0]);
        int altura = int.Parse(items[1]);
        Screen.SetResolution(largura, altura, tgFullScreen.isOn);
        //TODO: guardar alterações
    }

    public void NovaQualidade(int i)
    {
        QualitySettings.SetQualityLevel(i, true);
        //TODO: guardar alterações
    }

    public void FullScreenAlterado()
    {
        Screen.fullScreen = tgFullScreen.isOn;
        //TODO: guardar alterações
    }
    public void Voltar()
    {
        SceneManager.LoadScene("MenuPrincipal");
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
