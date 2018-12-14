using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour 
{
	public static GameControl instance;			//A reference to our game control script so we can access it statically.
	public Text scoreText;						//A reference to the UI text component that displays the player's score.
	public GameObject gameOvertext;				//A reference to the object that displays the text which appears when the player dies.

	private int score = 0;						//The player's score.
	public bool gameOver = false;				//Is the game over?
    public bool gameStart = false;
	public float scrollSpeed = -1.5f;
    public Animator countDown;
    public PanelGameOver panelGameOver;
    public Sprite[] spBackgrounds;
    public SpriteRenderer[] imgBackgound;
    

    public GameObject[] players;

    Bird player;

    private void Start()
    {
        if (GameManager.Instance == null)
            return;
        Sprite spBackground = spBackgrounds[GameManager.Instance.backgroundIdx];
        SetBackground(spBackground);
        player= Instantiate(players[GameManager.Instance.playerIdx],new Vector3(-1.8f, 0.55f),Quaternion.identity).GetComponent<Bird>();
        CountDown();
    }

    void Awake()
	{
		//If we don't currently have a game control...
		if (instance == null)
			//...set this one to be it...
			instance = this;
		//...otherwise...
		else if(instance != this)
			//...destroy this one because it is a duplicate.
			Destroy (gameObject);
	}

	void Update()
	{
		//If the game is over and the player has pressed some input...
		if (gameOver && (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.W))) 
		{
			//...reload the current scene.
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
    void CountDown()
    {
        countDown.Play("CountDown");
        Invoke("StartGame", 3);
    }
    public void StartGame()
    {
        countDown.gameObject.SetActive(false);
        gameStart = true;
        player.SetStart();
    }
    void SetBackground(Sprite sp)
    {
        for(int i = 0; i < imgBackgound.Length; i++)
        {
            imgBackgound[i].sprite = sp;
        }
    }

	public void BirdScored()
	{
		//The bird can't score if the game is over.
		if (gameOver)	
			return;
		//If the game is not over, increase the score...
		score++;
		//...and adjust the score text.
		scoreText.text = "Score: " + score.ToString();
	}

	public void BirdDied()
	{
		//Activate the game over text.
		//gameOvertext.SetActive (true);
		//Set the game to be over.
		gameOver = true;
        panelGameOver.Show(score);
        scoreText.gameObject.SetActive(false);
	}
}
