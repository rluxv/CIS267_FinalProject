using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    private AudioSource backgroundMusicPlayer;
    public AudioClip levelMusic;
    public AudioClip battleMusic;

    private void Start()
    {
        backgroundMusicPlayer = this.GetComponent<AudioSource>();
        
    }
    
    public void startLevelMusic()
    {
        backgroundMusicPlayer.clip = levelMusic;

    }

    public void startBattleMusic()
    {

        backgroundMusicPlayer.clip = battleMusic;

    }

    public void playCurrentMusic()
    {

        backgroundMusicPlayer.Play();
    }

    public void stopCurrentMusic() 
    {
        backgroundMusicPlayer.Stop();
    }

}
