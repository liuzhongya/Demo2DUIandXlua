using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {


    //public string lx = "Dirt1a(1)";
    //   public string[] coinName = new string[6];
    //public   int start = 1, length = 4;
    void Start () {

        //  string str = gameObject.name;

        //  Debug.Log(str+"    "+str.Substring(start - 1, length));
        //  if(str.Substring(start - 1, length) == "Coin")
        //  {
        ////      print("这是金币");
        //  }
      
    }

    void CutStr(string strName)
    {
        strName.Substring(0, 6);

    }

    void Update () {
		
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
