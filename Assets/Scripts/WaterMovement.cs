using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public TerrainLayer water;

    private float waterSpeed = 0.02f;
    private bool direction = true;

    private void FixedUpdate()
    {
        if (water.tileOffset.x >= 0.4)
            direction = false;
        if (water.tileOffset.x <= -0.4)
            direction = true;

        if (direction)
            water.tileOffset = new Vector2(water.tileOffset.x + waterSpeed, water.tileOffset.y + waterSpeed);
        else
            water.tileOffset = new Vector2(water.tileOffset.x - waterSpeed, water.tileOffset.y - waterSpeed);
    }
}