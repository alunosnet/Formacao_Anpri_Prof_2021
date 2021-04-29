using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorFrutaMagica : MonoBehaviour
{
    [SerializeField] float TempoParaGerarFruta = 5;
    [SerializeField] GameObject PrefabFruto;
    float TempoParaProximoFruto = 0;

    // Start is called before the first frame update
    void Start()
    {
        TempoParaProximoFruto = TempoParaGerarFruta;
    }

    // Update is called once per frame
    void Update()
    {
        TempoParaProximoFruto -= Time.deltaTime;
        if (TempoParaProximoFruto <= 0)
        {
            Vector3 posicao = new Vector3(
                this.transform.position.x + Random.Range(-1, 1),
                this.transform.position.y + Random.Range(-1, 1),
                this.transform.position.z + Random.Range(-1, 1));
            Instantiate(PrefabFruto, posicao, this.transform.rotation);
            TempoParaProximoFruto = TempoParaGerarFruta + Random.Range(0, 10);
        }
    }
}
