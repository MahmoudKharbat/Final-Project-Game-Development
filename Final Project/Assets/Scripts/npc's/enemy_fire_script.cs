using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_fire_script : MonoBehaviour
{
    //public GameObject aCamera;
    public GameObject player_target;
    public GameObject startPoint;
    private LineRenderer lr;
    AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            if (Physics.Raycast(player_target.transform.position, player_target.transform.forward, out hit))
            {
                sound.Play();
                //player_target.transform.position = hit.point;
                StartCoroutine(FireFlash());
            }
        }
    }

    IEnumerator FireFlash()
    {
        lr.enabled = true;
        lr.SetPosition(0, startPoint.transform.position);
        lr.SetPosition(1, player_target.transform.position);
        yield return new WaitForSeconds(0.05f);
        //lr.SetPosition(1, startPoint.transform.position);
        lr.enabled = false;
    }
}
