using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    [HideInInspector] public UIController uIController;
    public CanvasGroup panelCanvasGroup;

    public void Setup(UIController controller)
    {
        uIController = controller;
    }

    public void ShowHideCanvasGroup(bool toShow)
    {
        panelCanvasGroup.alpha = toShow ? 1 : 0;
        panelCanvasGroup.blocksRaycasts = toShow;
        panelCanvasGroup.interactable = toShow;
    }
}
