using System;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public float[] Position { get; private set; }   // [X, Y] of the hole
    public bool IsDeletable { get; private set; }   // the hole is deletable

    public Hole(float viewWidth, float viewHeight, bool isDeletable, int nr = -1) {
        this.IsDeletable = isDeletable;

        if (!isDeletable && nr >= 0)
        {
            this.Position = new float[] { Screen.width * INIT_HOLES_POSITIONS[nr, 0], Screen.height * INIT_HOLES_POSITIONS[nr, 1] };
        }
        else if (isDeletable)
        {
            this.Position = GetRandomPosition(viewWidth * LIGHT_GREEN_AREA_SIZE[0], viewWidth * LIGHT_GREEN_AREA_SIZE[1],
                viewHeight * LIGHT_GREEN_AREA_SIZE[2], viewHeight * LIGHT_GREEN_AREA_SIZE[3]);
        }
        else {
            Debug.Log("Illegal params feeded to the Hole constructor");
            this.Position = new float[] { Single.NaN, Single.NaN };
        }
    }

    private float[] GetRandomPosition(float min_x, float max_x, float min_y, float max_y) {
        float x = UnityEngine.Random.Range(min_x, max_x);
        float y = UnityEngine.Random.Range(min_y, max_y);
        float[] position = new float[] { x, y };
        return position;
    }

    private static float[] LIGHT_GREEN_AREA_SIZE = new float[] { 0.13f, 0.87f, 0.23f, 0.77f };
    private static float[,] INIT_HOLES_POSITIONS = new float[3, 2] { { 0.2f, 0.5f }, { 0.8f, 0.2f }, { 0.8f, 0.8f } };
}
