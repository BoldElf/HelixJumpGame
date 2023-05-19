using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelProgress : BallEvents
{
    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private LevelGenerator levelGenerator;


    [SerializeField] private Text currentLevel;
    [SerializeField] private Text nextLevel;
    [SerializeField] private Image progressBar;

    private float fillAmountStep;

    private void Start()
    {
        currentLevel.text = levelProgress.CurrentLevel.ToString();
        nextLevel.text = (levelProgress.CurrentLevel + 1).ToString();
        progressBar.fillAmount = 0;

        fillAmountStep = 1 / (levelGenerator.FloorAmount-1); // !
    }

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if(type == SegmentType.Empty || type == SegmentType.Finish)
        {
            progressBar.fillAmount += fillAmountStep;
        }
    }

}
