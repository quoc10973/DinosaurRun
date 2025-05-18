using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float gameSpeed = 5f;
    [SerializeField] private float speedIncreaseRate = 0.15f;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameSpeed();
    }

    private void UpdateGameSpeed()
    {
        gameSpeed += speedIncreaseRate * Time.deltaTime;
    }
}
