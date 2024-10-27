using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Lock_Level : MonoBehaviour
{
    public Scr_User_Login dtLogin;
    public int checkd;
    public Button[] levelButtons;

    private void Awake()
    {        
        checkd = dtLogin.levelUser;
        UnlockLevels();
    }

    public void OnButtonCheck()
    {
        checkd = dtLogin.levelUser;
        UnlockLevels();
    }
    
    void UnlockLevels()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i; // Lưu chỉ số level để sử dụng trong sự kiện
            levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex + 1));

            if (i + 1 <= checkd)
            {
                levelButtons[i].interactable = true; 
                levelButtons[i].gameObject.SetActive(true);

                
            }
            else
            {
                levelButtons[i].interactable = false;
                levelButtons[i].gameObject.SetActive(false);
            }
        }
    }
    
    public void ClickLevel()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            //UnityEngine.SceneManagement.SceneManager.LoadScene(i);
            int levelIndex = i; // Lưu chỉ số level để sử dụng trong sự kiện
            levelButtons[i].onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene(levelIndex + 1));
        }
    }
    void LoadLevel(int levelIndex)
    {
        // Chuyển đến scene thứ levelIndex
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelIndex);
    }

}
