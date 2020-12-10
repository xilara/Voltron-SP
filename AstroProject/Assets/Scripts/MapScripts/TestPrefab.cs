using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPrefab : MonoBehaviour
{
    [SerializeField] GameObject testObj;


    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = Instantiate(testObj);

        SphereCollider tempCollider = temp.AddComponent<SphereCollider>();
        tempCollider.center = Vector3.zero;

    }
}
