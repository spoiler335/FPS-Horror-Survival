using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LhRotate : MonoBehaviour
{
    [SerializeField] GameObject lhObject;
    [SerializeField] float Speed = 0.1f;
    
    void Update()
    {
        lhObject.transform.Rotate(0f,Speed,0f,Space.World);
    }
}
