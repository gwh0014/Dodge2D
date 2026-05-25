using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restart;
    public Button endGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (restart != null)
        {
            restart.onClick.AddListener(RestartGame);
        }

        if (endGame != null)
        {
            endGame.onClick.AddListener(QuitGame);
        }

    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverText.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        endGame.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();

        if(Time.timeScale == 0f && Keyboard.current.spaceKey.isPressed)
        {
            RestartGame();
        }

        
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
