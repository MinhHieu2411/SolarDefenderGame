using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRotation : MonoBehaviour
{
    [SerializeField] Transform _target;
    // Start is called before the first frame update
    void LateUpdate()
    {
        transform.rotation = _target.rotation;
    }
}
