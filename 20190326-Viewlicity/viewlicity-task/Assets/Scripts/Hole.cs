using UnityEngine;

public class Hole : MonoBehaviour
{
    public float[] Position { get; private set; }   // [X, Y] of the hole
    public bool IsDeletable { get; private set; }   // the hole is deletable

    public Hole(float viewWidth, float viewHeight, bool isDeletable) {
        this.IsDeletable = isDeletable;

        if (isDeletable) {
            this.Position = GetRandomPosition(viewWidth * 0.13f, viewWidth * 0.87f, viewHeight * 0.23f, viewHeight * 0.77f);
        }
    }

    private float[] GetRandomPosition(float min_x, float max_x, float min_y, float max_y) {
        float x = Random.Range(min_x, max_x);
        float y = Random.Range(min_y, max_y);
        float[] position = new float[] { x, y };
        return position;
    }

    private static float MAX_VALUE_WIDTH = Screen.width;
    private static float MAX_VALUE_HEIGHT = Screen.height;
}
