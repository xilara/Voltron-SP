using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadSpaceHunt()
    {
        SceneManager.LoadScene("SpaceHunt");
    }

    public void LoadSSModel()
    {
        SceneManager.LoadScene("Solar System Model");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }
   
}
