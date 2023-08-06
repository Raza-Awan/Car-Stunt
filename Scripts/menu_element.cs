using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_element : MonoBehaviour
{
   public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void loadscene(string scenetoload)
    {
        SceneManager.LoadScene(scenetoload);
    }
    public void level1()
    {
        SceneManager.LoadScene(1);
    }
}
