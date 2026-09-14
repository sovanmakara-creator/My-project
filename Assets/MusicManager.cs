
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    // Background music
    public AudioSource musicSource;

    // Button / UI sound effects
    public AudioSource sfxSource;

    [Header("Sound Effects")]
    public AudioClip buttonClickSound;

    void Awake()
    {
        // Prevent duplicate MusicManagers
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        // Keep MusicManager between scenes
        DontDestroyOnLoad(gameObject);

        // Get both Audio Sources
        
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
}

