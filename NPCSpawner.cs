using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] float Intervalo = 5;
    [SerializeField] GameObject Modelo;
    [SerializeField] Transform[] Pontos;
    float NextSpawn=0;
    // Start is called before the first frame update
    void Start()
    {
        NextSpawn = Intervalo;
    }

    // Update is called once per frame
    void Update()
    {
        NextSpawn -= Time.deltaTime;
        if (NextSpawn <= 0)
        {
            Vector3 posicao = new Vector3(transform.position.x + Random.Range(-1, 1),
                                        transform.position.y,
                                        transform.position.z + Random.Range(-1, 1));
            var objeto=Instantiate(Modelo, posicao, Quaternion.identity);
            objeto.GetComponent<MoveNPC>().Pontos = Pontos;
            NextSpawn = Intervalo + Random.Range(0, 10);
        }
    }
}
