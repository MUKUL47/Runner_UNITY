using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour {
    Rigidbody player;
    public GameObject camera;
    int pos = 0;

    // Use this for initialization
    void Start () {
        player = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (pos == 0)
        {
            player.velocity = new Vector3(-1, 0, 0);
            camera.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0);
            camera.GetComponent<Rigidbody>().position = new Vector3(player.position.x + 1.5f, player.position.y, player.position.z);
            camera.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(0, -90, 0)));
        }
        if (pos == 1)
        {
            player.velocity = new Vector3(0, 0, 1);
            camera.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
            camera.GetComponent<Rigidbody>().position = new Vector3(player.position.x, player.position.y, player.position.z - 1.5f);
            camera.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (pos == 2)
        {
            player.velocity = new Vector3(1, 0, 0);
            camera.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0);
            camera.GetComponent<Rigidbody>().position = new Vector3(player.position.x - 1.5f, player.position.y, player.position.z);
            camera.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(0, 90, 0)));
        }
        if (pos == 3)
        {
            player.velocity = new Vector3(0, 0, -1);
            camera.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
            camera.GetComponent<Rigidbody>().position = new Vector3(player.position.x, player.position.y, player.position.z + 1.5f);
            camera.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(0, 180, 0)));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) pos += 1;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (pos == 0) pos = 3;

            else pos -= 1; if (pos < 0) pos *= -1;

        }

        pos %= 4;
    }
}
