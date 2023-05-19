using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwap : MonoBehaviour
{
    [SerializeField] private Material axis;
    [SerializeField] private Material ball;
    [SerializeField] private Material floor;
    [SerializeField] private Material finish;
    [SerializeField] private Material trap;

    [SerializeField] private new Camera camera;


    Color[] colorAxisAndCamera = new Color[5] { Color.white, Color.magenta, Color.cyan, Color.gray, Color.green};
    Color[] colorBall = new Color[5] { Color.white, Color.red, Color.cyan, Color.gray, Color.green};
    Color[] colorFloor = new Color[5] { Color.white, Color.black, Color.cyan, Color.gray, Color.green};
    Color[] colorFinish = new Color[5] { Color.white, Color.black, Color.cyan, Color.gray, Color.green};
    Color[] ColorTrap = new Color[3] { Color.red, Color.magenta, Color.yellow};

    
    

    private void Start()
    {
        int index = Random.Range(0, 5);
        axis.color = colorAxisAndCamera[index];

        index = Random.Range(0, 5);
        ball.color = colorBall[index];

        index = Random.Range(0, 5);
        floor.color = colorFloor[index];

        index = Random.Range(0, 5);
        finish.color = colorFinish[index];

        index = Random.Range(0, 3);
        trap.color = ColorTrap[index];

        index = Random.Range(0, 5);
        camera.backgroundColor = colorAxisAndCamera[index];   
    }
    
}
