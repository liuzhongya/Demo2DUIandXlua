using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoSingleton<ObjectPool> {

    public string ResourcesDir;


    Dictionary<string, SubPool> m_pools = new Dictionary<string, SubPool>();
    //取出物体
    public GameObject Spawn(string name, Transform trans)
    {
     //   print("aaaaaaaaaaa");
        SubPool pool = null;
        if (!m_pools.ContainsKey(name))
        {
            RegiterNew(name, trans);
           // print("bbbbbbbbbbbb");
        }
        pool = m_pools[name];
       // print("sssssssss");
        return pool.Spawn();
     
    }


    //public GameObject Spawn(string name,Transform trans)
    //{
    //    SubPool pool = null;
    //    if (!m_pools.ContainsKey(name))
    //    {
    //        RegiterNew(name, trans);
    //    }
    //    pool = m_pools[name];

    //    return pool.Spawn();
    //}
    public void UnSpawn(GameObject go)
    {
        SubPool pool = null;
        foreach(var p in m_pools.Values)
        {
            if (p.Contains(go))
            {
                pool = p;
                break;
            }
        }
     //   print(go.ToString());
        pool.UnSpawn(go);

    }
    public void UnSpawnAll(GameObject go)
    {
       
        foreach (var p in m_pools.Values)
        {
            p.UnSpawnAll();
        }
       

    }

    void  RegiterNew(string names,Transform trans)
    {
        string path = ResourcesDir + "/" + names;
        GameObject go = Resources.Load<GameObject>(path);
        SubPool pool = new SubPool(trans, go);
        m_pools.Add(pool.Name, pool);


    }



}
