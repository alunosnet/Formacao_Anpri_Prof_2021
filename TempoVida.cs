using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoVida : MonoBehaviour
{
    [SerializeField] float SegundosVida = 10;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, SegundosVida);
    }

    
}
