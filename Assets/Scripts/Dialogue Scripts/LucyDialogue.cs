using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucyDialogue : MonoBehaviour
{
    [SerializeField] private GameObject textPressEToInteract;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textPressEToInteract.SetActive(true);
            Debug.Log("Hi");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textPressEToInteract.SetActive(false);
    }
}
