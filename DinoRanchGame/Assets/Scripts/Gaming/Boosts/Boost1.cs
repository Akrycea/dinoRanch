using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost1 : MonoBehaviour
{
    public ResourcesManager resourcesManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        resourcesManager.WARM = resourcesManager.WARM + 2 * Time.deltaTime;
    }
}
