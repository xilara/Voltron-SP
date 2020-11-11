/**********************************************************************************************
 *  Version:    1.0                                                                           *
 *  Author:     Phillip Powell                                                                *
 *  Contact:    pmpowell92@gmail.com, ppowell1@nmsu.com                                       *
 *                                                                                            *
 *  Preconditions:  The script should be a component of the "Solar System Properties"         *
 *                   GameObject inside the "Solar System Model" Scene                         *
 *                                                                                            *
 *  Postcondition:  The script will affect the transforms of all celestial objects            *
 *                   in the "Solar System Model" scene.                                       *
 *                                                                                            *
 *                                                                                            *
 *  
 *                                                                                            *
 **********************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarDistances : MonoBehaviour
{
    // References the "Solar System Properties" child objects

    [SerializeField] private GameObject[] SolarSystemObjects = new GameObject[9];
    [SerializeField] public float solarSystemScale = .00001f;
    //[SerializeField] private float distanceScale = 1f;
    [SerializeField] public int rotation = 90;
    // Needed for rotation transforms.

    Quaternion solarSystemRotation;
    Quaternion ninetyDegrees = Quaternion.Euler(90, 0, 0);

    /***************************************************************************************
     *                                                                                     *
     *                                  Properties                                         *
     *                                                                                     *
     ***************************************************************************************/

    
    // Sun Properties (NASA Sun model came in at 1/1000 scale compared to Earth's model)
    public float sunScale = 218490f;            // 218.49 times Earth's diameter

    // Mercury Properties
    public float mercuryScale = 0.3829383f;     // 0.3829383 times Earth's diameter

    // Venus Properties
    public float venusScale = 0.949898f;

    // Earth Properties
    public float earthScale = 1f;

    // Mars Properties
    public float marsScale = 0.5320201f;

    // Jupiter Properties
    public float jupiterScale = 10.97332f;

    // Saturn Properties
    public float saturnScale = 9.140166f;

    // Uranus Properties
    public float uranusScale = 3.980851f;

    // Neptune Properties
    public float neptuneScale = 3.864699f;

    // Start is called before the first frame update
    void Start()
    {

        /***************************************************************************************
         *                                                                                     *
         *                                  Properties                                         *
         *                                                                                     *
         ***************************************************************************************/

        solarSystemRotation = Quaternion.Euler(90, 0, 0);

        // Sun Properties (NASA Sun model came in at 1/1000 scale compared to Earth's model)

        float sunPos = 0f * solarSystemScale;

        // Mercury Properties

        float mercuryPos = 46989000f * solarSystemScale;        // 46,989,000 km 4.6989+e7

        // Venus Properties

        float venusPos = 107480000f * solarSystemScale;         // 107,480,000 km   1.0748e+8 

        // Earth Properties

        float earthPos = 148620000f * solarSystemScale;         // 148,620,000 km  1.4862e+8

        // Mars Properties

        float marsPos = 215280000f * solarSystemScale;          // 215,280,000 km  2.1528e+8

        // Jupiter Properties

        float jupiterPos = 766110000f * solarSystemScale;       // 766,110,000 km  7.6611e+8

        // Saturn Properties

        float saturnPos = 1492700000f * solarSystemScale;       // 1,492,700,000 km 1.4927e+9

        // Uranus Properties

        float uranusPos = 2958900000f * solarSystemScale;       // 2,958,900,000 km  2.9589e+9

        // Neptune Properties       
        float neptunePos = 4476200000f * solarSystemScale;      // 4,476,200,000 km 4.4762e+9

        /***************************************************************************************
         *                                                                                     *
         *                                  Transforms                                         *
         *                                                                                     *
         ***************************************************************************************/

        // Solar System Properties Transforms (Script should be in "Solar System Properties")
        //  "this" should reference the "Solar System Properties" GameObject in Scene.

        this.transform.rotation = solarSystemRotation;
        this.transform.position = new Vector3(0, 0, 0);
        this.transform.localScale = new Vector3(.00001f, .00001f, .00001f);

        // Sun Properties Transforms
        SolarSystemObjects[0].transform.position = new Vector3(sunPos, 0, 0);
        SolarSystemObjects[0].transform.localScale = new Vector3(sunScale, sunScale, sunScale);

        // Mercury Properties Transforms
        SolarSystemObjects[1].transform.position = new Vector3(mercuryPos, 0, 0);
        SolarSystemObjects[1].transform.localScale = new Vector3(mercuryScale, mercuryScale, mercuryScale);

        // Venus Properties Transforms
        SolarSystemObjects[2].transform.position = new Vector3(venusPos, 0, 0);
        SolarSystemObjects[2].transform.localScale = new Vector3(venusScale, venusScale, venusScale);

        // Earth Properties Transforms
        SolarSystemObjects[3].transform.position = new Vector3(earthPos, 0, 0);
        SolarSystemObjects[3].transform.localScale = new Vector3(earthScale, earthScale, earthScale);

        // Mars Properties Transforms
        SolarSystemObjects[4].transform.position = new Vector3(marsPos, 0, 0);
        SolarSystemObjects[4].transform.localScale = new Vector3(marsScale, marsScale, marsScale);

        // Jupiter Properties Transforms
        SolarSystemObjects[5].transform.position = new Vector3(jupiterPos, 0, 0);
        SolarSystemObjects[5].transform.localScale = new Vector3(jupiterScale, jupiterScale, jupiterScale);

        // Saturn Properties Transforms
        SolarSystemObjects[6].transform.position = new Vector3(saturnPos, 0, 0);
        SolarSystemObjects[6].transform.localScale = new Vector3(saturnScale, saturnScale, saturnScale);

        // Uranus Properties Transforms
        SolarSystemObjects[7].transform.position = new Vector3(uranusPos, 0, 0);
        SolarSystemObjects[7].transform.localScale = new Vector3(uranusScale, uranusScale, uranusScale);

        // Neptune Properties Transforms
        SolarSystemObjects[8].transform.position = new Vector3(neptunePos, 0, 0);
        SolarSystemObjects[8].transform.localScale = new Vector3(neptuneScale, neptuneScale, neptuneScale);
    }

}
