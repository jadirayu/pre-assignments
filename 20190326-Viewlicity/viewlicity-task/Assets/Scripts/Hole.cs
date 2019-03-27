using UnityEngine;

public class Hole : MonoBehaviour
{
    public float[] Position { get; private set; }
    public bool IsDeletable { get; private set; }

    public Hole(bool isDeletable, int nr = -1) {
        this.IsDeletable = isDeletable;

        if (isDeletable) {
            this.Position = GetRandomPosition(MIN_VALUE_WIDTH, MAX_VALUE_WIDTH, MIN_VALUE_HEIGHT, MAX_VALUE_HEIGHT);
        }
        else {
            if (nr >= 0) {
                this.Position = new float[] { INITIAL_HOLE_POSITIONS[nr, 0], INITIAL_HOLE_POSITIONS[nr, 1] };
            }
        }
    }

    private float[] GetRandomPosition(float min_x, float max_x, float min_y, float max_y) {
        float x = Random.Range(min_x, max_x);
        float y = Random.Range(min_y, max_y);
        float[] position = new float[] { x, y };
        return position;
    }

    private static float MAX_VALUE_WIDTH = Screen.width / 2;
    private static float MIN_VALUE_WIDTH = -1 * MAX_VALUE_WIDTH;
    private static float MAX_VALUE_HEIGHT = Screen.height / 2;
    private static float MIN_VALUE_HEIGHT = -1 * MAX_VALUE_HEIGHT;

    private static float[,] INITIAL_HOLE_POSITIONS = new float[3, 2] { { 1, 1 }, { 0.5f, 0.5f }, { 0.3f, 0.3f } };


}
