using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class RobberScript : MonoBehaviour
{
    // fire script
    public Animator animator;
    public GameObject player_target;
    public NavMeshAgent robber;
    public GameObject rifle;
    public GameObject currNpc;
    private bool goToSafe = true;
    private bool goGetSafeDoorCode = true;
    private bool CollectMoney = true;
    private bool runSomeWhere = true;
    private bool arrivedDestination  = false;
    private int health = 100;
    void Start()
    {
        robber = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    public int Health
    {
        get { return health; }   // get method
        set { health = value; }  // set method
    }
    // shotgun script
    void Update()
    {
        if (health == 0)
        {
            print("Robber you are dead");
            robber.enabled = false;
            rifle.SetActive(false);
            animator.SetInteger("state", 2);
            StartCoroutine(waitBeforeNewScene());
            // if robber is dead, cop won
        }
        if(!runSomeWhere && arrivedDestination)
        {
            robber.enabled = false;
            rifle.SetActive(false);
            StartCoroutine(waitBeforeNewScene());                    
            Destroy(currNpc);
        }
    }

    IEnumerator waitBeforeStart()
    {
        yield return new WaitForSeconds(10f);
        if (goToSafe)
        {
            // Safe Door Coordinate Coordinate (-9.3f, 2.51f, -3f)
            robber.SetDestination(new Vector3(-9.3f, 0f, -3f));
            goToSafe = false;
            animator.SetTrigger("Start");
            animator.SetInteger("state", 1);
        }
    }

    IEnumerator waitBeforeNewScene()
    {
        if (health == 0) // Robber is dead.
        {
            GlobalManager.Instance.addWin();
            SceneManager.LoadScene("Scenes/WinTheGame");
        }
        else
        {
            SceneManager.LoadScene("Scenes/GameOver");
        }
        yield return new WaitForSeconds(0.05f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //goToSafeDoor
        if (collision.tag == "goToSafe")
        {
            StartCoroutine(waitBeforeStart());
        }

        //goGetSafeDoorCode
        if (collision.tag == "goGetSafeDoorCode")
        {
            if(goGetSafeDoorCode)
            {
                // Code Location Coordinate (-13.5f, 2.51f, -17.5f)
                robber.SetDestination(new Vector3(-13.5f, 2.51f, -17.5f));
                goGetSafeDoorCode = false;
            }
        }
        //comeBackToSafeDoorWithCode
        if (collision.tag == "comeBackToSafeDoorWithCode")
        {
            // Safe Door Code Coordinate (-9.4f, 2.51f, -2.6f)
            robber.SetDestination(new Vector3(-9.4f, 2.51f, -2.6f));
        }

        //CollectMoney
        if (collision.tag == "CollectMoney")
        {
            if (CollectMoney && !goGetSafeDoorCode)
            {
                // Money Coordinate (-12f, 2.51f, -13.1f)
                robber.SetDestination(new Vector3(-12f, 2.51f, -13.1f));
                CollectMoney = false;
            }
            if(goGetSafeDoorCode)
            {
                robber.SetDestination(new Vector3(-6.5f, 2.51f, -2.5f));
            }
        }

        if (collision.tag == "CollectMoney01")
        {
            // Money Coordinate (-15.25f, 2.51f, -13.1f)
            robber.SetDestination(new Vector3(-15.25f, 2.51f, -13.1f));
        }

        if (collision.tag == "CollectMoney02")
        {
            // Money Coordinate (-15.65f, 2.51f, -10.85f)
            robber.SetDestination(new Vector3(-15.65f, 2.51f, -10.85f));
        }

        if (collision.tag == "CollectMoney03")
        {
            // Money Coordinate (-15.65f, 2.51f, -6.6f)
            robber.SetDestination(new Vector3(-15.65f, 2.51f, -6.6f));
        }

        if (collision.tag == "CollectMoney04")
        {
            // Money Coordinate (-15.65f, 2.51f, -2.6f)
            robber.SetDestination(new Vector3(-15.65f, 2.51f, -2.6f));
        }

        if (collision.tag == "CollectMoney05")
        {
            // Money Coordinate (-15.65f, 2.51f, 1.4f)
            robber.SetDestination(new Vector3(-15.65f, 2.51f, 1.4f));
        }

        if (collision.tag == "CollectMoney06")
        {
            // Money Coordinate (-15.65f, 2.51f, 1.4f)
            robber.SetDestination(new Vector3(-15.65f, 2.51f, 5.4f));
        }

        if (collision.tag == "CollectMoney07")
        {
            // Money Coordinate (-14.9f, 2.51f, 8.17f)
            robber.SetDestination(new Vector3(-14.9f, 2.51f, 8.17f));
        }

        if (collision.tag == "CollectMoney08")
        {
            // Money Coordinate (-12f, 2.51f, 8f)
            robber.SetDestination(new Vector3(-12f, 2.51f, 8f));
        }

        //runSomeWhere
        if (collision.tag == "runSomeWhere")
        {
            runSomeWhere = false;
            // Destination Coordinate
            robber.SetDestination(new Vector3(20f, 2.51f, 1f));
        }
        // arrived Destination
        if (collision.tag == "Destination")
        {
            if(runSomeWhere == false)
                arrivedDestination = true;
        }
    }
}