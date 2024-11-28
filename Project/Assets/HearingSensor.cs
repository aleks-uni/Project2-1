using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents.Sensors;

public class HearingSensor : MonoBehaviour
{
    public float hearingRadius = 50f; // Radius within which the agent "hears"
    public LayerMask detectableLayers; // Layers to detect (e.g., ball, players, etc.)
    public int maxObjects = 5; // Maximum number of objects to track

    private List<Vector3> objectPositions = new List<Vector3>();

    public void CollectNearbyObjects()
    {
        objectPositions.Clear();

        // Find all colliders within the hearing radius
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, hearingRadius, detectableLayers);

        foreach (Collider obj in nearbyObjects)
        {
            if (objectPositions.Count >= maxObjects)
                break; // Limit the number of objects
            objectPositions.Add(obj.transform.position);
        }
    }

    public List<Vector3> GetObjectPositions()
    {
        return objectPositions;
    }

    void OnDrawGizmosSelected()
    {
        // Visualize the hearing radius in the editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, hearingRadius);
    }
}