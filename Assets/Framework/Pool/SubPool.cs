using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPool : MonoBehaviour {

    //集合
    public List<GameObject> m_object = new List<GameObject>();

    //预设
    GameObject m_prefab;

    Transform m_parent;

    //名字
    public string Name 
    {
        get
        {
            return m_prefab.name;
        }
    }

    public SubPool(Transform parent,GameObject go)
    {
        m_prefab = go;
        m_parent = parent;

    }

    //取出物体
    public GameObject Spawn()
    {
        GameObject go = null;
      
        foreach (var obj in m_object)
        {
            if (!obj.activeSelf)
            {
                go = obj;
            }
            //print(go.transform.position.ToString() + "go1");
        }
        if (go == null)
        {
            go = Instantiate(m_prefab, m_parent);
            go.transform.parent = m_parent;
        

            // print("go.position           " + m_parent.position.ToString() + "    " + go.transform.parent.position.ToString());
           // print(go.transform.position.ToString() + "go3");
          
            //print(go.transform.position.ToString() + "go4");
            m_object.Add(go);

        }

        go.SetActive(true);
        go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);

      //  print(go.transform.position.ToString() + "go");
        return go;


    }
    //回收物体
    public void UnSpawn(GameObject go)
    {
        if (Contains(go)) 
        {
            go.SendMessage("OnUnSpawn", SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);
        }
    }
    //回收所有物体
    public void UnSpawnAll()
    {

        foreach (var obj in m_object)
        {

            if (!obj.activeSelf)
            {
                UnSpawn(obj);
            }
        }

       


    }
    public bool Contains(GameObject go)
    {
        return m_object.Contains(go);
    }




}
