using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGameOver : MonoBehaviour {

    public Text txtScore;
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
        txtScore.text = "得分："+score.ToString();
        Show();
    }
    public void Hide()
    {
        anim.Play("Panel_DownUp");
    }
    public void OnReplay()
    {

        GameManager.Instance.LoadScene("Main");
    }
    public void OnHome()
    {

        GameManager.Instance.LoadScene("Index");
    }
}
