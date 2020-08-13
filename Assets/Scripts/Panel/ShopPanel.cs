using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ShopPanel : BasePanel
{
    private CanvasGroup canvasGrop;
    private void Start()
    {
        canvasGrop = GetComponent<CanvasGroup>();
    }
    public override void OnEnter()
    {
        if (canvasGrop == null)
        {
            canvasGrop = GetComponent<CanvasGroup>();
        }
        canvasGrop.alpha = 1;
        canvasGrop.blocksRaycasts = true;

        Vector3 temp = transform.localPosition;
        temp.x = 600;
        transform.localPosition = temp;
        transform.DOLocalMoveX(0, 0.5f);


    }
    public override void OnExit()
    { 
        
        canvasGrop.blocksRaycasts = false;
          transform.DOLocalMoveX(600, 0.5f).OnComplete(()=> canvasGrop.alpha = 0);

    }
public void OnClosePanel()
    {
        UIManager.Instance.PopPanel();

    }
    public override void OnPause()
    {
        canvasGrop.blocksRaycasts = false;
    }
    public override void OnResume()
    {
        canvasGrop.blocksRaycasts = true;
    }
    public void OnItemButtonClick()
    {
        UIManager.Instance.PushPanel(UIPanelType.ItemMessage);
    }




}
