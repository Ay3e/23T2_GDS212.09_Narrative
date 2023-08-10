using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OfficeObjectiveManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] arrayOfObjects;
    private int pistolNumberID = 0;
    private int chocolateNumberID = 1;
    private int sodaNumberID = 2;

    [SerializeField] private GameObject disenableDialogue;
    [SerializeField] private GameObject oldChapter;
    [SerializeField] private GameObject newChapter;
    [SerializeField] private GameObject activateMap;
    public static bool chapterTwoUnlocked = false;

    private void Start()
    {
        activateMap.SetActive(false);
    }
    private void Update()
    {
        for(int i=0; i< arrayOfObjects.Length; i++)
        {
            if (OutlineSelection.pistolCheckbox)
            {
                arrayOfObjects[pistolNumberID].text = "[X]";
            }
            if (OutlineSelection.chocolateCheckbox)
            {
                arrayOfObjects[chocolateNumberID].text = "[X]";
            }
            if (OutlineSelection.sodaCheckbox)
            {
                arrayOfObjects[sodaNumberID].text = "[X]";
            }
        }

        if(OutlineSelection.pistolCheckbox && OutlineSelection.chocolateCheckbox && OutlineSelection.sodaCheckbox)
        {
            disenableDialogue.SetActive(false);
            oldChapter.SetActive(false);
            newChapter.SetActive(true);
            chapterTwoUnlocked = true;
            activateMap.SetActive(true);
        }
    }
}
