using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ApanhaGema : MonoBehaviour
{
    [SerializeField] int TotalDeGemas;
    [SerializeField] int ContaGemas=0;
    [SerializeField] GameObject PanelApanhaGemas;
    [SerializeField] FirstPersonController _player;
    [SerializeField] Text GemaCount;

    // Start is called before the first frame update
    void Start()
    {
        TotalDeGemas = GameObject.FindGameObjectsWithTag("Gema").Length;
        _player = FindObjectOfType<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gema")
        {
            ContaGemas++;
            if (GemaCount != null)
                GemaCount.text = ContaGemas.ToString();
            TotalDeGemas--;
            Destroy(other.gameObject);
            if(TotalDeGemas<=0)
            {
                PanelApanhaGemas.SetActive(true);
                Time.timeScale = 0;
                _player.m_MouseLook.SetCursorLock(false);
            }
        }
    }
}
