using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject selectedZombie;
    public GameObject [] zombies;
    public Vector3 selectedSize;
    private InputAction left, right, Jump;
    private int selectedIndex;
    public Vector3 pushForce;
    public TMP_Text timerText;
    private float time = 0;
    public int score = 0;
    public TMP_Text scoreText;
    public GameObject losePanel;
    public bool isGameOver = false;
    public int totalCollectibles;
    public int collected;
    public GameObject winPanel;
    public int zombiesInDeathZone = 0;
    public GameObject startPanel; 
    public bool gameStarted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;
        startPanel.SetActive(true);
        selectZombie(0);
        left = InputSystem.actions.FindAction("PrewZombie");
        right = InputSystem.actions.FindAction("NextZombie");
        Jump = InputSystem.actions.FindAction("Jump"); 
        
            //Debug.Log("selected" + selectedZombie.name);
    }

    void selectZombie(int index)
    {
        if (selectedZombie != null)
            selectedZombie.transform.localScale = Vector3.one;
        selectedZombie = zombies[index];
        selectedZombie.transform.localScale = selectedSize;
        Debug.Log("selected" + selectedZombie.name);
    }

    public void AddScore(int amount)
    {
        score += amount; scoreText.text = "Score: " + score; collected++; if (collected >= totalCollectibles) WinGame();
        
    }

    public void StartGame()
    {
        gameStarted = true; startPanel.SetActive(false); Time.timeScale = 1f;
        
    }

    public void LoseGame()
    {
        if (isGameOver) return;
        isGameOver = true; losePanel.SetActive(true);
        Time.timeScale = 0f;
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlaySFX(AudioManager.Instance.loseSound);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        AudioManager.Instance.PlayMusic();


    }

    public void QuitGame()
    {
        Application.Quit();
        
    }
    
    public void WinGame()
    {
        if (isGameOver) return;

        isGameOver = true; winPanel.SetActive(true); 
        Time.timeScale = 0f;
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlaySFX(AudioManager.Instance.winSound);

    }
    
    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;
        if (left.WasReleasedThisFrame())
        {
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = 3;
            selectZombie(selectedIndex);
            Debug.Log("Left is pressed");

        }

        if (right.WasPressedThisFrame())
        {
            selectedIndex++;
            if (selectedIndex >= zombies.Length)
                selectedIndex = 0;
            selectZombie(selectedIndex);
            Debug.Log("Right is pressed");

        }

        if (Jump.WasPressedThisFrame())
        {
            Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
            rb.AddForce(pushForce);
            Debug.Log("Jump is pressed");
        }
        time += Time.deltaTime;
        timerText.text = "Time:" + time.ToString("F1") + "s";
    }
}
