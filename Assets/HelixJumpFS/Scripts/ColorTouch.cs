using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTouch : BallEvents
{
    [SerializeField] private Transform parentTransform;
    [SerializeField] private MeshRenderer visualMeshRender;
    [SerializeField] private Blot blotPrefab;


    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if(type != SegmentType.Empty)
        {
            Blot blot = Instantiate(blotPrefab, parentTransform);
            blot.Init(new Vector3(visualMeshRender.transform.position.x, transform.position.y, visualMeshRender.transform.position.z),
                visualMeshRender.material.color);
        }
    }

}
