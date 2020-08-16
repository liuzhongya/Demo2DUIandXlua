using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour {

    private Animator ani;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (PlayerData.m_IsPause)
        {
            ani.speed = 0;
        }
        else
        {
            ani.speed = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Player)
        {
            //播发声音;TODO
            PlayerData.plaHp = Mathf.Clamp(PlayerData.plaHp + 50, 0, 100); 
          


            Destroy(gameObject);
        }
    }



}
