using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Button startbutton;
    private GameManager gamemanager;
    
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startbutton = GetComponent<Button>();
        startbutton.onClick.AddListener(Startgame);

    }

    void Startgame()
    {
        Debug.Log(startbutton.gameObject.name + " was clicked");
        gamemanager.TitleScreen.SetActive(false);
        gamemanager.isGameActive = true;
        gamemanager.UpdateLife();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
