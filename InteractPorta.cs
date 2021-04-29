using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPorta : MonoBehaviour,IInteract
{
    [SerializeField] bool Fechado = true;
    Animator _animator;
    public void Action()
    {
        if (Fechado)
        {
            _animator.SetTrigger("abre");
        }
        else
        {
            _animator.SetTrigger("fecha");
        }
        Fechado = !Fechado;
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = transform.root.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
