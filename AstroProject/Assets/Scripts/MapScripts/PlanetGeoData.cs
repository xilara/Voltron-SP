/************************************************************************************
*  Created by:    Phillip Powell
*  Date:          28 November 2020
*  
*  Purpose:       Processes NASA data into vector lists and updates planet GameObject
*                  transforms with these vectors over time given. 
*
************************************************************************************/
using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Utilities;
using UnityEngine.UI;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using UnityEngine.UIElements;

public class PlanetGeoData : MonoBehaviour
{
    // Editor variables; can be changed in editor
    [SerializeField] AbstractMap _map;
    [SerializeField] string mapReferencePoint;                  // Where the map center is
    [SerializeField] GameObject Sun;                            // Center position 3D model prefab
    [SerializeField] TextAsset[] planetData;                    // array of NASA orbital data text files
    [SerializeField] GameObject[] planetObjects;                // array of 3D model prefabs
    [SerializeField] private float planetScale = .00125f;       // sets the size of planets
    [SerializeField] private float delayTime = .01f;            // sets the delay in the coroutines


    private float sunScale;                                     // used for Sun's scale. 

    // Indices responsible for iterating through each respective Vector2d list.
    private int mercIndex = 1;
    private int venusIndex = 1;
    private int earthIndex = 1;
    private int marsIndex = 1;
    private int jupiterIndex = 1;
    private int saturnIndex = 1;
    private int uranusIndex = 1;
    private int neptuneIndex = 1;
    private int plutoIndex = 1;

    Vector2d sunVec;
    Vector2d referencePoint;
    GameObject _sun;                    // used to update Sun position in Start and Update functions
    List<GameObject> _spawnPlanets;

    // Lists for storing each planet's geographical locations
    List<Vector2d> mercGeoVecs;
    List<Vector2d> venusGeoVecs;
    List<Vector2d> earthGeoVecs;
    List<Vector2d> marsGeoVecs;
    List<Vector2d> jupiterGeoVecs;
    List<Vector2d> saturnGeoVecs;
    List<Vector2d> uranusGeoVecs;
    List<Vector2d> neptuneGeoVecs;
    List<Vector2d> plutoGeoVecs;

    void Start()
    {
        int planetIndex = 0;            // used to iterate through planets

        referencePoint = Conversions.StringToLatLon(mapReferencePoint);

        sunScale = planetScale * 1000;  // Sun model used is 1/1000 scale, comment out if using new model

        // Sun properties
        _sun = Instantiate(Sun);        // Creates a clone of the prefab

        SphereCollider sunCollider = _sun.AddComponent<SphereCollider>();
        sunCollider.center = Vector3.zero;

        sunVec = VectorExtensions.GetGeoPosition(new Vector2(0, 0), Conversions.LatLonToMeters(referencePoint), .03f);
        _sun.transform.localPosition = _map.GeoToWorldPosition(sunVec, true);
        _sun.transform.localScale = new Vector3(sunScale, sunScale, sunScale);
        _sun.transform.SetParent(this.transform); // Setting GameObject to be a child object

        _spawnPlanets = new List<GameObject>();

        mercGeoVecs = new List<Vector2d>();
        venusGeoVecs = new List<Vector2d>();
        earthGeoVecs = new List<Vector2d>();
        marsGeoVecs = new List<Vector2d>();
        jupiterGeoVecs = new List<Vector2d>();
        saturnGeoVecs = new List<Vector2d>();
        uranusGeoVecs = new List<Vector2d>();
        neptuneGeoVecs = new List<Vector2d>();
        plutoGeoVecs = new List<Vector2d>();

        mercGeoVecs = processPlanetData(planetData[0]);
        venusGeoVecs = processPlanetData(planetData[1]);
        earthGeoVecs = processPlanetData(planetData[2]);
        marsGeoVecs = processPlanetData(planetData[3]);
        jupiterGeoVecs = processPlanetData(planetData[4]);
        saturnGeoVecs = processPlanetData(planetData[5]);
        uranusGeoVecs = processPlanetData(planetData[6]);
        neptuneGeoVecs = processPlanetData(planetData[7]);
        plutoGeoVecs = processPlanetData(planetData[8]);

        foreach (GameObject planet in planetObjects)
        {

            GameObject _planet = Instantiate(planet);      // Creates clones of planet prefabs
            _planet.transform.localScale = new Vector3(planetScale, planetScale, planetScale);
            SphereCollider planetCollider = _planet.AddComponent<SphereCollider>();
            planetCollider.center = Vector3.zero;

            if (_planet.transform.name.Contains("Saturn"))
                planetCollider.radius = 500f;

            // Sets up starting positions of each planet
            switch (planetIndex)
            {
                case 0:
                    _planet.transform.localPosition = _map.GeoToWorldPosition(mercGeoVecs[0], true);
                    break;
                case 1:
                    _planet.transform.localPosition = _map.GeoToWorldPosition(venusGeoVecs[0], true);
                    break;
                case 2:
                    _planet.transform.localPosition = _map.GeoToWorldPosition(earthGeoVecs[0], true);
                    break;
                case 3:
                    _planet.transform.localPosition = _map.GeoToWorldPosition(marsGeoVecs[0], true);
                    break;
                case 4:
                    _planet.transform.localPosition = _map.GeoToWorldPosition(jupiterGeoVecs[0], true);
                    break;
                case 5:
                    _planet.transform.localPosition = _map.GeoToWorldPosition(saturnGeoVecs[0], true);
                    break;
                case 6:
                    _planet.transform.localPosition = _map.GeoToWorldPosition(uranusGeoVecs[0], true);
                    break;
                case 7:
                    _planet.transform.localPosition = _map.GeoToWorldPosition(neptuneGeoVecs[0], true);
                    break;
                case 8:
                    _planet.transform.localPosition = _map.GeoToWorldPosition(plutoGeoVecs[0], true);
                    break;
                default:
                    break;
            } // end switch

            planetIndex++;

            // Sets the planet GameObjects to be a child object of the controller GameObject
            _planet.transform.SetParent(this.transform);

            //Store the planets in a list to pass to the Update function
            _spawnPlanets.Add(_planet);

        } // end foreach

        // Start the coroutines responsible for iterating through the
        //  geographical vector lists responsible for planet positions
        //  on the map.

        StartCoroutine("updateMercGeoVecs");
        StartCoroutine("updateVenusGeoVecs");
        StartCoroutine("updateEarthGeoVecs");
        StartCoroutine("updateMarsGeoVecs");
        StartCoroutine("updateJupiterGeoVecs");
        StartCoroutine("updateSaturnGeoVecs");
        StartCoroutine("updateUranusGeoVecs");
        StartCoroutine("updateNeptuneGeoVecs");
        StartCoroutine("updatePlutoGeoVecs");

    } // end start

    private void Update()
    {
        int count = _spawnPlanets.Count;
        for (int j = 0; j < count; j++)
        {
            GameObject spawnedPlanet = _spawnPlanets[j];

            // Updates the position of the planets every frame; used in case of zoom or panning on map
            switch (j)
            {
                case 0:
                    spawnedPlanet.transform.localPosition = _map.GeoToWorldPosition(mercGeoVecs[mercIndex], true);
                    break;
                case 1:
                    spawnedPlanet.transform.localPosition = _map.GeoToWorldPosition(venusGeoVecs[venusIndex], true);
                    break;
                case 2:
                    spawnedPlanet.transform.localPosition = _map.GeoToWorldPosition(earthGeoVecs[earthIndex], true);
                    break;
                case 3:
                    spawnedPlanet.transform.localPosition = _map.GeoToWorldPosition(marsGeoVecs[marsIndex], true);
                    break;
                case 4:
                    spawnedPlanet.transform.localPosition = _map.GeoToWorldPosition(jupiterGeoVecs[jupiterIndex], true);
                    break;
                case 5:
                    spawnedPlanet.transform.localPosition = _map.GeoToWorldPosition(saturnGeoVecs[saturnIndex], true);
                    break;
                case 6:
                    spawnedPlanet.transform.localPosition = _map.GeoToWorldPosition(uranusGeoVecs[uranusIndex], true);
                    break;
                case 7:
                    spawnedPlanet.transform.localPosition = _map.GeoToWorldPosition(neptuneGeoVecs[neptuneIndex], true);
                    break;
                case 8:
                    spawnedPlanet.transform.localPosition = _map.GeoToWorldPosition(plutoGeoVecs[plutoIndex], true);
                    break;
                default:
                    break;
            } // end switch

        } // end for

        // Continually updates the Sun's position on map
        _sun.transform.localPosition = _map.GeoToWorldPosition(sunVec, true);
    } // end Update


    /************************************************************************************
    *  Created by:    Phillip Powell
    *  Date:          28 November 2020
    *  
    *  Purpose:       Process files containing planetary transforms on the Solar Ecliptic,
    *                  to gather XZ vectors for each planet in the game environment.
    *               
    *  Precondition:  Files must be retrieved or copied from this NASA website:
    *                   https://omniweb.gsfc.nasa.gov/coho/helios/planet.html
    *                 Once processed another link with the data will show above
    *                 the graphs.
    *                 
    *                 (NOTE: Delete first line of file, only numerics allowed)
    *                
    *  Postcondition: Will return a Vector2d List containing all the necessary vectors for the
    *                  given planet
    *                  
    *                  (NOTE: Vector2d is an object in the MapBox API)
    * 
    ************************************************************************************/
    private List<Vector2d> processPlanetData(TextAsset planetData)
    {
        string planetText = planetData.text;
        string[] planetLines = planetText.Split(System.Environment.NewLine.ToCharArray());
        List<Vector2d> planetGeoVecs = new List<Vector2d>();
        try
        {
            foreach (string planetLine in planetLines)
            {
                if (planetLine.Length > 1)      // If string is not empty
                {

                    string tempStr = planetLine;

                    // Formatting text document for processing; using single space as delimiter

                    // Processes all whitespace to a single space.
                    tempStr = tempStr.Replace("  ", " ");
                    tempStr = tempStr.Replace("   ", " ");
                    tempStr = tempStr.Replace("    ", " ");
                    tempStr = tempStr.Replace("\t", " ");

                    string[] planetSingleData = tempStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    float planetVecX = float.Parse(planetSingleData[2]);
                    float planetVecY = float.Parse(planetSingleData[3]);

                    // Temporary Vector2 variable created with each line in file.
                    //  Stores vectors gathered from files; used in geolocation.
                    Vector2 planetVectors = new Vector2(planetVecX, planetVecY);

                    // NMSU map reference point, should be in the Intramural Fields
                    //  Change if using new map.
                    // Vector2d refPoint = new Vector2d(32.279, -106.746);

                    // Converts planet's Cartesian coordinates to latitude and longitude
                    // GetGeoPosition reference point must be in Mercator meters, not lon, lat. 
                    Vector2d geoVectors = VectorExtensions.GetGeoPosition(planetVectors, Conversions.LatLonToMeters(referencePoint), .03f);

                    // Add the geoVector to a list to be returned
                    planetGeoVecs.Add(geoVectors);

                }// end if
            }//end foreach
            return planetGeoVecs;
        }
        catch (Exception e)
        {
            print("Error " + e);
            return null;
        }
    } // end processPlanetData

    // Coroutines
    IEnumerator updateMercGeoVecs()
    {
        WaitForSeconds wait = new WaitForSeconds(delayTime);

        while (true)
        {
            mercIndex = mercIndex + 1;
            if (mercIndex == mercGeoVecs.Count) mercIndex = 0;
            yield return wait;
        }

    }

    IEnumerator updateVenusGeoVecs()
    {
        WaitForSeconds wait = new WaitForSeconds(delayTime);

        while (true)
        {
            venusIndex = venusIndex + 1;
            if (venusIndex == venusGeoVecs.Count) venusIndex = 0;
            yield return wait;
        }

    }

    IEnumerator updateEarthGeoVecs()
    {
        WaitForSeconds wait = new WaitForSeconds(delayTime);

        while (true)
        {
            earthIndex = earthIndex + 1;
            if (earthIndex == earthGeoVecs.Count) earthIndex = 0;
            yield return wait;
        } // end while
    } // end updateEarthGeoVecs

    IEnumerator updateMarsGeoVecs()
    {
        WaitForSeconds wait = new WaitForSeconds(delayTime);

        while (true)
        {
            marsIndex = marsIndex + 1;
            if (marsIndex == marsGeoVecs.Count) marsIndex = 0;
            yield return wait;
        } // end while
    } // end updateMarsGeoVecs

    IEnumerator updateJupiterGeoVecs()
    {
        WaitForSeconds wait = new WaitForSeconds(delayTime);

        while (true)
        {
            jupiterIndex = jupiterIndex + 1;
            if (jupiterIndex == jupiterGeoVecs.Count) jupiterIndex = 0;
            yield return wait;
        } // end while
    } // end updateJupiterGeoVecs

    IEnumerator updateSaturnGeoVecs()
    {
        WaitForSeconds wait = new WaitForSeconds(delayTime);

        while (true)
        {
            saturnIndex = saturnIndex + 1;
            if (saturnIndex == saturnGeoVecs.Count) saturnIndex = 0;
            yield return wait;
        } // end while
    } // end updateSaturnGeoVecs


    IEnumerator updateUranusGeoVecs()
    {
        WaitForSeconds wait = new WaitForSeconds(delayTime);

        while (true)
        {
            uranusIndex = uranusIndex + 1;
            if (uranusIndex == uranusGeoVecs.Count) uranusIndex = 0;
            yield return wait;
        } // end while
    } // end updateUranusGeoVecs

    IEnumerator updateNeptuneGeoVecs()
    {
        WaitForSeconds wait = new WaitForSeconds(delayTime);

        while (true)
        {
            neptuneIndex = neptuneIndex + 1;
            if (neptuneIndex == neptuneGeoVecs.Count) neptuneIndex = 0;
            yield return wait;
        }// end while
    } // end updateNeptuneGeoVecs
    IEnumerator updatePlutoGeoVecs()
    {
        WaitForSeconds wait = new WaitForSeconds(delayTime);

        while (true)
        {
            plutoIndex = plutoIndex + 1;
            if (plutoIndex == plutoGeoVecs.Count) plutoIndex = 0;
            yield return wait;
        } // end while
    } // end updatePlutoGeoVecs
}
