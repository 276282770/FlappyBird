using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public int playerIdx = 0;
    public int backgroundIdx = 0;
	// Use this for initialization
	void Start () {
        Instance = this;
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
