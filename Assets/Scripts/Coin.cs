using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {


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


    void CutStr(string strName)
    {
        strName.Substring(0, 6);

    }

  

    void UnSpawnItem()
    {
        //ObjectPool.Instance.UnSpawn(gameObject);
        //print("回收  " + gameObject.name);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Player)
        {
            //播发声音;TODO
            //增加金币数
            //  plaertCoinNum.CoinNum = plaertCoinNum.CoinNum+1;

            //    PlayerData.Instance.CoinNum = plaertCoinNum.CoinNum + 1; 

            //   collision.SendMessage("AddCoinNum", 1);

            //  PlayerData.Instance.coinNum += 1;
            //  SendMessageUpwards("AddCoinNum", 1);
            PlayerData.coinNum = PlayerData.coinNum + 10;


            Destroy(gameObject);
        }
    }

}
