using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_debug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("função start. Objeto " + this.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Função update. Localização " + this.gameObject.transform.position);
        Debug.Log("Posição local " + this.gameObject.transform.localPosition);
    }
}
