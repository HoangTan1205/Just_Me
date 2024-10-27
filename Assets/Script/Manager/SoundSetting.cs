using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundSetting : MonoBehaviour
{
    public Toggle toggleNhacNen;
    public Toggle toggleHieuUng;
    public AudioManager audioMusic;
    public Scr_User_Login data_User_Login;
    public int soundContent;
    private void Awake()
    {

        audioMusic = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        soundContent = data_User_Login.sound;

        LoadToggleSound();
        LoadToggleSFX();
        toggleNhacNen.onValueChanged.AddListener(delegate { ToggleSound(); });
        toggleHieuUng.onValueChanged.AddListener(delegate { ToggleSFX(); });

    }
    void Start()
    {
        
         
              
    }

    public void LoadToggleSound()
    {
        if (soundContent == 1|| soundContent == 3)
        {
            toggleNhacNen.isOn = true;
            audioMusic.musicSource.Play();
        }
        else
        {
            toggleNhacNen.isOn = false;
            
        }
        
    }
    public void LoadToggleSFX()
    {
        if (soundContent >= 2)
        {

            toggleHieuUng.isOn = true;
            audioMusic.SFX_Source.Play();
        }
        else
        {
            toggleHieuUng.isOn = false;
        }
        
    }

    public void ToggleSound()
    {
        
        if (toggleNhacNen.isOn)
        {        
            audioMusic.musicSource.Play();
            data_User_Login.sound += 1;

        }
        else
        {          
            audioMusic.musicSource.Stop();
            data_User_Login.sound-=1;
        }
    }
    public void ToggleSFX()
    {
        
        if (toggleHieuUng.isOn)
        {
            //audioMusic.PlaySFX(audioMusic.click);
            data_User_Login.sound +=2;

        }
        else
        {
            //audioMusic.SFX_Source.Stop();
            data_User_Login.sound -=2;
        }
    }
    // public void ButtonOnSound()
    // {
    //     audioMusic.PlaySFX(audioMusic.click);
    // }
    public void StopSound()
    {
        audioMusic.musicSource.Stop();
    }
}
