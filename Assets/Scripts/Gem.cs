using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

    private Animator ani;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    void Update () {
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
            //增加金币数

            PlayerData.gemNum = PlayerData.gemNum + 1;


            Destroy(gameObject);
        }



    }
}
