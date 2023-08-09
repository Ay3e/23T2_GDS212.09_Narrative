using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OfficeObjectiveManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] arrayOfObjects;

    private void Update()
    {
        for(int i=0; i< arrayOfObjects.Length; i++)
        {
            arrayOfObjects[i].text = "[X]";
        }
    }
}
