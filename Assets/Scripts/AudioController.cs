using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private GameSettingsReference gameStatus;
    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private AudioSource playerSfxAudioSource;
    [SerializeField] private AudioSource asteroidSfxAudioSource;
    [Header("Audio Clips")]
    [SerializeField] private AudioClip bgmGame;
    [SerializeField] private AudioClip sfxShoot;
    [SerializeField] private AudioClip sfxPlayerImpact;
    [SerializeField] private AudioClip sfxAsteroidImpact;
    [SerializeField] private AudioClip sfxDead;

    private void Awake()
    {
        bgmAudioSource.playOnAwake = false;
        bgmAudioSource.loop = true;

        playerSfxAudioSource.playOnAwake = false;
        playerSfxAudioSource.loop = false;
        asteroidSfxAudioSource.playOnAwake = false;
        asteroidSfxAudioSource.loop = false;
    }

    private void PlayBGM(AudioClip music)
    {
        bgmAudioSource.Stop();
        bgmAudioSource.clip = music;
        bgmAudioSource.Play();
    }

    private void PlayPlayerSFX(AudioClip soundSfx)
    {
        playerSfxAudioSource.Stop();
        playerSfxAudioSource.clip = soundSfx;
        playerSfxAudioSource.Play();
    }

    private void PlayAsteroidSFX(AudioClip soundSfx)
    {
        asteroidSfxAudioSource.Stop();
        asteroidSfxAudioSource.clip = soundSfx;
        asteroidSfxAudioSource.Play();
    }

    public void ChangeVolume()
    {
        bgmAudioSource.volume = gameStatus.BGMVolume;
        playerSfxAudioSource.volume = gameStatus.SFXVolume;
        asteroidSfxAudioSource.volume = gameStatus.SFXVolume / 2;
    }

    public void PlayBGMGame()
    {
        PlayBGM(bgmGame);
    }

    public void PlaySFXShoot()
    {
        PlayPlayerSFX(sfxShoot);
    }

    public void PlaySFXPlayerImpact()
    {
        PlayAsteroidSFX(sfxPlayerImpact);
    }

    public void PlaySFXAsteroidImpact()
    {
        PlayAsteroidSFX(sfxAsteroidImpact);
    }

    public void PlaySFXDead()
    {
        PlayPlayerSFX(sfxDead);
    }
}
