using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Material material; // Reference to the material of the GameObject
    [SerializeField]
    private float parallaxFactor = 0.01f; // Control the speed of the parallax effect
    private float offset; // Offset value for the parallax effect



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<Renderer>().material; // Get the material of the GameObject

    }

    // Update is called once per frame
    void Update()
    {
        ParalaxScroll(); // Call the parallax scroll method
    }

    private void ParalaxScroll()
    {
        float speed = GameManager.instance.gameSpeed * parallaxFactor; // Calculate the speed of the parallax effect
        offset += speed * Time.deltaTime; // Update the offset value based on the speed and time
        material.SetTextureOffset("_MainTex", Vector2.right * offset); // Set the texture offset of the material
    }
}
