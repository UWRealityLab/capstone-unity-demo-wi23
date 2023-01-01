using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int points = 1;
    public bool reoccurring = true;

    public Transform spawnOrigin; // Provide an origin point for generating new positions if necessary
    public float boundsWidth;

    public ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        scoreManager.updateScore(points);
        if (reoccurring)
        {
            gameObject.transform.position = generateNewPosition(boundsWidth/2);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // New position calculated assuming a square, flat region to spawn in
    private Vector3 generateNewPosition(float boundsRange)
    {
        float newXPosition = spawnOrigin.position.x + Random.Range(-1 * boundsRange, boundsRange);
        float newZPosition = spawnOrigin.position.z + Random.Range(-1 * boundsRange, boundsRange);

        // In Unity's 3D coordinate system the Y-axis is the vertical axis so we want to leave it the same
        return new Vector3(newXPosition, transform.position.y, newZPosition);
    }
}
