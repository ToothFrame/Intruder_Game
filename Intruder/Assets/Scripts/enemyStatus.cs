using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStatus : MonoBehaviour
{
    public float time;
    public int status;
    public Vector3 lastPlayerPosition;
    public Transform Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (status == 0)
        {
            return;
        }

        if (status == 1)
        {
            if (time > 0)
            {
                time -= Time.deltaTime * 10;
            }
            else
            {
                time = 0;
                status = 0;
            }
        }

        if (status == 2)
        {
            if (time > 0)
            {
                if (time > 98.99f)
                {
                    lastPlayerPosition = Player.position;
                }
                time -= Time.deltaTime * 10;
            }
            else
            {
                time = 99f;
                status = 1;
                
            }
        }
    }
}
