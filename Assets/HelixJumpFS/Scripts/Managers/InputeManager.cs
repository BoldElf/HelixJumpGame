using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputeManager : BallEvents
{
    [SerializeField] MouseRotator InputRotator;

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if(type == SegmentType.Finish || type == SegmentType.Trap )
        {
            InputRotator.enabled = false;
        }
    }
}

