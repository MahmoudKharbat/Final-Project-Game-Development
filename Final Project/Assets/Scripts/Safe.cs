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
           // print("hello");
            codePanel.SetActive(true);
            instructionText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("hello from trigger1");
        isAtDoor = true;
        instructionText.SetActive(true);
        /*if (other.gameObject == player.gameObject)
        {
            print("hello from trigger");
            isAtDoor = true;
        }*/
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
