using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Scr_Start;

public class Start_Manager : MonoBehaviour
{
    [SerializeField] private List<In4User> listTTUser = new List<In4User>();
    [SerializeField] private Scr_Start data;
    [SerializeField] private string file;

    private void Start()
    {
        file = "User";
        LoadTextLinh(file);

    }
    public void LoadTextLinh(string path)
    {
        TextAsset loadText = Resources.Load<TextAsset>(path);
        string[] lines = loadText.text.Split('\n');
        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split('\t');

            In4User tt = new In4User();
            tt.Id = Convert.ToInt32(cols[0]);
            tt.UserName = cols[1];
            tt.Pass = cols[2];
            tt.Level = Convert.ToInt32(cols[3]);
            tt.DiemCao = Convert.ToInt32(cols[4]);
            tt.AmThanh = Convert.ToInt32(cols[5]);
            listTTUser.Add(tt);
            InforUser list = new InforUser(tt.Id, tt.UserName, tt.Pass, tt.Level, tt.DiemCao, tt.AmThanh);
            data.List_User.Add(list);

        }
    }
}
[System.Serializable]
public class In4User
{
    public int Id;
    public string UserName;
    public string Pass;
    public int Level;
    public int DiemCao;
    public int AmThanh;
}
