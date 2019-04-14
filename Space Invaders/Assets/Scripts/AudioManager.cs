using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static float musicVolume;
    public static float sfxVolume;
    public static float generalVolume;

    public AudioSource killSource;
    public AudioSource shootSource;
    public AudioSource explosionSource;

    public static AudioSource kill;
    public static AudioSource shoot;
    public static AudioSource explosion;

    void Start()
    {
        kill = killSource;
        shoot = shootSource;
        explosion = explosionSource;
    }
		
    public static void PlayKill()
    {
        kill.Play(0);
    }

    public static void PlayShoot()
    {
        shoot.Play(0);
    }

    public static void PlayExplosion()
    {
        explosion.Play(0);
    }

    public static void setGeneralVolume(float volume)
    {
        generalVolume = volume;
        updateAllVolumes();
    }

    public static void setMusicVolume(float volume)
    {
        musicVolume = volume;
        updateMusicVolumes();
    }

    public static void setSfxVolume(float volume)
    {
        musicVolume = volume;
        updateSfxVolumes();
    }

    public static void updateAllVolumes()
    {
        updateMusicVolumes();
        updateSfxVolumes();
    }

    public static void updateMusicVolumes()
    {
        //.volume = (generalVolume / 100) * musicVolume;
    }

    public static void updateSfxVolumes()
    {
        kill.volume = (generalVolume / 100) * sfxVolume;
        shoot.volume = (generalVolume / 100) * sfxVolume;
        explosion.volume = (generalVolume / 100) * sfxVolume;
    }
}
