using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuScr : MonoBehaviour
{
    int Level= 1;
    public static int LevelID=1;
    public static int Mony;
    public Text MonyText;
    public Text LevelText;
    private void Update()
    {
        MonyText.text = Mony.ToString();
        LevelText.text = LevelID.ToString();
    }
    public void LoadLevel()
    {
        Level = LevelID;
        SceneManager.LoadScene(Level);
        print(Level);
    }
    public void ExitLevel()
    {

    }
    public void RetryLevel()
    {

    }
}
