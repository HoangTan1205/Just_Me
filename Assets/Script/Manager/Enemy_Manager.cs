using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
//using UnityEngine.SceneManagement;
//using Unity.VisualScripting.Antlr3.Runtime.Misc;
using static Scr_Table_Object;
public class Enemy_Manager : MonoBehaviour
{
    public List<ChiSoEnemy> listTTE = new List<ChiSoEnemy>();
    public Scr_Table_Object data;
    private void Awake()
    {
        LoadTextLinh("Enemy");
    }
    private void Start()
    {
        
    }

    public void LoadTextLinh(string path)
    {
        TextAsset loadText = Resources.Load<TextAsset>(path);
        string[] lines = loadText.text.Split('\n');
        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split('\t');

            ChiSoEnemy ttE = new ChiSoEnemy();
            ttE.Id = Convert.ToInt32(cols[0]);
            ttE.Linh = cols[1];
            ttE.Hp = float.Parse(cols[2]);
            ttE.Dmg = float.Parse(cols[3]);
            ttE.TocDoChay = float.Parse(cols[4]);
            ttE.TocDoBan = float.Parse(cols[5]);
            ttE.TamBan = float.Parse(cols[6]);
            listTTE.Add(ttE);
            if (data.tableObjects.Count < listTTE.Count)
            {
                TableObject list = new TableObject(ttE.Id, ttE.Linh, ttE.Hp, ttE.Dmg, ttE.TocDoChay, ttE.TocDoBan, ttE.TamBan);
                data.tableObjects.Add(list);
            }
        }
    }



}
[System.Serializable]
public class ChiSoEnemy
{
    public int Id;
    public string Linh;
    public float Hp;
    public float Dmg;
    public float TocDoChay;
    public float TocDoBan;
    public float TamBan;
}
