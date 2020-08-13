using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 namespace Mode2D
{
    public class Lx : MonoBehaviour
    {
        BaseData basedata = new BaseData();
        // Use this for initialization
        void Start()
        {
          
            basedata.MoveSpeed = 111;
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(basedata.MoveSpeed + "   " + basedata.JumpSpeed);
        }
    }
}