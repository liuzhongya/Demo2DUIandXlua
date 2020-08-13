using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour {

    //希望可以在其他的代码中访问所以使用单例模式
    public static ShadowPool instance;
    public GameObject shadowPrefab;

    public int shadowCount;
    private Queue<GameObject> availableObjects = new Queue<GameObject>();



    private void Awake()
    {
        instance = this;

        //初始化对象吃
        FillPool();


    }
    public void FillPool()
    {
        for(int i = 0; i < shadowCount; i++)
        {
          //  var newShadow = Instantiate(shadowPrefab);

            var newShadow = GameObject.Instantiate<GameObject>(shadowPrefab);
            newShadow.transform.SetParent(transform);
            //取消其用.返回对象池
            ReturnPool(newShadow);
        }
    }

    public void ReturnPool(GameObject go)
    {
        go.SetActive(false);
        availableObjects.Enqueue(go);
    }

    public  GameObject GetFormPool()
    {
        if (availableObjects.Count == 0)
        {
            FillPool();
        }


        var outShadow = availableObjects.Dequeue();

        outShadow.SetActive(true);
        return outShadow;

    }



}
