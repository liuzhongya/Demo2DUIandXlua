using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ObjectPool))]
public class GameRoot : MonoSingleton<GameRoot> { 
    public ObjectPool objectPool;
    public static ShadowPool instance;
  
   
    void Start()
    {
        objectPool = ObjectPool.Instance;
        //  GameRoot.Instance.objectPool.Spawn("GameBackground3", parent.transform);


        //   UIManager.Instance.Test();

        InitUIShow();
    }
      public void InitUIShow()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name== "main")
        {
            UIManager.Instance.PushPanel(UIPanelType.StartMenum);
        }
        else if (scene.name == "StartGame")
        {
            UIManager.Instance.PushPanel(UIPanelType.MainMenum);
        }
    }

}
