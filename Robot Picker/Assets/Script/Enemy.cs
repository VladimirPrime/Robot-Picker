using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject OrbPrefab;
    
    public float speed = 1;

    public float timeBetweenOrbDrops = 1f;

    public float leftRightDistance = 10f;

    public float chanceDirection = 0.1f;
    void Start()
    {
        Invoke("DropOrb", 2f);   
    }

    void DropOrb()
    {
        Vector3 myVector = new Vector3(0.0f, 0.0f, 0.0f);
        GameObject Orb = Instantiate<GameObject>(OrbPrefab);
        Orb.transform.position = transform.position + myVector;
        Invoke("DropOrb", timeBetweenOrbDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftRightDistance)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftRightDistance)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
     if (Random.value < chanceDirection)
        {
            speed *= -1;
        }   
    }

}
