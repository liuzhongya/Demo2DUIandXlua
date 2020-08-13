using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuPanel : BasePanel
{

    public  CanvasGroup canvasGroup;
    private bool IsOpenSound=true;

    private  bool IsPause = true;
    //public bool IsPauseGame
    //{
    //    get { }
    //    set { }

    //}



    public Image SoundImage;
    public  Image PauseImage;


    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        SoundImage = GameObject.Find("MusicButton").GetComponent<Image>();
        PauseImage = GameObject.Find("PauseButton").GetComponent<Image>();
        //Debug.Log(canvasGroup);
    }

    public override void OnPause() 
    {
        canvasGroup.blocksRaycasts = false;//jiaohujinyong         
                                           //  Debug.Log("StartMenuPanel-OnPause");

        print("暂停");
    }
    // public override void OnResume()
    public override void OnResume()
    {
        canvasGroup.blocksRaycasts = true;
        Time.timeScale = 1;
        //  Debug.Log("StartMenuPanel-Reseme");
    }


    public void OnPushPanel(string panelTypeString)
    {
        UIPanelType panelType = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
        UIManager.Instance.PushPanel(panelType);

       // StartCoroutine("PauseGame");

    }
    IEnumerator PauseGame()
    {
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0;
    }



    public void OnClosePanel()
    {
        UIManager.Instance.PopPanel();
    }

    public void OnReturnMainScence()
    {
        OnClosePanel();
        Globe.nextSceneName = "main";
        SceneManager.LoadScene("LoadScence");

    }
    public void SoundButton() 
    {
      
        if(IsOpenSound)
        {
            IsOpenSound = false;
             SoundImage.sprite= Resources.Load("UI/Iconic1024x1024/Iconic1024x1024_18", typeof(Sprite)) as Sprite;
           
            SoundImage.sprite = Resources.LoadAll<Sprite>("UI/Iconic1024x1024")[18];
              
        }
        else
        {
            IsOpenSound = true;
            // SoundImage.sprite = Resources.Load("UI/Iconic1024x1024/Iconic1024x1024_14", typeof(Sprite)) as Sprite;
            SoundImage.sprite = Resources.LoadAll<Sprite>("UI/Iconic1024x1024")[6];

        }
    //    Debug.Log("声音管理函数+是否开启声音："+ IsOpenSound);

    }
    public void OnPauseButton()
    {
        if (IsPause)
        {
            IsPause = false;
            PauseImage.sprite = Resources.LoadAll<Sprite>("UI/Iconic1024x1024")[63];

        }
        else
        {
            IsPause = true;
            PauseImage.sprite = Resources.LoadAll<Sprite>("UI/Iconic1024x1024")[15];


        }

    }
   
}
