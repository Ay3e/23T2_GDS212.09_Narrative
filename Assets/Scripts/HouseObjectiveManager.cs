using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HouseObjectiveManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] arrayOfObjects;
    private int knifeNumebrID = 0;
    private int photoNumberID = 1;

    [SerializeField] private GameObject oldChapter;
    [SerializeField] private GameObject newChapter;


    public static bool chapterThreeDock = false;

    private void Update()
    {
        for (int i = 0; i < arrayOfObjects.Length; i++)
        {
            if (OutlineSelection.knifeCheckbox)
            {
                arrayOfObjects[knifeNumebrID].text = "[X]";
            }
            if (OutlineSelection.photoCheckbox)
            {
                arrayOfObjects[photoNumberID].text = "[X]";
            }
        }

        if(OutlineSelection.knifeCheckbox && OutlineSelection.photoCheckbox)
        {
            chapterThreeDock = true;
            oldChapter.SetActive(false);
            newChapter.SetActive(true);
            JaniceDialogue.activateNewChapter = false;
        }
    }
}
