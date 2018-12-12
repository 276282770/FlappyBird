using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour {

    public GameObject panelIndex;
    public GameObject panelSelectPlayer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnStart()
    {
       panelIndex.SetActive(false);
        panelSelectPlayer.SetActive(true);
    }
    public void OnSelectPlayer0()
    {
        GameManager.Instance.playerIdx = 0;
        GameManager.Instance.LoadScene("Main");
    }
    public void OnSelectPlayer1()
    {
        GameManager.Instance.playerIdx = 1;
        GameManager.Instance.LoadScene("Main");
    }

}
