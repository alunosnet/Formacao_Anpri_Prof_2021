using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] float velocidadeAndar = 1;
    [SerializeField] float velocidadeRodar = 1;
    float inputAndar;
    float inputRodar;
    CharacterController _characterController;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        inputAndar = Input.GetAxis("Vertical");
        inputRodar = Input.GetAxis("Horizontal");

        Vector3 novaPosicao = transform.forward * inputAndar*velocidadeAndar;
        novaPosicao.y += Physics.gravity.y;

        _characterController.Move(novaPosicao * Time.deltaTime);
        _characterController.transform.Rotate(_characterController.transform.up * inputRodar* velocidadeRodar * Time.deltaTime);
    }
}
