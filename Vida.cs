using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    [SerializeField] int vida = 100;
    AudioSource _audioSource;
    [SerializeField] AudioClip SomPerderVida;
    [SerializeField] AudioClip SomGanharVida;
    [SerializeField] Text txtVidaPlayer;

    public int GetVida()
    {
        return vida;
    }
    public void TiraVida(int valor)
    {
        vida -= valor;
        AtualizarUI();
        if (_audioSource!=null && SomPerderVida!=null)
        {
            _audioSource.clip = SomPerderVida;
            _audioSource.Play();
        }
        if (vida <= 0)
        {
            //Debug.Log("Morreu!");
            Destroy(gameObject.transform.root.gameObject);
        }
    }
    public void GanhaVida(int valor)
    {
        vida += valor;
        if (vida > 100)
            vida = 100;
        AtualizarUI();
        if (_audioSource != null && SomGanharVida != null)
        {
            _audioSource.clip = SomGanharVida;
            _audioSource.Play();
        }
    }

    private void AtualizarUI()
    {
        if(txtVidaPlayer!=null)
            txtVidaPlayer.text = vida.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = false;
        _audioSource.spatialBlend = 1;

        if(transform.tag=="Player")
            txtVidaPlayer = GameObject.FindGameObjectWithTag("VidaPlayer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
