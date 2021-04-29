using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Camera _fpsCamera;
    [SerializeField] float _distancia = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 origem = _fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
            RaycastHit hit;
            if (Physics.Raycast(origem, _fpsCamera.transform.forward, out hit, _distancia))
            {
                var objeto = hit.collider.GetComponent<IInteract>();
                if (objeto != null)
                    objeto.Action();
            }
        }
    }
}
