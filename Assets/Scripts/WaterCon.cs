using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCon : MonoBehaviour {

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
}
