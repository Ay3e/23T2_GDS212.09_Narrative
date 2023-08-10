using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chapter;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI objective;

    [SerializeField] private GameObject diveAvaliable;


    private void Update()
    {
        if(OfficeObjectiveManager.chapterTwoUnlocked == true)
        {
            chapter.text = "CHAPTER 2";
            title.text = "CLUE HUNTER";
            objective.text = "ASK THE CIVILLIANS AT THE DOCK ABOUT WHAT THEY KNOW";
        }
        else if(JaniceDialogue.activateNewChapter == true)
        {
            chapter.text = "CHAPTER 3";
            title.text = "THE TRUTH";
            objective.text = "HEAD UP NORTH";
        }
        else if(HouseObjectiveManager.chapterThreeDock == true)
        {
            chapter.text = "CHAPTER 3";
            title.text = "THE TRUTH";
            objective.text = "INVESTIGATE THE WATERS AT THE DOCK";
            diveAvaliable.SetActive(true);

        }
    }
}
