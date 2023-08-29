using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private GameSettingsReference gameStatus;
    [SerializeField] private OptionsPanelBehaviour optionsPanelBehaviour;
    [SerializeField] private VolumeOption volumeOption;
    [SerializeField] private VolumeUIButton[] volumeButtons;

    private void Start()
    {
        foreach (var button in volumeButtons)
        {
            button.Setup(this);
        }
        ChangeVolume(6);
    }

    public void ChangeVolume(int value)
    {
        switch (volumeOption)
        {
            case VolumeOption.SFX:
                gameStatus.SFXVolume = value/10f;
                break;
            case VolumeOption.BGM:
                gameStatus.BGMVolume = value/10f;
                break;
        }

        foreach (var button in volumeButtons)
        {
            button.GetComponent<Image>().color = Color.white;
        }

        foreach (var button in volumeButtons)
        {
            if (button.volumenValue > value)
            {
                button.GetComponent<Image>().color = Color.gray;
            }
        }
        optionsPanelBehaviour.ChangeVolumenAlert();
    }
}
