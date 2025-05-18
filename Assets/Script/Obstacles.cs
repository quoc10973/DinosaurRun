using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float leftBoundary = -10f; // Left boundary of the screen
    public float gameSpeed = 5f; // Speed of the game

    // Update is called once per frame
    void Update()
    {
        MoveObstacles(); // Call the method to move obstacles
    }

    private void MoveObstacles()
    {
        transform.position += Vector3.left * gameSpeed * Time.deltaTime; // Move the obstacle to the left
        if (transform.position.x < leftBoundary)
        {
            Destroy(gameObject); // Destroy the obstacle if it goes beyond the left boundary
        }
    }
}
