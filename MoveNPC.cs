using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveNPC : MonoBehaviour
{
    public enum NPCEstados { Idle = 0, Patrulha = 1, Atacar = 2 };
    [SerializeField] Transform[] Pontos;
    [SerializeField] int ProximoPonto = 0;
    [SerializeField] float Velocidade = 3;
    [SerializeField] float DistanciaMinima = 1;
    [SerializeField] Color corVePlayer;
    Color corBase;
    Renderer _renderer;
    GameObject _player;
    NavMeshAgent _navmeshagent;
    public NPCEstados estado = NPCEstados.Idle; 
    [SerializeField] bool inimigo = false;
    [SerializeField] float DistanciaAtaque = 1;
    Animator _animator;
    Vida _vida;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        if(_renderer==null)
            _renderer = GetComponentInChildren<Renderer>();
        corBase = _renderer.material.color;
        _player = GameObject.FindGameObjectWithTag("Player");
        _navmeshagent = GetComponent<NavMeshAgent>();
        _navmeshagent.speed = Velocidade;

        _animator = GetComponentInChildren<Animator>();
        _vida = GetComponent<Vida>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pontos.Length == 0)
        {
            Debug.Log("Tem de indicar os pontos a percorrer no Npc " + this.transform.name);
            return;
        }
        if (_vida != null && _vida.GetVida() <= 0) return;
        //idle
        if (estado == NPCEstados.Idle)
            return;
        if (estado == NPCEstados.Patrulha)
        {
            //distancia
            if (Vector3.Distance(transform.position, Pontos[ProximoPonto].position) < DistanciaMinima)
            {
                //passa para o proximo
                ProximoPonto++;
                if (ProximoPonto > Pontos.Length - 1)
                    ProximoPonto = 0;
            }
            ////direção
            if (_navmeshagent == null)
            {
                Vector3 direcao = Pontos[ProximoPonto].position - transform.position;
                //rodar na direção do próximo ponto
                Quaternion rotacao = Quaternion.LookRotation(direcao, Vector3.up);
                transform.rotation = rotacao;   //podiamos leerp
                //andar
                transform.Translate(Vector3.forward * Velocidade * Time.deltaTime);
                if (_animator != null)
                    _animator.SetFloat("velocidade", Velocidade);
            }
            else
            {
                _navmeshagent.SetDestination(Pontos[ProximoPonto].position);
                if(_animator!=null)
                    _animator.SetFloat("velocidade", _navmeshagent.velocity.magnitude);
            }
        }
        //vê o player?
        if (_player!=null && Utils.CanYouSeeThis(transform.position, _player.transform.position) && inimigo)
        {
            _renderer.material.color = corVePlayer;
            _navmeshagent.isStopped = false;
            _navmeshagent.SetDestination(_player.transform.position);
            if (_animator != null)
                _animator.SetFloat("velocidade", _navmeshagent.velocity.magnitude);
            estado = NPCEstados.Atacar;
        }
        else
        {
            _renderer.material.color = corBase;
            estado = NPCEstados.Patrulha;
        }
        if (estado == NPCEstados.Atacar)
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < DistanciaAtaque)
            {
                _navmeshagent.isStopped = true;
                if (_animator != null)
                    _animator.SetTrigger("atacar");
                
            }
        }
    }
}
