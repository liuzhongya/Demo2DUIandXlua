using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuPanel : BasePanel
{
    public  CanvasGroup canvasGroup;
    ////private bool IsOpenSound = true;
    ////public Image SoundImage;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
       //// SoundImage = GameObject.Find("MusicButton").GetComponent<Image>();

    }

    public override void OnPause()
    {
        canvasGroup.blocksRaycasts = false;//jiaohujinyong
      //  Debug.Log("StartMenuPanel-OnPause");
    }
   // public override void OnResume()
         public override void OnResume()
    {
        canvasGroup.blocksRaycasts = true;
      //  Debug.Log("StartMenuPanel-Reseme");
    }


    public void OnPushPanel(string panelTypeString)
    {
        UIPanelType panelType = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
        UIManager.Instance.PushPanel(panelType);
    }
    public void OnClosePanel()
    {
        UIManager.Instance.PopPanel();
    }

    public void OnStartGame()
    {
        OnClosePanel();
        Globe.nextSceneName = "StartGame";
        SceneManager.LoadScene("LoadScence");

    }

    ////public void SoundButton()
    ////{

    ////    if (IsOpenSound)
    ////    {
    ////        IsOpenSound = false;
    ////        SoundImage.sprite = Resources.Load("UI/Iconic1024x1024/Iconic1024x1024_18", typeof(Sprite)) as Sprite;

    ////        SoundImage.sprite = Resources.LoadAll<Sprite>("UI/Iconic1024x1024")[18];

    ////    }
    ////    else
    ////    {
    ////        IsOpenSound = true;
    ////        // SoundImage.sprite = Resources.Load("UI/Iconic1024x1024/Iconic1024x1024_14", typeof(Sprite)) as Sprite;
    ////        SoundImage.sprite = Resources.LoadAll<Sprite>("UI/Iconic1024x1024")[6];

    ////    }
    ////    //    Debug.Log("声音管理函数+是否开启声音："+ IsOpenSound);

    ////}





}
