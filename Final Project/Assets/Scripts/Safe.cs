using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Safe : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private TextMeshProUGUI CodeText;
    public GameObject instructionText;

    string codeText = "";
    public string safeCode;
    public GameObject codePanel;
    private bool isAtDoor = false;
    public GameObject player;
    public int robberEnter = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        instructionText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CodeText.text = codeText;

        if(codeText == safeCode)
        {
            animator.SetBool("isCodeCorrect", true);
            codePanel.SetActive(false);
        }

        if (codeText.Length > 4)
        {
            codeText = "";
        }

        if(Input.GetKey(KeyCode.E) && isAtDoor == true)
        {
            codePanel.SetActive(true);
            instructionText.SetActive(false);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Robber"))
        {
            robberEnter++;
            if(robberEnter == 2)
                animator.SetBool("isCodeCorrect", true);
        }
        isAtDoor = true;
        instructionText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        isAtDoor = false;
        codePanel.SetActive(false);
        instructionText.SetActive(false);
    }

    public void addDigit(string number)
    {
        codeText += number;
    }
}
