using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGamePanel : BasePanel {

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
    }
    public override void OnExit()
    {
        canvasGrop.alpha = 0;
        canvasGrop.blocksRaycasts = false;
    }
    public void OnClosePanel()
    {
        UIManager.Instance.PopPanel();

    }
    public void OnExitGameButton()
    {
        OnClosePanel();
       // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }




}
