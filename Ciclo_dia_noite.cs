using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciclo_dia_noite : MonoBehaviour
{
    [Header("Duração do dia em minutos")]
    [SerializeField] float DuracaoDia = 1.0f;
    [SerializeField] Vector3 VetorRotacao;
    float VelocidadeRotacao;

    // Start is called before the first frame update
    void Start()
    {
        VelocidadeRotacao = 360 / (DuracaoDia * 60);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(VetorRotacao * VelocidadeRotacao * Time.deltaTime);
    }
}
