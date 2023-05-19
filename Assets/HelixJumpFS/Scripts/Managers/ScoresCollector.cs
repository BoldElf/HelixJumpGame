using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresCollector : BallEvents
{
    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private int scores;

    public int Scores => scores;
    private int cnt = 0;

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Empty)
        {
            if(cnt == 1 )
            {
                scores += 10;
            }

            scores += levelProgress.CurrentLevel;
            cnt++;
        }

        if(type != SegmentType.Empty)
        {
            cnt = 0;
        }

    }
}
