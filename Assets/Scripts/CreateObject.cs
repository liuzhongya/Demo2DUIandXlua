using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour {

    public string ResourcesDir= "objects";
    private  int randomCreate;

    private void OnEnable()
    {
         randomCreate = Random.Range(1, 40);
        NewObjectCon();
    }
    private void Start()
    {
        
    }


    void Update () {
		
	}

    void NewObject(string objName,Vector3 cretePos)
    {
        string path = ResourcesDir + "/" + objName;
        GameObject go = Resources.Load<GameObject>(path);
        // print(transform.position.ToString());
        GameObject lxgo = Instantiate(go, transform);
        lxgo.transform.localPosition = cretePos;

    }

   public  string  CutStr(string strName)
    {
       // print(strName.Substring(0, 6));
       return  strName.Substring(0, 6);

    }
    void NewObjectCon()
    {
        if (CutStr(gameObject.name) == "Dirt1a" || CutStr(gameObject.name) == "Dirt2b")
        {
            print(randomCreate);
            if (randomCreate > 1 && randomCreate < 6)  //生成宝箱
            {

                if (CutStr(gameObject.name) == "Dirt2b")
                    NewObject("Chest", new Vector3(0, 4.3f, 0));
                else
                {
                    NewObject("Chest", new Vector3(0, 2.3f, 0));
                }

            }
            else if (randomCreate > 6 && randomCreate < 10)
            {
                if (CutStr(gameObject.name) == "Dirt2b")
                {
                    NewObject("Coin", new Vector3(-2, 4, 0));
                    NewObject("Coin", new Vector3(0, 4, 0));
                    NewObject("Coin", new Vector3(2, 4, 0));

                }
                else
                {
                    NewObject("Coin", new Vector3(-2, 2, 0));
                    NewObject("Coin", new Vector3(0, 2, 0));
                    NewObject("Coin", new Vector3(2, 2, 0));

                }
            }
            else if (randomCreate > 15 && randomCreate <= 25)  //生成金币
            {
                if (gameObject.name == "Dirt2b")
                    NewObject("Coin", new Vector3(0, 4, 0));
                else
                {
                    NewObject("Coin", new Vector3(0, 2, 0));

                }
            }
        }
        else if (CutStr(gameObject.name) == "Dirt2a" || CutStr(gameObject.name) == "Dirt3a" || CutStr(gameObject.name) == "Dirt3b" || CutStr(gameObject.name) == "Dirt3c")
        {
            if (randomCreate > 6 && randomCreate < 10)  //生成宝箱
            {

                NewObject("Chest", new Vector3(0, 2.3f, 0));

            }
            else if (randomCreate > 10 && randomCreate <= 15)  //生成金币
            {
                if (CutStr(gameObject.name) == "Dirt2b")
                {
                    NewObject("Coin", new Vector3(0, 4, 0));
                }
                else
                    NewObject("Coin", new Vector3(0, 2, 0));

            }
            else if (randomCreate > 15 && randomCreate <= 25)  //敌人一   
            {
                if (gameObject.name == "Dirt2b")
                {
                    NewObject("opossum", new Vector3(0, 4, 0));
                }
                else
                    NewObject("opossum", new Vector3(0, 1.5f, 0));
            }
            else if (randomCreate > 25 && randomCreate <= 35)  //敌人 er 
            {
                if (CutStr(gameObject.name) == "Dirt2b")
                {
                    NewObject("frog", new Vector3(0, 4, 0));
                }
                else
                    NewObject("frog", new Vector3(0, 1.5f, 0));
            }
            else if (randomCreate > 35 && randomCreate <= 40)  //敌人三
            {
                if (CutStr(gameObject.name) == "Dirt2b")
                {
                    float ranDomeagle = Random.Range(4f, 6.5f);
                    NewObject("eagle", new Vector3(0, ranDomeagle, 0));
                }
                else
                {
                    float ranDomeagle = Random.Range(2.5f, 5);
                    NewObject("eagle", new Vector3(0, ranDomeagle, 0));
                }
            }
        }
        //  宝箱0-10， ，金币10-20，敌人（3种）20-40
        else if (CutStr(gameObject.name) == "Dirt7a")
        {
            if (randomCreate > 0 && randomCreate <= 6)  //生成宝箱
            {
                NewObject("Coin", new Vector3(0, 1.5f, 0));


            }
            else if (randomCreate > 6 && randomCreate <= 10)  //生成金币
            {
                NewObject("Chest", new Vector3(0, 2.3f, 0));
            }
            else if (randomCreate > 10 && randomCreate <= 15)  //生成金币
            {
                NewObject("Coin", new Vector3(-4, 1.5f, 0));
                NewObject("Coin", new Vector3(-2, 1.5f, 0));
                NewObject("Coin", new Vector3(0, 1.5f, 0));
                NewObject("Coin", new Vector3(2, 1.5f, 0));
                NewObject("Coin", new Vector3(4, 1.5f, 0));
                NewObject("Coin", new Vector3(6, 1.5f, 0));
                print(gameObject.name);
            }
            else if (randomCreate > 15 && randomCreate <= 30)  //敌人一   
            {
                NewObject("opossum", new Vector3(0, 1.5f, 0));
                NewObject("frog", new Vector3(4, 1.5f, 0));
                NewObject("eagle", new Vector3(-4, 4.5f, 0));

            }
            else if (randomCreate > 30 && randomCreate <= 35)  //敌人 er 
            {
                NewObject("opossum", new Vector3(0, 1.5f, 0));
                NewObject("frog", new Vector3(4, 1.5f, 0));
            }
            else if (randomCreate > 35 && randomCreate <= 40)  //敌人三
            {
                NewObject("frog", new Vector3(4, 1.5f, 0));
                float ranDomeagle = Random.Range(2.5f, 5);
                NewObject("eagle", new Vector3(0, ranDomeagle, 0));
            }
        }
        else           //(gameObject.name == "Dirt2a" || gameObject.name == "Dirt2b")  //Dirt4，5，6情况
        {
            if (randomCreate > 6 && randomCreate < 10)  //生成宝箱
            {
                //    string path = ResourcesDir + "/" + "Coin";
                //    GameObject go = Resources.Load<GameObject>(path);
                //    print(transform.position.ToString());
                // GameObject lxgo=Instantiate(go, transform);
                //    lxgo.transform.localPosition = new Vector3(0, 2, 0);
                //    Debug.Log("生成宝箱");
                NewObject("Chest", new Vector3(0, 2.3f, 0));

            }
            else if (randomCreate > 10 && randomCreate <= 15)  //生成金币
            {
                NewObject("Coin", new Vector3(-2, 2, 0));
                NewObject("Coin", new Vector3(0, 2, 0));
                NewObject("Coin", new Vector3(2, 2, 0));
                NewObject("Coin", new Vector3(4, 2, 0));
            }
            else if (randomCreate > 15 && randomCreate <= 30)  //敌人一   
            {
                if (randomCreate < 20)
                {
                    NewObject("frog", new Vector3(0, 1.5f, 0));
                }
                else if (randomCreate > 20 && randomCreate < 25)
                {
                    NewObject("opossum", new Vector3(0, 1.5f, 0));
                }
                else
                {
                    float ranDomeagle = Random.Range(2.5f, 5);
                    NewObject("eagle", new Vector3(0, ranDomeagle, 0));
                }
            }
            else if (randomCreate > 30 && randomCreate <= 35)  //敌人 er 
            {
                NewObject("opossum", new Vector3(0, 1.5f, 0));
                float ranDomeagle = Random.Range(2.5f, 5);
                NewObject("eagle", new Vector3(0, ranDomeagle, 0));
            }
            else if (randomCreate > 35 && randomCreate <= 40)  //敌人三
            {
                NewObject("frog", new Vector3(4, 1.5f, 0));
                float ranDomeagle = Random.Range(2.5f, 5);
                NewObject("eagle", new Vector3(0, ranDomeagle, 0));
            }

        }
  
    }

}