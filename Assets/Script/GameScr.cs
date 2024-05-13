using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScr : MonoBehaviour
{
    public int Scory;
    public int ScoryMax;
    public Text ScoryText;
    public Text ScoreMax;
    public int MonyPlus;
    public GameObject MenuObj;
    public GameObject MenuWinObj;
    bool ActiveMenu=false;
    public float Timers;
    void Update()
    {
        ScoryText.text = Scory.ToString()+"/"+ ScoryMax.ToString();
        if (Scory>=ScoryMax)
        {
            MenuWinObj.SetActive(true);
        }
        CheckVoxels();
    }

    void CheckVoxels()
    {
        GameObject[] voxels = GameObject.FindGameObjectsWithTag("Voxel");
        bool allTrue = true;

        foreach (GameObject voxel in voxels)
        {
            VoxelScr voxelScript = voxel.GetComponent<VoxelScr>();
            if (voxelScript != null)
            {
                if (!voxelScript.IsTrue)
                {
                    allTrue = false;
                    break;
                }
            }
        }

        if (allTrue)
        {
            Timers -= Time.deltaTime;
            Debug.Log("Все зайнято");
            if (Timers < 0)
            {
                ExitLevel();
            }
        }
        else
        {
            Timers = 0.5f;
        }
    }

    public void Menus()
    {
        if (ActiveMenu == false)
        {
            MenuObj.SetActive(true);
        }
        else
        {
            MenuObj.SetActive(false);
        }
    }

    public void ExitLevel()
    {

        SceneManager.LoadScene(0);
    }
    public void WinLevel()
    {
        SceneManager.LoadScene(0);
        MenuScr.Mony += 30;
        MenuScr.LevelID++;
    }

    public void UpWinLevel()
    {
        SceneManager.LoadScene(0);
        MenuScr.Mony += 90;
        MenuScr.LevelID++;
    }


    public void RetryLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
