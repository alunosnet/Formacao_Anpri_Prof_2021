using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaVida : MonoBehaviour
{
    [SerializeField] int ValorVidaGanhar = 10;
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
                vida.GanhaVida(ValorVidaGanhar);
            }
            Destroy(this.gameObject);
        }
    }
}
