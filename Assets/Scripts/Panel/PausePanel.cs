using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : BasePanel {

    private CanvasGroup canvasGroup;
    
    private bool IsPause = true;
    private Image PauseImage;
    private Text PauseText;
    private float  PauseNum=3;
    private bool IsStartCounting=false;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        PauseImage = GameObject.Find("PauseImageButton").GetComponent<Image>();
        PauseText = GameObject.Find("PauseText").GetComponent<Text>();
        PauseText.text = "";


    }

    private void Update()
    {
        StartCounting();
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
     //   Debug.Log("Pop");
    }

    public void OnReturnMainScence()
    {
        OnClosePanel();
        Globe.nextSceneName = "main";
        SceneManager.LoadScene("LoadScence");

    }
    public override void OnEnter()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;

        Vector3 temp = transform.localPosition;
        temp.x = 600;
        transform.localPosition = temp;
        transform.DOLocalMoveX(0, 0.5f);


    }
    public override void OnExit()
    {

        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
      //  transform.DOLocalMoveX(600, 0.5f).OnComplete(() => canvasGroup.alpha = 0);

    }
    IEnumerator WaitStartGame()
    {
        //if(IsPause==true)
        //PauseImage.sprite = Resources.LoadAll<Sprite>("UI/Iconic1024x1024")[62];
        //else
        //    PauseImage.sprite = Resources.LoadAll<Sprite>("UI/Iconic1024x1024")[14];
        yield return new WaitForSeconds(3.1f);
        IsStartCounting = false;
        PauseText.text = "";
        OnClosePanel();
      //  Debug.Log("等待结束");
    }
    private void StartCounting()
    {
        if(IsStartCounting)
        {
            PauseNum = PauseNum - Time.deltaTime;
            if (PauseNum > 0)
            {
                PauseText.text = PauseNum.ToString();
            }
            else
            {
                PauseText.text = "0";
            }
        }
    }
 

    public void OnPauseButton() 
    {
        PauseNum = 3;
     
        if (IsPause == false)
        {
            PauseImage.sprite = Resources.LoadAll<Sprite>("UI/Iconic1024x1024")[62];
            IsPause = false;
            Debug.Log("aa");
        }
        else
        {
            PauseImage.sprite = Resources.LoadAll<Sprite>("UI/Iconic1024x1024")[14];
            IsStartCounting = true;

          StartCoroutine("WaitStartGame");
            IsPause = true;
          //  Debug.Log("bbb");
        }

     //   Debug.Log(IsPause);


    }


}