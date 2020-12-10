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

    public void LoadMapLoader()
    {
        SceneManager.LoadScene("MapLoadingScene");
    }
    public void LoadSSModel()
    {
        SceneManager.LoadScene("Solar System Model");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void LoadMap()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadEarthAR()
    {
        SceneManager.LoadScene("earthScale");
    }

    public void LoadJupiterAR()
    {
        SceneManager.LoadScene("JupiterScale");
    }

    public void LoadMarsAR()
    {
        SceneManager.LoadScene("marsScale");
    }

    public void LoadMercuryAR()
    {
        SceneManager.LoadScene("mercuryScale");
    }

    public void LoadNeptuneAR()
    {
        SceneManager.LoadScene("NeptuneScale");
    }

    public void LoadSaturnAR()
    {
        SceneManager.LoadScene("SaturnScale");
    }

    public void LoadSunAR()
    {
        SceneManager.LoadScene("sunScale");
    }

    public void LoadUranusAR()
    {
        SceneManager.LoadScene("UranusScale");
    }

    public void LoadVenusAR()
    {
        SceneManager.LoadScene("venusScale");
    }
    public void LoadPlutoAR()
    {
        SceneManager.LoadScene("plutoScale");
    }

    public void LoadAstrodex()
    {
        SceneManager.LoadScene("Astrodex");
    }

    public void LoadMercuryInfo()
    {
        SceneManager.LoadScene("MercuryInfo");
    }

    public void LoadVenusInfo()
    {
        SceneManager.LoadScene("VenusInfo");
    }

    public void LoadEarthInfo()
    {
        SceneManager.LoadScene("EarthInfo");
    }

    public void LoadMarsInfo()
    {
        SceneManager.LoadScene("MarsInfo");
    }

    public void LoadJupiterInfo()
    {
        SceneManager.LoadScene("JupiterInfo");
    }

    public void LoadSaturnInfo()
    {
        SceneManager.LoadScene("SaturnInfo");
    }

    public void LoadUranusInfo()
    {
        SceneManager.LoadScene("UranusInfo");
    }

    public void LoadNeptuneInfo()
    {
        SceneManager.LoadScene("NeptuneInfo");
    }
    public void LoadPlutoInfo()
    {
        SceneManager.LoadScene("PlutoInfo");
    }
}   
