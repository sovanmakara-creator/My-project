
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    // Background music
    public AudioSource musicSource;

    // Button / UI sound effects
    public AudioSource sfxSource;

    [Header("Sound Effects")]
    public AudioClip buttonClickSound;

    [Header("Player Sounds")]
    public AudioClip turnleftSound;
    public AudioClip turnRightSound;
    public AudioClip jumpSound;

  void Awake()
{
    if (Instance != null && Instance != this)
    {
        Destroy(gameObject);
        return;
    }

    Instance = this;

    DontDestroyOnLoad(gameObject);
}

    // =========================
    // MUSIC ON
    // =========================

    public void MusicOn()
    {
        musicSource.UnPause();
    }

    // =========================
    // MUSIC OFF
    // =========================

    public void MusicOff()
    {
        musicSource.Pause();
    }

    // =========================
    // MUSIC VOLUME
    // =========================

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }

    // =========================
    // MUTE MUSIC
    // =========================

    public void ToggleMute()
    {
        musicSource.mute = !musicSource.mute;
    }

    // =========================
    // BUTTON SOUND
    // =========================

    public void PlayButtonSound()
    {
        sfxSource.PlayOneShot(buttonClickSound);
    }

    public void  SetSFXVolume(float volume){
        sfxSource.volume = volume;
    }
    public void PlaySFX(AudioClip sound)
{
    sfxSource.PlayOneShot(sound);
}
}

