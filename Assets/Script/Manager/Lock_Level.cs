using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Lock_Level : MonoBehaviour
{
    public Input_Login data;
    public int checkd;
    public Button[] levelButtons;

    private void Awake()
    {
        data = FindFirstObjectByType<Input_Login>();
        checkd = data.levelUser;
        UnlockLevels();
    }

    public void OnButtonCheck()
    {
        data = FindFirstObjectByType<Input_Login>();
        checkd = data.levelUser;
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
