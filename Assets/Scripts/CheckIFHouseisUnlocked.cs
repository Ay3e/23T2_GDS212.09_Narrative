using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIFHouseisUnlocked : MonoBehaviour
{
    [SerializeField] private GameObject buttonToHouse;

    private void Update()
    {
        if(JaniceDialogue.activateNewChapter == true)
        {
            buttonToHouse.SetActive(true);
        }
    }
}
