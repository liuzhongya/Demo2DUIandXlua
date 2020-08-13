using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mode2D {
public class BaseData : MonoBehaviour {

	public enum BaseState
    {
        Idle,
        Move,
        Jump,
        Attack
    }

    private float movespeed;
    public float MoveSpeed
    {
        set
        {
            movespeed = value;
        }
        get
        {
            return movespeed;
        }
    }


    private float jumpspeed;
    public float JumpSpeed
    {
        set
        {
            jumpspeed = value;
        }
        get
        {
            return jumpspeed;
        }

    }
    private float maxY; //跳起最大速度
    public float MaxY
    {
        get {        return maxY;    }
        set {     maxY = value;    }
    }
        private float attack;
        public float Attack
        {
            set { attack = value; }
            get { return attack; }
        }
        private int hp;
        public int HP
        {
            set { hp = value; }
            get { return hp; }
        }
        private  int mana;
        public int Mana
        {
            set { mana = value; }
            get { return mana; }
        }

    private Animator anim;
    private bool IsGround = true;
    //private int groundLayerMsk



    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
        public virtual void OnMove()
        {

        }
        public virtual void OnAttack()
        {

        }
        public virtual void OnHp()
        {

        }
        public virtual void OnMana()
        {

        }


    }
}