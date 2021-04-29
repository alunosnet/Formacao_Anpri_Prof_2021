using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Test : MonoBehaviour
{
    [SerializeField] float velocidade=5;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        /*if(rigidbody!=null)
            rigidbody.useGravity = false;*/
        //rigidbody.velocity = transform.forward * velocidade;
        //adicionar um componente
        /*var audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSource.volume = 0.5f;

        Destroy(gameObject.GetComponent<AudioSource>(),3);*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position += transform.forward*Time.deltaTime*velocidade;
        //rigidbody.AddForce(transform.forward * velocidade);
        //transform.Translate(transform.forward * velocidade * Time.deltaTime);
        rigidbody.MovePosition(transform.position + (transform.forward * velocidade * Time.deltaTime)); 
    }
}
