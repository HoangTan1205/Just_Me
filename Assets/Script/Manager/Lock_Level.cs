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
    
}
