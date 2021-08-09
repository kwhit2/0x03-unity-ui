using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

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

    // to reference ScoreText gameobject & display score
    public Text scoreText;

    // to reference HealthText game object & display health
    public Text healthText;

    // Winning text UI display 
    public Text WinLoseText;

    // background color of You win display
    public Image WinLoseBG;

    // to set You Win display to active when player triggers the goal
    public GameObject winUi; 


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
            SetScoreText();
            Destroy(other.gameObject);
        }

        // Remove 1 health when player triggers the red trap plane
        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            SetHealthText();
        }

        // Victory when player triggers the green goal plane
        if (other.gameObject.tag == "Goal")
        {
            winUi.SetActive(true);
            WinLoseText.text = "You Win!";
            WinLoseBG.color = Color.green;
            WinLoseText.color = Color.black;
            StartCoroutine(LoadScene(3));
        }
    }

    // Game Over and reset game
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }

        if (health == 0)
        {
            winUi.SetActive(true);
            WinLoseText.text = "Game Over!";
            WinLoseBG.color = Color.red;
            WinLoseText.color = Color.white;
            StartCoroutine(LoadScene(3));
        }
    }

    // UI Score: display score when coins are collected
    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    // UI Health: display health of player
    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }

    // Wait for seconds before reloading scene
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
