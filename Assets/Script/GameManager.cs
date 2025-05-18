using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float gameSpeed = 5f;
    [SerializeField] private float speedIncreaseRate = 0.15f;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreTextObject;
    [SerializeField] private GameObject gameStartText;
    [SerializeField] private GameObject gameOverText;
    private bool isGameStarted = false;
    private bool isGameOver = false;
    private float score = 0f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public float GameSpeed()
    {
        return gameSpeed;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted)
        {
            HandleStartGameInput();
            return;
        }
        if(isGameOver)
        {
            return;
        }
        UpdateGameSpeed();
        UpdateScore();
    }

    private void UpdateGameSpeed()
    {
        gameSpeed += speedIncreaseRate * Time.deltaTime;
    }

    private void UpdateScore()
    {
        score += Time.deltaTime * 10;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }

    private void StartGame()
    {
        Time.timeScale = 0f; // Pause the game
        scoreTextObject.SetActive(false);
        gameStartText.SetActive(true);
        gameOverText.SetActive(false);
    }

    private void HandleStartGameInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1f; // Resume the game
            scoreTextObject.SetActive(true);
            gameStartText.SetActive(false);
            isGameStarted = true;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f; // Pause the game
        isGameOver = true;
        gameOverText.SetActive(true);
        scoreTextObject.SetActive(false);
        StartCoroutine(ReloadScene());
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
