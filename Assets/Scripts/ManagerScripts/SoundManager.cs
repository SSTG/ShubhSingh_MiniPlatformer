using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : Singleton<SoundManager>
{
    // Start is called before the first frame update
    public AudioSource musicSource;
    public AudioSource sfxSource;
    
   void Awake()
   {
    musicSource.volume=!PlayerPrefs.HasKey("MusicVolume") ? 0.5f:PlayerPrefs.GetFloat("MusicVolume");
    sfxSource.volume=!PlayerPrefs.HasKey("SFXVolume") ? 0.5f: PlayerPrefs.GetFloat("SFXVolume");
    musicSource.Play();
    
   }
   public void PlaySound(AudioClip audioClip)
   {
    sfxSource.clip=audioClip;
    sfxSource.loop=false;
    sfxSource.Play();
   }
   public void SetMusicVolume(Slider slider)
   {
    
    musicSource.volume=slider.value;
    PlayerPrefs.SetFloat("MusicVolume",slider.value);
   }
   public void SetSFXVolume(Slider slider)
   {
    
    sfxSource.volume=slider.value;
    PlayerPrefs.SetFloat("SFXVolume",slider.value);
   }
}
