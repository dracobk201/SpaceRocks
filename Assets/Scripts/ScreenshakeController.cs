using UnityEngine;

public class ScreenshakeController : MonoBehaviour
{
    [SerializeField] private GameSettingsReference gameStatus;
    private float shakeDuration;
    private float shakeMagnitude;
    private float dampingSpeed;
    private Vector3 _initialPosition;

    private void OnEnable()
    {
        _initialPosition = transform.localPosition;
        dampingSpeed = gameStatus.shakeDampingSpeed;
    }

    private void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = _initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = _initialPosition;
        }
    }

    public void TriggerSimpleShake()
    {
        shakeDuration = gameStatus.lowShakeDuration;
        shakeMagnitude = gameStatus.lowShakeMagnitude;
    }

    public void TriggerHardShake()
    {
        shakeDuration = gameStatus.heavyShakeDuration;
        shakeMagnitude = gameStatus.heavyShakeMagnitude;
    }
}
