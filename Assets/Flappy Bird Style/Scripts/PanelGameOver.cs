using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGameOver : MonoBehaviour {

    public Text txtScore;
    public Image imgStar;
    public Sprite[] spStars;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Show()
    {
        anim.Play("Panel_UpDown");
    }
    public void Show(int score)
    {
        Sound.Instance.Stop();
        Sound.Instance.PlayGameOver();
        txtScore.text = "得分："+score.ToString();
        if (score < 10)
        {
            imgStar.sprite = spStars[3];
        }else if (score < 50)
        {
            imgStar.sprite = spStars[2];
        }else if (score < 200)
        {
            imgStar.sprite = spStars[1];
        }
        else
        {
            imgStar.sprite = spStars[0];
        }
        
        Show();
    }
    public void Hide()
    {
        anim.Play("Panel_DownUp");
    }
    public void OnReplay()
    {
        Sound.Instance.PlayClick();
        GameManager.Instance.LoadScene("Main");
    }
    public void OnHome()
    {
        Sound.Instance.PlayClick();
        GameManager.Instance.LoadScene("Index");
    }
}
