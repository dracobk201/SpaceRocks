using UnityEngine;
using UnityEngine.UI;

public class VolumeUIButton : MonoBehaviour
{
    public int volumenValue;
    [SerializeField] private Button volumeButton;
    [SerializeField] private VolumeController volumeController;

    private void OnEnable()
    {
        volumeButton.onClick.AddListener(OnButtonPressed);
    }

    private void OnDisable()
    {
        volumeButton.onClick.RemoveListener(OnButtonPressed);
    }

    public void Setup(VolumeController controller)
    {
        volumeController = controller;
    }

    private void OnButtonPressed()
    {
        volumeController.ChangeVolume(volumenValue);
    }
}
