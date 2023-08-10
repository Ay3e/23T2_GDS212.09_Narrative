using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiveManager : MonoBehaviour
{
    [SerializeField] private GameObject textPressEToInteract;

    private bool isPlayerInTrigger = false;

    private void Update()
    {
        if(isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            //Loads to dive in the water scene
            SceneManager.LoadScene(4);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textPressEToInteract.SetActive(true);
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerInTrigger = false;
        textPressEToInteract.SetActive(false);
    }
}
