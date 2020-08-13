using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUnSpaw : MonoBehaviour {

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.K))
    //    {
    //        BroadcastMessage("UnSpawnItem", SendMessageOptions.DontRequireReceiver);
    //        print("发送消息 ");
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Player)
        {
            BroadcastMessage("UnSpawnItem", SendMessageOptions.DontRequireReceiver);
            print("发送消息 ");
        }
    }





}
