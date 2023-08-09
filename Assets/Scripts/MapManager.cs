using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [SerializeField] private int theOffice = 0;
    [SerializeField] private int theDock = 1;
    [SerializeField] private int theHouse = 2;
    [SerializeField] private int map = 3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(map);
        }
    }

    public void SceneTheOffice()
    {
        SceneManager.LoadScene(theOffice);
    }

    public void SceneTheDock()
    {
        SceneManager.LoadScene(theDock);
    }

    public void SceneTheHouse()
    {
        SceneManager.LoadScene(theHouse);
    }
}
