using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float leftBoundary = -10f; // Left boundary of the screen

    // Update is called once per frame
    void Update()
    {
        MoveObstacles(); // Call the method to move obstacles
    }

    private void MoveObstacles()
    {
        transform.position += Vector3.left * GameManager.instance.gameSpeed * Time.deltaTime; // Move the obstacle to the left
        if (transform.position.x < leftBoundary)
        {
            Destroy(gameObject); // Destroy the obstacle if it goes beyond the left boundary
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.GameOver(); // Call the GameOver method in GameManager when the player collides with the obstacle
        }
    }
}
