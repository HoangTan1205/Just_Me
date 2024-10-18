using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Scr_User_Login;
public class WinLose : MonoBehaviour
{
    [SerializeField] private Slider TowerLinh;
    [SerializeField] private Slider TowerEnemy;
    [SerializeField] private GameObject PanelWin;
    [SerializeField] private GameObject PanelLose;
    [SerializeField] Scr_User_Login dataUser;
    void Update()
    {
        if (TowerLinh.value <= 0)
        {
            Time.timeScale = 0;
            PanelWin.SetActive(false);
            PanelLose.SetActive(true);
        }

        if (TowerEnemy.value <= 0)
        {
            Time.timeScale = 0;
            PanelWin.SetActive(true);
            PanelLose.SetActive(false);
            UnLockLevel();
        }
    }
    public void UnLockLevel()
    {
        int levelHienTai = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        if (levelHienTai == dataUser.levelUser)
        {
            dataUser.levelUser++;
        }
    }
    public void ManTiepTheo()
    {
        int level = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(level + 1);
    }
}
