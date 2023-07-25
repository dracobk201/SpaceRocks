using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    [HideInInspector] public GameStatusReference gameStatus;
    [HideInInspector] public UIController uIController;
    public CanvasGroup panelCanvasGroup;

    public void Setup(UIController controller, GameStatusReference status)
    {
        gameStatus = status;
        uIController = controller;
    }

    public void ShowHideCanvasGroup(bool toShow)
    {
        panelCanvasGroup.alpha = toShow ? 1 : 0;
        panelCanvasGroup.blocksRaycasts = toShow;
        panelCanvasGroup.interactable = toShow;
    }
}
