using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EcranDeFin : MonoBehaviour
{
    public int winscene;
    public int defscene;
public void Victory()
    {
        SceneManager.LoadScene(winscene);
    }

public void Defeat()
    {
        SceneManager.LoadScene(defscene);
    }
}
