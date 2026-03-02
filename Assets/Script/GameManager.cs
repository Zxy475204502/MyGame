using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject TitleScreen;
    public TextMeshProUGUI Lifetext;
    public TextMeshProUGUI gameoverText;
    public TextMeshProUGUI succeedText;
    public Button restartbutton;

    public int life;
    public int score;
    
    public bool isGameActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        life = 4;
        score = 0;
        gameoverText.gameObject.SetActive(false);
        succeedText.gameObject.SetActive(false);
        restartbutton.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLife()
    {
        return life;
    }

    public int GetScore()
    {
        return score;
    }
    public void AddScore()
    {
        score++;   
    }

    public void UpdateLife()
    {
        life -= 1;
        Lifetext.text = "Life : " + life;
    }

    public void GameOver()
    {
        gameoverText.gameObject.SetActive(true);
        restartbutton.gameObject.SetActive(true);
        restartbutton.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        life = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameSucceed()
    {
        succeedText.gameObject.SetActive(true);
        restartbutton.gameObject.SetActive(true);
        restartbutton.onClick.AddListener(RestartGame);
    }
}
