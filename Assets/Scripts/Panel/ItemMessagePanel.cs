using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ItemMessagePanel : BasePanel {
    private CanvasGroup canvasGroup;
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public override void OnEnter()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;

        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.5f);
    }

    /// <summary>
    /// 处理页面的关闭
    /// </summary>
    public override void OnExit()
    {
      //  canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        // Debug.Log("RankingListPanel-OnExit");
        transform.DOScale(0, 0.5f).OnComplete(() => canvasGroup.alpha = 0);
    }

    public void OnClosePanel()
    {
        UIManager.Instance.PopPanel();


    }




}
