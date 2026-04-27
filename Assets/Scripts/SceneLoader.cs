using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//画面遷移
public class SceneLoader : MonoBehaviour
{

    public void SceneChangeOpening()
    {
        SceneManager.LoadScene("OpeningScene");
    }
    public void SceneChangeFloorMap()
    {
        SceneManager.LoadScene("FloorMapScene");
    }
    public void SceneChangeCulpritSelect()
    {
        SceneManager.LoadScene("CulpritSelectScene");
    }
    public void SceneChangeTrueEnding()
    {
        SceneManager.LoadScene("TrueEnding");
    }
    public void SceneChangeFalseEnding()
    {
        SceneManager.LoadScene("FalseEnding");
    }
    public void SceneChangeStart()
    {
        SceneManager.LoadScene("StartScene");
    }


}
