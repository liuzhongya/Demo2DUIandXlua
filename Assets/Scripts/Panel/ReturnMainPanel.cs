using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainPanel : BasePanel {
    public  CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    

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
        UIManager.Instance.PopPanel();

    }

    public void OnReturnMainScence()
    {
        OnClosePanel();
     
        Globe.nextSceneName = "main";
        SceneManager.LoadScene("LoadScence");
        //Debug.Log("返回主界面" + canvasGroup);
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
        transform.DOLocalMoveX(600, 0.5f).OnComplete(() => canvasGroup.alpha = 0);

    }
 

    

}