using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public void DestroyGate()
    {
        
        // Add any additional logic or animations related to gate destruction here.
        Destroy(gameObject);
    }
}
