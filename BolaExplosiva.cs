using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaExplosiva : MonoBehaviour
{
    [SerializeField] float raioExplosao = 10.0f;
    [SerializeField] float forcaExplosao = 10.0f;
    [SerializeField] int danoExplosao = 50;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] GameObject _efeitoExplosao;
    

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Invoke("Explode", 2);
    }

    public void Explode()
    {
        _audioSource.Play();
        Vector3 posicaoExplosao = transform.position;
        Collider[] colliders = Physics.OverlapSphere(posicaoExplosao, raioExplosao);
        foreach(Collider obj in colliders)
        {
            if (obj is CharacterController) continue;
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(forcaExplosao, posicaoExplosao, raioExplosao, 3.0f);

            Vida vida = obj.GetComponent<Vida>();
            if (vida != null)
                vida.TiraVida(danoExplosao);
        }
        if (_efeitoExplosao != null)
        {
            var efeito=Instantiate(_efeitoExplosao, transform.position, Quaternion.identity);
            //efeito.GetComponent<ParticleSystem>().Play();
        }
        //Destroy(this.gameObject);
        //esconder a bola
        GetComponent<Renderer>().enabled = false;
        Destroy(this.gameObject, 2);
    }
}
