using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private List<BaseUI> uiPanels;

    private void Awake()
    {
        foreach (var uiPanel in uiPanels)
        {
            uiPanel.Setup(this);
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
            Debug.Log($"{index} - {targetPanel}");
            if (index == -1)
            {
                Debug.LogError($"Target Panel, {targetPanel}, doesn't exist");
                return;
            }

            uiPanels[index].ShowHideCanvasGroup(true);
            for (int i = 0; i < uiPanels.Count; i++)
            {
                if (i == index)
                {
                    break;
                }
                uiPanels[i].ShowHideCanvasGroup(false);
            }
        }
    }
}
