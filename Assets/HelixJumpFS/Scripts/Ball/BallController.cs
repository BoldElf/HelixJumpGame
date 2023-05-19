using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallMovment))]
public class BallController : OneColliderTrigger
{
    private BallMovment movment;

    BallMovment Movment => movment;

   [HideInInspector]public UnityEvent<SegmentType> CollisionSegment;

    private void Start()
    {
        movment = GetComponent<BallMovment>();
    }

    protected override void OnOneTriggerEnter(Collider other)
    {
        Segment segment = other.GetComponent<Segment>();

        if(segment != null)
        {
            if(segment.Type == SegmentType.Empty)
            {
                movment.Fall(other.transform.position.y);
            }

            if (segment.Type == SegmentType.Default)
            {
                movment.Jump();
            }
            
            if (segment.Type == SegmentType.Finish || segment.Type == SegmentType.Trap )
            {
                movment.Stop();
            }

            CollisionSegment.Invoke(segment.Type);
        }
    }
}
