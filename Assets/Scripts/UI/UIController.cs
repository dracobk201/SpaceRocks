using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameSettingsReference gameStatus;
    [SerializeField] private List<BaseUI> uiPanels;

    private void Awake()
    {
        foreach (var uiPanel in uiPanels)
        {
            uiPanel.Setup(this, gameStatus);
        }
    }

    public void ShowHidePanel(UIPanel targetPanel)
    {
        if (targetPanel.Equals(UIPanel.None))
        {
            foreach(var uiPanel in uiPanels)
            {
                uiPanel.ShowHideCanvasGroup(false);
            }
        }
        else
        {
            int index = uiPanels.FindIndex(ui => ui.gameObject.name.Equals(targetPanel.ToString()));
            
            if (index == -1)
            {
                Debug.LogError($"Target Panel, {targetPanel}, doesn't exist");
                return;
            }

            foreach (var uiPanel in uiPanels)
            {
                uiPanel.ShowHideCanvasGroup(false);
            }

            uiPanels[index].ShowHideCanvasGroup(true);
        }
    }
}
