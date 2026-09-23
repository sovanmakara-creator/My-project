
using UnityEngine;

public class MusicManager : MonoBehaviour
{
   public static MusicManager instance;

    // Background music
    public AudioSource musicSource;

    // Button / UI sound effects
    public AudioSource sfxSource;

    [Header("Sound Effects")]
    public AudioClip buttonClickSound;
    public AudioClip JumpSound;

    public AudioClip winSound;
    public AudioClip GameOverSound;
    public AudioClip CollectingCoin;


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
   public void PlayJumpSound()
{
    if (sfxSource == null) { Debug.LogError("sfxSource is missing in Inspector!"); return; }
    if (JumpSound == null) { Debug.LogError("JumpSound clip is None in Inspector!"); return; }
    

    sfxSource.PlayOneShot(JumpSound);
}
    
    public void PlayWinSound(){
        sfxSource.PlayOneShot(winSound);
    }
    public void PlayGameOverSound(){
        sfxSource.PlayOneShot(GameOverSound);
    }
    public void PlayCollectingCoinSound(){
        sfxSource.PlayOneShot(CollectingCoin);
    }
}

