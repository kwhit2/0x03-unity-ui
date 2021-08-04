using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // speed variable
    public float speed = 2000f;
    // to reference the Rigidbody of the Player game object
    public Rigidbody rb;
    // to reference score variable
    private int score = 0;
    // to reference health variable
    public int health = 5;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Player movement right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        
        // Player movement left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }

        // Player movement down
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
        
        // Player movement up
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
    }

    // OnTrigger events in game (score, health, victory)
    void OnTriggerEnter(Collider other)
    {
        // Add one to score when player triggers gold coin
        if (other.gameObject.tag == "Pickup")
        {
            score += 1;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }

        // Remove 1 health when player triggers the red trap plane
        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            Debug.Log("Health: " + health);
        }

        // Victory when player triggers the green goal plane
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }

    // Game Over and reset game
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
