using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform axis;
    [SerializeField] private Floor floorPrefab;

    [Header("settings")]
    [SerializeField] private int defaultFloorAmount;
    [SerializeField] private float floorHeight;

    [SerializeField] private int amountEmptySegment;
    [SerializeField] private int maxTrapSegment;
    [SerializeField] private int minTrapSegment;

    private float floorAmount = 0;
    public float FloorAmount => floorAmount;

    private float lastFloor = 0;
    public float LastFloor => lastFloor;

    public float FloorHeight => floorHeight;

    public void Generate( int level)
    {
        DestroyChilde();

        floorAmount = defaultFloorAmount + level;

        axis.transform.localScale = new Vector3(1, floorAmount * floorHeight + floorHeight, 1);


        for (int i = 0; i < floorAmount; i++)
        {
            Floor floor = Instantiate(floorPrefab, transform);
            floor.transform.Translate(0, i * floorHeight, 0);
            floor.name = "Floor" + i;

            if(i == 0)
            {
                floor.SetFinishSegment();
            }

            if(i > 0 && i < floorAmount - 1)
            {
                floor.AddEmptySegment(amountEmptySegment);
                floor.SetRandomTrapSegment(Random.Range(minTrapSegment, maxTrapSegment + 1));
                floor.SetRandomRotation();
            }

            if(i == floorAmount - 1)
            {
               floor.AddEmptySegment(2);
               lastFloor = floor.transform.position.y;
            }
        }
    }

    private void DestroyChilde()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i) == axis) continue;

            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void Destroy(float index)
    {
        Destroy(transform.GetChild((int)index).gameObject);
    }
}
