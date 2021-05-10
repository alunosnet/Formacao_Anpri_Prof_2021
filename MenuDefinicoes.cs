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
        PlayerPrefs.SetString("ScreenResolution", resolucaoEscolhida);
        PlayerPrefs.Save();
    }

    public void NovaQualidade(int i)
    {
        QualitySettings.SetQualityLevel(i, true);
        PlayerPrefs.SetInt("QualitySettings", i);
        PlayerPrefs.Save();
    }

    public void FullScreenAlterado()
    {
        Screen.fullScreen = tgFullScreen.isOn;
        PlayerPrefs.SetInt("FullScreen", Screen.fullScreen == true ? 1 : 0);
        PlayerPrefs.Save();
    }
    public static void LoadSettings()
    {
        //fullscreen
        Screen.fullScreen = PlayerPrefs.GetInt("FullScreen", 1) == 1 ? true : false;

        //resolução
        string resolucaoEscolhida = PlayerPrefs.GetString("ScreenResolution", "800x600");
        string[] items = resolucaoEscolhida.Split('x');
        int largura = int.Parse(items[0]);
        int altura = int.Parse(items[1]);
        Screen.SetResolution(largura, altura, Screen.fullScreen);

        //qualidade
        int i = PlayerPrefs.GetInt("QualitySettings", 3);
        QualitySettings.SetQualityLevel(i, true);
    }
    public void Voltar()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //preparar UI
        tgFullScreen.isOn= PlayerPrefs.GetInt("FullScreen", 1) == 1 ? true : false;

        ddQualidadeGrafica.value= PlayerPrefs.GetInt("QualitySettings", 3);

        for(int i = 0; i < ddResolucao.options.Count; i++)
        {
            if(ddResolucao.options[i].text== PlayerPrefs.GetString("ScreenResolution", "800x600"))
            {
                ddResolucao.value = i;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
