using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField][Range(0.01f,1f)]
    private float sizeX = 1f;

    [SerializeField]
    [Range(0.01f, 1f)]
    private float sizeY = 1f;

    [SerializeField]
    [Range(0.01f, 1f)]
    private float sizeZ = 1f;

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        //Check position
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / sizeX);
        int yCount = Mathf.RoundToInt(position.y / sizeY);
        int zCount = Mathf.RoundToInt(position.z / sizeZ);

        Vector3 result = new Vector3(
            (float)xCount * sizeX,
            (float)yCount * sizeY,
            (float)zCount * sizeZ);

        result += transform.position;

        return result;
    }

    //Gizmo interface Unity
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x < 5; x += sizeX)
        {
            for (float z = 0; z < 5; z += sizeZ)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, 0.1f);
            }

        }
    }
}