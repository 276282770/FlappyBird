using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Loading : MonoBehaviour {

    public GameObject panelIndex;
    public GameObject panelSelectPlayer;
    public Image imgBg;
    public  string bgName;
    
	// Use this for initialization
	void Start () {
        bgName = Application.dataPath + "/背景.jpg";
        Sprite spBg = LoadSprite(bgName, new Vector2Int(900, 600));
        if (spBg != null)
        {
            imgBg.sprite = spBg;
            Debug.Log("更换首页背景");
        }

  
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnStart()
    {
        Sound.Instance.PlayClick();
       panelIndex.SetActive(false);
        panelSelectPlayer.SetActive(true);
    }
    public void OnSelectPlayer0()
    {
        Sound.Instance.PlayClick();
        GameManager.Instance.playerIdx = 0;
        GameManager.Instance.LoadScene("Main");
    }
    public void OnSelectPlayer1()
    {
        Sound.Instance.PlayClick();
        GameManager.Instance.playerIdx = 1;
        GameManager.Instance.LoadScene("Main");
    }
    Sprite LoadSprite(string path,Vector2Int size)
    {
        FileInfo fi = new FileInfo(path);
        if (!fi.Exists)
            return null;
        FileStream fs = fi.OpenRead();
        byte[] buffer = new byte[fs.Length];
        fs.Read(buffer, 0, (int)fs.Length);
        Texture2D texture = new Texture2D(size.x, size.y);
        texture.LoadImage(buffer);
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        return sp;
        
    }
}
