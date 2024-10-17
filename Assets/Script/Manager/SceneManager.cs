using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
//using UnityEngine.SceneManagement;
//using Unity.VisualScripting.Antlr3.Runtime.Misc;
using static Scr_Table_Object;
public class SceneManager : MonoBehaviour
{
    public List<ThongTin> listTT = new List<ThongTin>();
    public Scr_Table_Object data;
    //public List<Scr_Table_Object.TableObject> ListData;
    void Awake()
    {

        //  if (FindObjectsOfType<SceneManager>().Length > 1)
        //  {
        //      Destroy(gameObject);
        //  }
        //  else
        //  {
        //      DontDestroyOnLoad(gameObject); // Giữ lại đối tượng này khi chuyển scene
        //  }

    }
    private void Start()
    {
        //ListData = new List<Scr_Table_Object.TableObject>();
        LoadTextLinh("Linh");
    }

    public void LoadTextLinh(string path)
    {
        TextAsset loadText = Resources.Load<TextAsset>(path);
        string[] lines = loadText.text.Split('\n');
        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split('\t');

            ThongTin tt = new ThongTin();
            tt.Id = Convert.ToInt32(cols[0]);
            tt.Linh = cols[1];
            tt.Hp = float.Parse(cols[2]);
            tt.Dmg = float.Parse(cols[3]);
            tt.TocDoChay = float.Parse(cols[4]);
            tt.TocDoBan = float.Parse(cols[5]);
            tt.TamBan = float.Parse(cols[6]);
            listTT.Add(tt);

            TableObject list = new TableObject(tt.Id , tt.Linh,tt.Hp, tt.Dmg , tt.TocDoChay ,tt.TocDoBan ,tt.TamBan );
            data.tableObjects.Add(list);

        }        
    }

    internal static object GetActiveScene()
    {
        throw new NotImplementedException();
    }
}
[System.Serializable]
public class ThongTin
{
    public int Id;
    public string Linh;
    public float Hp;
    public float Dmg;
    public float TocDoChay;
    public float TocDoBan;
    public float TamBan;
}
