using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraClickScript : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] GameObject buttonScript;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit mouseHit;

            if (Physics.Raycast(mouseRay, out mouseHit))
            {
                string objectName = mouseHit.transform.name;

                if (objectName.Contains("Sun"))
                    SceneManager.LoadScene("sunScale");

                if (objectName.Contains("Mercury"))
                    SceneManager.LoadScene("mercuryScale");

                if (objectName.Contains("Venus"))
                    SceneManager.LoadScene("venusScale");

                if (objectName.Contains("Earth"))
                    SceneManager.LoadScene("earthScale");

                if (objectName.Contains("Mars"))
                    SceneManager.LoadScene("marsScale");

                if (objectName.Contains("Jupiter"))
                    SceneManager.LoadScene("JupiterScale");

                if (objectName.Contains("Saturn_1_120536"))
                    SceneManager.LoadScene("SaturnScale");

                if (objectName.Contains("Uranus"))
                    SceneManager.LoadScene("UranusScale");

                if (objectName.Contains("Neptune"))
                    SceneManager.LoadScene("NeptuneScale");

                if (objectName.Contains("Pluto"))
                    SceneManager.LoadScene("plutoScale");

                //if(objectName.Contains("Pluto"))
                //    buttonScript.GetComponent<ButtonScript>().LoadPlutoAR();   
            }
        }

        for(int i = 0; i < Input.touchCount; i++)
        {
            if(Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray touchRay = camera.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit touchHit;

                if (Physics.Raycast(touchRay, out touchHit))
                {
                    string objectName = touchHit.transform.name;

                    if(objectName.Contains("Sun"))
                        SceneManager.LoadScene("sunScale");

                    if (objectName.Contains("Mercury"))
                        SceneManager.LoadScene("mercuryScale");

                    if (objectName.Contains("Venus"))
                        SceneManager.LoadScene("venusScale");

                    if (objectName.Contains("Earth"))
                        SceneManager.LoadScene("earthScale");

                    if (objectName.Contains("Mars"))
                        SceneManager.LoadScene("marsScale");

                    if (objectName.Contains("Jupiter"))
                        SceneManager.LoadScene("JupiterScale");

                    if (objectName.Contains("Saturn"))
                        SceneManager.LoadScene("SaturnScale");

                    if (objectName.Contains("Uranus"))
                        SceneManager.LoadScene("UranusScale");

                    if (objectName.Contains("Neptune"))
                        SceneManager.LoadScene("NeptuneScale");

                    if (objectName.Contains("Pluto"))
                        SceneManager.LoadScene("plutoScale");

                } // end if
            } // end if
        } // end for
        
    } // end Update
} // end script
