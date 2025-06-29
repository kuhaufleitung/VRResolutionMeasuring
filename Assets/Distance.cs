using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    [SerializeField] private GameObject object1;
    [SerializeField] private GameObject object2;
    // Start is called before the first frame update
    void Start()
    {
        if (object1 == null || object2 == null) return;
        float distance = Vector3.Distance(object1.transform.position, object2.transform.position);
        Debug.Log("Distance: " + distance + " units");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
