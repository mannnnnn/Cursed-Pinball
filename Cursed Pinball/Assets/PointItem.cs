using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointItem : MonoBehaviour
{
    
    public void PointTypeAcquired()
    {
        GetComponent<Animator>().SetTrigger("Flash");
    }

}
