using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    // Start is called before the first frame update
    public static AudioSource audioSource;
   void Awake()
   {
    audioSource=GetComponent<AudioSource>();
   }
   public static void PlaySound(AudioClip audioClip)
   {
    audioSource.clip=audioClip;
    audioSource.loop=false;
    audioSource.Play();
   }
}
