using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Enemy : MonoBehaviour
{
<<<<<<< Updated upstream
    public Transform rayOrigin;
    public Transform player;
    public enemyStatus status;
    public int rayDistance;
    public bool playerInTarget;
    public NavMeshAgent nav;
    public int raggio;
    public GameObject[] waypoints;
    public Vector3 target;
    public bool changedStatus;
    public bool isworking;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //status = GameObject.Find("GameManager").GetComponent<enemyStatus>();
        waypoints = GameObject.FindGameObjectsWithTag("Waypoints");
        nav = gameObject.GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    private void Update()
    {
        vision();
        if (status.status < 2 && changedStatus == false)
        {
            if (Vector3.Distance(transform.position, target) < 1)
            {
                if (isworking == false)
                {
                    isworking = true;
                    StartCoroutine(waitOnWaipoint(Random.Range(3f, 6f)));
                }
            }
        }
        else if (status.status == 1 && changedStatus == true)
        {
            changedStatus = false;
            if (isworking == false)
            {
                isworking = true;
                StartCoroutine(waitOnWaipoint(0f));
            }
        }

        else
        {
            if (playerInTarget)
            {
                nav.SetDestination(player.position);
            }
            else if (playerInTarget == false && status.status == 2)
            {
                nav.ResetPath();
                nav.SetDestination(status.lastPlayerPosition);
                changedStatus = true;
            }
        }
    }

    void UpdateDestination()
    {
        int x = Random.Range(0, waypoints.Length);
        target = waypoints[x].transform.position;
        nav.SetDestination(target);
        isworking = false;
    }

    IEnumerator waitOnWaipoint(float timer)
    {
        yield return new WaitForSeconds(timer);
        UpdateDestination();
    }

    void vision()
    {
        //rayOrigin.LookAt(player);
        RaycastHit hit;
        for (int x = -raggio; x < raggio; x++)
        {

            if (Physics.Raycast(rayOrigin.position, Quaternion.Euler(0, x, 0) * this.gameObject.transform.forward * rayDistance, out hit, rayDistance))
            {
                if (hit.transform.tag == "Player")
                {
                    playerInTarget = true;
                    Debug.DrawRay(rayOrigin.position, Quaternion.Euler(0, x, 0) * this.gameObject.transform.forward * rayDistance, Color.red);
                    Debug.Log("Did Hit");
                    status.status = 2;
                    status.time = 99f;
                    break;
                }
                else
                {
                    playerInTarget = false;
                    Debug.DrawRay(rayOrigin.position, Quaternion.Euler(0, x, 0) * this.gameObject.transform.forward * rayDistance, Color.green);
                }

            }
            else
            {
                Debug.DrawRay(rayOrigin.position, Quaternion.Euler(0, x, 0) * this.gameObject.transform.forward * rayDistance, Color.green);
            }
        }
=======
    public Transform[] waypoints;
    public NavMeshAgent nav;
    public int currentWaypoint;
    public bool enemyIsMoving; 


    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        UpdatePosition();
        enemyIsMoving = true;
    }

    void Update()
    {
        if(Vector3.Distance(gameObject.transform.position, waypoints[currentWaypoint].position) < 1f && enemyIsMoving)
        {
            enemyIsMoving = false;
            StartCoroutine(WaitOnPoint()); 
        }
    }

    void UpdatePosition()
    {
        currentWaypoint = Random.Range(0, waypoints.Length); 
        nav.SetDestination(waypoints[currentWaypoint].position);
    }

    IEnumerator WaitOnPoint()
    {
        yield return new WaitForSeconds(Random.Range(0f, 4f));
        UpdatePosition();
        enemyIsMoving = true;
>>>>>>> Stashed changes
    }
}
