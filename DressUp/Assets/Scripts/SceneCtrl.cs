using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GotoNextScene()
    {
        GameObject girl = GameObject.Find("Girl");

        girl.GetComponent<Character>().SaveCurrentDresses();
        SceneManager.LoadScene("GameScene");
    }
}
