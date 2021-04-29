using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirFecharPorta : MonoBehaviour
{
    [SerializeField] Transform Fechado;
    [SerializeField] Transform Aberto;
    [SerializeField] int estado = 0; //0-Fechado 1-Abrir 2-Aberto 3-Fechar
    [SerializeField] float tempo = 2; //tempo em segundos
    [SerializeField] float PosicaoAtual = 0; //posicao em percentagem da porta
    [SerializeField] float Velocidade = 0;  //velocidade do movimento da porta
    // Start is called before the first frame update
    void Start()
    {
        Velocidade = 1 / tempo;
    }

    // Update is called once per frame
    void Update()
    {
        if (estado == 0)
            Invoke("AbrirPorta", 2);
        if (estado == 2)
            Invoke("FecharPorta", 2);
        if (estado == 1)
            Abrir();
        if (estado == 3)
            Fechar();
    }
    public void SetEstado(int estado)
    {
        this.estado = estado;
    }
    void AbrirPorta()
    {
        SetEstado(1);
    }
    void FecharPorta()
    {
        SetEstado(3);
    }
    void Fechar()
    {
        transform.position = Vector3.Lerp(Aberto.position, Fechado.position, PosicaoAtual);
        PosicaoAtual += Velocidade * Time.deltaTime;
        if (PosicaoAtual > 1)
        {
            estado = 0;
            PosicaoAtual = 0;
        }
    }
    void Abrir()
    {
        transform.position = Vector3.Lerp(Fechado.position, Aberto.position, PosicaoAtual);
        PosicaoAtual += Velocidade * Time.deltaTime;
        if (PosicaoAtual > 1)
        {
            estado = 2;
            PosicaoAtual = 0;
        }
    }
}
