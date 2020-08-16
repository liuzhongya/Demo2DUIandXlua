using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

     
    public  static PlayerData _instance;
    public static PlayerData Instance
    {

        get { return _instance; }
    }

    private void Awake()
    {
        _instance = this;
    }

       
    public static float plaHp=100;
    public float nowHp;
    public int nowCoin;
    public int nowGem;
    public float MaxplaHp = 120;
    public static bool m_IsPause = false;



 

    //public  float PlaHp
    //{
    //    get {
    //        plaHp= Mathf.Clamp(plaHp, 0, MaxplaHp);
    //        return plaHp;
    //    }
    //    set { plaHp = value; }
    //}

    public static int coinNum = 100;
    //public   int CoinNum
    //{
    //    get { 
    //        return coinNum; }
    //    set {

    //        coinNum = value;
    //        print(coinNum + "   进行set");
    //    }
    //}

    public static  int gemNum = 10;
    //public int GemNum
    //{
    //    get {   return gemNum; }
    //    set { gemNum = value; }
    //}


    private void Update()
    {
        nowCoin = coinNum;
        nowGem = gemNum;
        nowHp = plaHp;
        if (Input.GetKeyDown(KeyCode.L))
        {
            coinNum -= 1;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            plaHp -= 10;
            plaHp= Mathf.Clamp(plaHp, 0, 100);
            print(plaHp);

        }
    }

    void AddCoinNum(int addnum)
    {
       coinNum += addnum;
    }

    void AddGemNum(int addnum)
    {       
            gemNum += addnum;
    }

}
