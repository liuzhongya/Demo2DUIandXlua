using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UIManager  {
   
    /// 单例模式的核心
    /// 1.定义一个静态对象，在外界访问，内部构造
    /// 2.构造方法私有化
    
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
        set
        {

        }
    }
   



    private Transform canvastransform;
    private Transform Canvastransform
    {
        get
        {
            if (canvastransform == null)
            {

                canvastransform = GameObject.Find("Canvas").transform;
                
            }

            return canvastransform;
        }
    }

    private Dictionary<UIPanelType, string> panelPathDict;//存储所有面板的路径
    private Dictionary<UIPanelType, BasePanel> panelDict ;//保存所有实例化面板的游戏物体身上得BasePane组件
    private Stack<BasePanel> panelStack;


    private UIManager()  //无法再外界实例化，再内部实例化
    {
        ParseUIPanelType();
    }

    /// <summary>
    /// 把页面入栈
    /// </summary>
    public void PushPanel(UIPanelType panelType)
    {
       // Debug.Log("0000000000000");
        if (panelStack==null)
        {
            panelStack = new Stack<BasePanel>();
        }
       // Debug.Log("22222222222");
        //判断栈里是否有页面
        if (panelStack.Count > 0)
        {
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }
      //  Debug.Log("11111111111111");

        BasePanel panel = GetPanel(panelType);
       // Debug.Log("aaaaaaaaa");
        panel.OnEnter();
       // Debug.Log("bbbbbbbb");
        panelStack.Push(panel);
       // Debug.Log("cccccccc");
    }
    /// <summary>
    /// 出栈
    /// </summary>
    public void PopPanel()
    {
        if (panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }
        if (panelStack.Count <= 0)
            return;
      //  关闭显示
        BasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();

        if (panelStack.Count <= 0) return;
      //  Debug.Log(panelStack.Count);
        BasePanel topPanel2 = panelStack.Peek();
        topPanel2.OnResume();
        // Debug.Log("lllOnResume");

    }


    /// <summary>
    /// 出栈 ，把页面从界面上移除
    /// </summary>
    //public void PopPanel()
    //{
    //    if (panelStack == null)
    //        panelStack = new Stack<BasePanel>();

    //    if (panelStack.Count <= 0) return;

    //    //关闭栈顶页面的显示
    //    BasePanel topPanel = panelStack.Pop();
    //    topPanel.OnExit();

    //    if (panelStack.Count <= 0) return;
    //    BasePanel topPanel2 = panelStack.Peek();
    //    topPanel2.OnResume();

    //}
    /// <summary>
    /// 根据面板类型实例化面板
    /// </summary>
    /// <returns></returns>
    private BasePanel GetPanel(UIPanelType panelType)
    {
      //  Debug.Log("0000000000000");
        if (panelDict==null)
        {
            panelDict = new Dictionary<UIPanelType, BasePanel>();
        }
        //BasePanel panel;
        //panelDict.TryGetValue(panelType, out panel);
      //  Debug.Log("111111111");
        BasePanel panel = panelDict.TryGet(panelType);
    //    Debug.Log("2222222");

        if (panel == null)  //为空则是要去实例化面板
        {
        //    Debug.Log("333333333");
            //string path;
            //panelPathDict.TryGetValue(panelType, out path);

            string path = panelPathDict.TryGet(panelType);

            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;

            instPanel.transform.SetParent(Canvastransform,false);
            
          //  Debug.Log(panelType);
        //    bool IsStoredDict
           //if(!panelDict.ContainsKey(UIPanelType.Shop)|| !panelDict.ContainsKey(UIPanelType.Developer)|| 
           //     !panelDict.ContainsKey(UIPanelType.ExitGame)|| !panelDict.ContainsKey(UIPanelType.ItemMessage)||
           //      !panelDict.ContainsKey(UIPanelType.MainMenum) || !panelDict.ContainsKey(UIPanelType.RankingList)
           //      || !panelDict.ContainsKey(UIPanelType.Setting) || !panelDict.ContainsKey(UIPanelType.StartMenum))
          if(!panelDict.ContainsKey(panelType))

            {
                panelDict.Add(panelType, instPanel.GetComponent<BasePanel>());
              //  Debug.Log("0000000000000");
            }
          
         //   Debug.Log("11111111111");
            return instPanel.GetComponent<BasePanel>();
        }
        else
            return panel;

    }


    [Serializable]
    public class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList;
     }

    private  void ParseUIPanelType()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();
      
        TextAsset ta =  Resources.Load<TextAsset>("UIPanelType");
      UIPanelTypeJson jsonObject=  JsonUtility.FromJson<UIPanelTypeJson>(ta.text);

        foreach(UIPanelInfo info in jsonObject.infoList)
        {
           // Debug.Log(info.panelType);
            panelPathDict.Add(info.panelType, info.path);
        }

    }
    /// <summary>
    /// just for test
    /// </summary>
    public void Test()
    {
        string path;
        panelPathDict.TryGetValue(UIPanelType.ItemMessage, out path);
        //Debug.Log(path);
    }

}
