using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class vehicle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 initPos;
    private Quaternion initRot;
    private float speed = 2f;
    private bool isMoving = false;
    //private bool isColliding = false;

    private GameManager gamemanager;

    private int life;
    private int nowScore;
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        initPos = transform.position;
        initRot = transform.rotation;
        
        
    }
    private void OnMouseDown()
    {
        //transform.Translate(Vector3.forward * speed);
        if (gamemanager.isGameActive)
        {
            isMoving = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vehicle") )
        {
            if (isMoving)
            {
                gamemanager.UpdateLife();
                Debug.Log(gameObject.gameObject.name + "was crushed");
            }
            isMoving = false;
            
            
            StartCoroutine(BackToTarget());
            life = gamemanager.GetLife();
            if (life == 0)
            {
                gamemanager.GameOver();
            }


        }
        if (other.gameObject.CompareTag("Wall"))
        {
            gamemanager.AddScore();
            Destroy(gameObject);
            nowScore = gamemanager.GetScore();
            if (nowScore == 9)
            {
                gamemanager.GameSucceed();
            }
            
        }
    }

    IEnumerator BackToTarget()
    {
        while(Vector3.Distance(transform.position, initPos)> 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, initPos, speed * Time.deltaTime);
        }
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
       
        if (isMoving)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if(!isMoving)
        {
            Vector3 currentPos = transform.position;
            transform.position = Vector3.MoveTowards(currentPos, initPos, speed * Time.deltaTime);
        }
        
        
    }
}
