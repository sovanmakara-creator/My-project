
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    //music bg
    private AudioSource audioSource;

    //Button/ UI Sound effects
    private AudioSource sfxSource;

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

        // Save this MusicManager
        instance = this;

        // Don't destroy when changing scenes
        DontDestroyOnLoad(gameObject);

        // Get Audio Source component
        audioSource[] sources = GetComponent<AudioSource>();

        musicSource = sources[0];
        sfxSource = sources[1];
    }

    // =========================
    // MUSIC ON
    // =========================

    public void MusicOn()
    {
        audioSource.UnPause();
    }

    // =========================
    // MUSIC OFF
    // =========================

    public void MusicOff()
    {
        audioSource.Pause();
    }

    // =========================
    // VOLUME
    // =========================

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    // =========================
    // MUTE
    // =========================

    public void ToggleMute()
    {
        audioSource.mute = !audioSource.mute;
    }
}


