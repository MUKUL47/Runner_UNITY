using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateTerrain : MonoBehaviour
{

    public Transform prefab;
    float t = 1, c = 1, prevX, prevZ, pos = 0 , k=0, till=.5f,dO=0;
    string direction = "F";
    void Start()
    {
        c = UnityEngine.Random.RandomRange(3, 8);
        prevX = prevZ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        string boxname = "";
           t -= Time.deltaTime;
        boxname = k + "";
        if (pos == 0)
        {
            if (t < 0)
            {
                
                Transform box = Instantiate(prefab, new Vector3(prevX + .992f, 0, prevZ), Quaternion.identity); box.name = k + "";
                prevX = box.transform.position.x;
                prevZ = box.transform.position.z;
                t = .1f; c--;
                k++;
            }
        }
        if (pos == 1)
        {
            if (t < 0)
            {
                
                Transform box = Instantiate(prefab, new Vector3(prevX, 0, prevZ - .992f), Quaternion.identity); box.name = k + "";
                prevX = box.transform.position.x;
                prevZ = box.transform.position.z;
                t = .1f; c--;
                k++;
            }
        }
        if (pos == 2)
        {
            if (t < 0)
            {
                
                Transform box = Instantiate(prefab, new Vector3(prevX - .992f, 0, prevZ), Quaternion.identity); box.name = k + "";
                prevX = box.transform.position.x;
                prevZ = box.transform.position.z;
                t = .1f; c--;
                k++;
            }
        }
        if (pos == 3)
        {
            if (t < 0)
            {
                
                Transform box = Instantiate(prefab, new Vector3(prevX, 0, prevZ + .992f), Quaternion.identity); box.name = k + "";
                prevX = box.transform.position.x;
                prevZ = box.transform.position.z;
                t = .1f; c--;
                k++;
            }
        }

    

        if (c == 0)
        {
            c = UnityEngine.Random.RandomRange(10, 30);
            int dir = UnityEngine.Random.RandomRange(0, 2);
            if (dir == 1) { pos += 1; }

            if (dir == 0)
            {
                if (pos == 0) pos = 3;

                else pos -= 1; if (pos < 0) pos *= -1;

            }
            pos %= 4;

            }
          
        }
    }

