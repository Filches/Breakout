using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    AudioSource sond;
    public AudioClip wong, gaeover, deth;

    public bool bed;
    public int redLives = 3, bluLives = 3;
    public int redbricks = 20, blubricks = 20;
    public float resetDelay = 1f;
    public Text livesTextRed, livesTextBlu;
    public GameObject gameOverRed, gameOverBlu;
    public GameObject youWonRed, youWonBlu;
    public GameObject bricksPrefab, bricksPrefab2;
    public GameObject redpaddle, blupaddle;
    public GameObject deathParticles, deathParticles2;
    public static GM instance = null;

    private GameObject clonePaddle, clonePaddle2;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();

        sond = GetComponent<AudioSource>();
   
    }

    public void Setup()
    {
        clonePaddle = Instantiate(redpaddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);

        clonePaddle2 = Instantiate(blupaddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab2, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        if (redbricks < 1)
        {
            youWonRed.SetActive(true);
            Time.timeScale = .25f;
            Invoke ("RestartGame", resetDelay);
            sond.PlayOneShot(wong);
        }

        if (blubricks < 1)
        {
            youWonBlu.SetActive(true);
            Time.timeScale = .25f;
            Invoke("RestartGame", resetDelay);
            sond.PlayOneShot(wong);
        }

        if (redLives <1)
        {
            gameOverRed.SetActive(true);
            Time.timeScale = .25f;
            Invoke ("RestartGame", resetDelay);
            sond.PlayOneShot(gaeover);
        }

        if (bluLives < 1)
        {
            gameOverBlu.SetActive(true);
            Time.timeScale = .25f;
            Invoke("RestartGame", resetDelay);
            sond.PlayOneShot(gaeover);
        }
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void LoseLifeRed()
    {
        redLives--;
        livesTextRed.text = "RED LIVES: " + redLives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke ("SetupPaddle", resetDelay);
        CheckGameOver();
        sond.PlayOneShot(deth);

    }
    public void LoseLifeBlu()
    {
        bluLives--;
        livesTextBlu.text = "BLU LIVES: " + bluLives;
        Instantiate(deathParticles2, clonePaddle2.transform.position, Quaternion.identity);
        Destroy(clonePaddle2);
        Invoke("SetupPaddle2", resetDelay);
        CheckGameOver();
        sond.PlayOneShot(deth);

    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(redpaddle, transform.position, Quaternion.identity) as GameObject;
    }

    void SetupPaddle2()
    {
        clonePaddle2 = Instantiate(blupaddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyRedBrick()
    {
        redbricks--;
        CheckGameOver();
    }
    public void DestroyBluBrick()
    {
        blubricks--;
        CheckGameOver();
    }
    
}
