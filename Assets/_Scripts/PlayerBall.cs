using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBall : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontal;
    private float vertical;
    private float speed = 1;

    public Text myText;

    public List <GameObject> pickUpsDestroyed;

    private int playerScore;

    public GameObject playerBall;

    // Start is called before the first frame update
    void Start()
    {
        playerBall = GameObject.Find("ball");
        pickUpsDestroyed = new List<GameObject>();
        rb = playerBall.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        myText.text = "Score:" + playerScore;
        // read user input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        // call move
        MoveBall();
        // Restart Game 
        if (pickUpsDestroyed.Count == 8)
        {
            playerBall.SetActive(false);
            Invoke("RestartGame", 2);
        }
    }

    // Allow movement of ball from read input 
    void MoveBall()
    {
        rb.AddForce(new Vector3(horizontal, 0.0f, vertical) * speed);
    }

    // detect collision between ball and pickup objects
    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "cube")
        {
            playerScore += 1;
        }
        else if (obj.tag == "pill")
        {
            playerScore += 2;
        }
        else if (obj.tag == "cyl")
        {
            playerScore += 3;
        }
        pickUpsDestroyed.Add(obj.gameObject);
        obj.gameObject.SetActive(false);
    }

    void RestartGame()
    {
        foreach (GameObject obj in pickUpsDestroyed)
        {
            obj.SetActive(true);
        }

        playerBall.SetActive(true);
        playerBall.transform.position = new Vector3(20,0.5f, 30);
        pickUpsDestroyed.Clear();
        playerScore = 0;
    }

}   

