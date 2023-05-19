using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorMove : BallEvents
{
    [SerializeField] LevelGenerator levelGenerator;
    [SerializeField] Floor floorPrefab;

    [HideInInspector] private float level1;
    private int cnt = 0;

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        level1 = levelGenerator.FloorAmount;

        if(type == SegmentType.Empty)
        {
            levelGenerator.Destroy(levelGenerator.FloorAmount - cnt);

            level1 -= cnt;
            cnt++;

            Floor floor = Instantiate(floorPrefab, transform);

            floor.transform.Translate(0, level1 * levelGenerator.FloorHeight - levelGenerator.FloorHeight + 1, 0);
        }
    }
    
   
}

