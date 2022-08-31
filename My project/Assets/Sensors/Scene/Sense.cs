using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sense : MonoBehaviour
{
    protected bool playerDetected;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();   
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSense();   
    }

    protected virtual void Initialize() { }

    protected virtual void UpdateSense() { }
}
