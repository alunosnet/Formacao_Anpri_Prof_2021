using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Atirar : MonoBehaviour
{
    [SerializeField] Transform _pontoAtirar;
    [SerializeField] GameObject _modeloBola;
    [SerializeField] float _forcaAtirar = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        if (Time.timeScale == 0) return;
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            var objeto = Instantiate(_modeloBola, _pontoAtirar.position, Quaternion.identity);
            objeto.GetComponent<Rigidbody>().AddForce(transform.forward * _forcaAtirar);
            Destroy(objeto, 5);
        }
    }
}
