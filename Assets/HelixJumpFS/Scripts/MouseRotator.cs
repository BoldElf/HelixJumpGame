using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotator : MonoBehaviour
{
    [SerializeField] private string mouseInputeAxis;
    [SerializeField] private int sensitive;

    private void Update()
    {
        if(Input.GetMouseButton(0) == true)
        {
            transform.Rotate(0, Input.GetAxis(mouseInputeAxis) * -sensitive, 0);
        }
    }


}
