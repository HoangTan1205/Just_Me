using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    [SerializeField] private Scr_User_Login Data_User_Login;
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource SFX_Source;

    public AudioClip backGround;
    public AudioClip scenePlay;
    public AudioClip L_Kiem;
    public AudioClip L_XaThu;
    public AudioClip click;

    public int level;

    private void Awake()
    {
        level = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        if (level == 0)
        {
            PlayMusic(backGround);
        }
        else
        {
            PlayMusic(scenePlay);
        }
    }
    private void Start()
    {
        
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX_Source.clip = clip;
        if (Data_User_Login.sound >=2)
        {
            SFX_Source.PlayOneShot(clip);
        }
    }
    public void PlayMusic(AudioClip clip)
    {
        if (Data_User_Login.sound == 1 || Data_User_Login.sound == 3)
        {          
            musicSource.clip = clip;           
        }
        
    }
    public void ButtonOnSound()
    {
        PlayMusic(backGround);
    }
    
}
