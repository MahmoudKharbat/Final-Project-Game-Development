using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    private static GlobalManager _instance;
    private static int playerWins = 0;
    //public static int maxHealth = 100;
    private static int currentHealth = 100;
    public HealthBar healthBar;

    public static GlobalManager Instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("Global Manager is null");
            return _instance; 
        }
    }
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Debug.LogError("Global Manager Already Exist");
            Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            healthBar.SetHealth(currentHealth);
        }
    }

    public void addWin()
    {
        playerWins++;
        Debug.Log("Numbers Of Winnings = " + playerWins);
    }
    public int getHealth()
    {
        return currentHealth;
    }
    public void updateHealth(int health)
    {
        currentHealth = health;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
