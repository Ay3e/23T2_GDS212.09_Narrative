using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LouieDialogue : MonoBehaviour
{
    [SerializeField] private GameObject textPressEToInteract;
    [SerializeField] private GameObject dialogue;

    private bool isInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = true;
            textPressEToInteract.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInTrigger = false;
        textPressEToInteract.SetActive(false);
        dialogue.SetActive(false);
    }

    private void Update()
    {
        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            dialogue.SetActive(true);
            textPressEToInteract.SetActive(false);
        }
    }
}
