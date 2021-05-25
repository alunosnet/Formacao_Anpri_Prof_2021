using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiraVida : MonoBehaviour
{
    [SerializeField] int ValorVidaATirar = 10;
    private void OnTriggerEnter(Collider other)
    {
        TirarVida(other.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        TirarVida(collision.gameObject);
        
    }
    private void TirarVida(GameObject other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "NPC")
        {
            Vida vida = other.transform.GetComponent<Vida>();
            if (vida != null)
            {
                vida.TiraVida(ValorVidaATirar);
            }
            if(transform.tag.Equals("Bola")) Destroy(this.gameObject);
        }
        
    }
}
