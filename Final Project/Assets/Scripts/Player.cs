using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int currentHealth;
    public HealthBar healthBar;
    CharacterController cController;
    float rotationAroundY = 0;
    float rotationAroundX = 0;
    float angularSpeed = 5f;
    float speed = 5f;
    public GameObject aCamera; // public means that it must be connected to some object in Unity

    void Start()
    {
        cController = GetComponent<CharacterController>(); // connect to Character controller of player
        currentHealth = GlobalManager.Instance.getHealth();

        healthBar.SetMaxHealth(100);
        healthBar.SetHealth(currentHealth);

    }

    void Update()
    {
        float deltaz;

        rotationAroundX = -Input.GetAxis("Mouse Y") * angularSpeed;
        // rotates only camera
        aCamera.transform.Rotate(new Vector3(rotationAroundX, 0, 0));

        rotationAroundY = Input.GetAxis("Mouse X") * angularSpeed;
        transform.Rotate(new Vector3(0, rotationAroundY, 0));

        // Time.deltaTime is time btween frames
        deltaz = speed * Input.GetAxis("Vertical") * Time.deltaTime; // can be {1,0,-1}

        Vector3 motion = new Vector3(0, -0.5f, deltaz);// always forward in Local coordinates
        motion = transform.TransformDirection(motion); // transforms motion to GLOBAL coordinates
        cController.Move(motion);// gets vector in GLOBAL coordinates
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth == 0)
        {
            SceneManager.LoadScene(3);
        }
            
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }    
}