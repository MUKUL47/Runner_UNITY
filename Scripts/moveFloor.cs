using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveFloor : MonoBehaviour {
    public GameObject o1, o2, o3;
    GameObject Obstacle, Obstacle1, Obstacle2;
    Rigidbody player;
    bool canJump = true, gameOver = true, started = false, FS = false;
    public Text score , speed, GameOver;
    int selectEn;
    float time = 1f, Speed=0f, Score=0f;
    void Start() {
       
        player = GetComponent<Rigidbody>();
    }

    void Update() {
        if (!gameOver) {
            GameOver.text = "";
            playerAction(); moveObstacles(); }
        if (Input.GetKey(KeyCode.Space) && gameOver)
        {
            player.position = new Vector3(32.6f, 0.67f, 3f);
            gameOver = false; selectObstacle();
        }
    }

    public void moveObstacles()
    {
        speed.text = "Speed : "+Speed;
        score.text = "Score : " + Score;
        if (selectEn == 0) {
            if (Obstacle.GetComponent<Rigidbody>().position.x >= 49f)
            {
                Destroy(Obstacle);
                selectObstacle();

            }
            Obstacle.GetComponent<Rigidbody>().velocity = new Vector3(10f+Speed, 0, 0);



        }
        else if (selectEn == 1)
        {
            if (Obstacle1.GetComponent<Rigidbody>().position.x >= 49f)
            {
                Destroy(Obstacle1);
                selectObstacle();

            }
            Obstacle1.GetComponent<Rigidbody>().velocity = new Vector3(10f + Speed, 0, 0);

        }
        else if (selectEn == 2)
        {
            if (Obstacle2.GetComponent<Rigidbody>().position.x >= 49f)
            {
                Destroy(Obstacle2);
                selectObstacle();

            }
            Obstacle2.GetComponent<Rigidbody>().velocity = new Vector3(10f + Speed, 0, 0);

        }
        /*
        else if (selectEn == 3)
        {
            if (Obstacle3.GetComponent<Rigidbody>().position.x >= 49f)
            {
                Destroy(Obstacle3);
                selectObstacle();

            }
            Obstacle3.GetComponent<Rigidbody>().velocity = new Vector3(10f, 0, 0);

        }
        else if (selectEn == 4)
        {
            if (Obstacle4.GetComponent<Rigidbody>().position.x >= 49f)
            {
                Destroy(Obstacle4);
                selectObstacle();

            }
            Obstacle4.GetComponent<Rigidbody>().velocity = new Vector3(10f, 0, 0);

        }*/


    }

    private void OnCollisionEnter(Collision other)
    {
        print(transform.name);
        // print(other.transform.name.Substring(0, 3));  
        if (other.gameObject.name.Substring(0, 3) == "BOX" || other.gameObject.name.Substring(0, 6) == "Sphere" || other.gameObject.name.Substring(0, 4) == "Cube"
            || other.transform.name.Substring(0, 4) == "park" || other.transform.name.Substring(0, 4) == "road")
        {
            gameOver = true;
            Reset();
            
        }
    }
    public void selectObstacle()
    {
        Speed += .5f;
        Score++;
        selectEn = UnityEngine.Random.Range(0, 3);
        if (selectEn == 0) { Obstacle = Instantiate(o1, new Vector3(-10f, 1f, UnityEngine.Random.Range(0, 6)), Quaternion.identity); Obstacle.transform.Rotate(0, -(90f), 0);
        }
        else if(selectEn == 1) { Obstacle1 = Instantiate(o2, new Vector3(-10f, 1f, UnityEngine.Random.Range(0, 6)), Quaternion.identity);  }
        else if (selectEn == 2) { Obstacle2 = Instantiate(o3, new Vector3(-10f, 1f, UnityEngine.Random.Range(0, 6)), Quaternion.identity); Obstacle1.transform.Rotate(0, -(90f), 0); }
     
        // return selectEn;
    }
    public void playerAction()
    {
       
        var z = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        if (Input.GetKeyDown(KeyCode.Space) && canJump && transform.position.y <= .72f) { canJump = false; time = 1f; }
        if (!canJump)
        {
            Physics.gravity = new Vector3(0, 45.0F, 0);
            time -= Time.deltaTime;
            if (time <= .8f)
            {
                canJump = true;
                Physics.gravity = new Vector3(0, -25f, 0);
            }
        }
        transform.Translate(z, 0, 0);
        
    }
    public void Reset()
    {
        Speed = 0f;
        Score = 0f;
        speed.text = "";
        score.text = "";
        GameOver.text = "Gameover!!!\nPress space to start";
        }
    
}
