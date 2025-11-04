using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Unity.AI.Navigation;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] public Transform mCamera;
    [SerializeField] public Transform mRoomPosition;
    [SerializeField] Vector3 mOffset;
    [SerializeField] private NavMeshSurface navMeshSurface;

    public Transform mNewPosition;
    public void MoveCamera()
    {
        Vector3 mNewPosition = new Vector3(mRoomPosition.transform.position.x, mRoomPosition.transform.position.y + mOffset.y,
                mRoomPosition.transform.position.z + mOffset.z);

        mCamera.position = mNewPosition;

        StartCoroutine(RebuildNavMeshNextFrame());
    }
    private IEnumerator RebuildNavMeshNextFrame()
    {
        yield return null; // Wait one frame so transforms settle
        Physics.SyncTransforms(); // Ensure physics knows everything moved

        navMeshSurface.BuildNavMesh();

        foreach (var agent in FindObjectsOfType<NavMeshAgent>())
        {
            agent.Warp(agent.transform.position);
        }
    }
}