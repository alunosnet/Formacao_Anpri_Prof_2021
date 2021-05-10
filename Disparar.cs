using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Disparar : MonoBehaviour
{
    [SerializeField] Camera _fpsCamera;
    [SerializeField] float _distancia = 50f;
    [SerializeField] int _dano = 10;
    [SerializeField] float _forca = 50;
    AudioSource _audioSource;
    bool Disparou = false;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Disparou = true;
        }
    }
    private void FixedUpdate()
    {
        if (Disparou)
        {
            if (_audioSource != null)
                _audioSource.Play();
            Vector3 origem = _fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
            RaycastHit hit;
            if (Physics.Raycast(origem, _fpsCamera.transform.forward, out hit, _distancia))
            {
                var objeto = hit.collider.GetComponent<Vida>();
                if (objeto != null)
                    objeto.TiraVida(_dano);

                var rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 direcao = hit.collider.transform.position - transform.position;
                    rb.AddForceAtPosition(direcao.normalized * _forca, hit.point);
                }
            }
            Disparou = false;
        }
    }
}
