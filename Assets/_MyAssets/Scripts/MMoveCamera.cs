using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] public Transform mCamera;
    [SerializeField] public Transform mRoomPosition;
    public Transform mNewPosition;
    [SerializeField] Vector3 mOffset;


    //public float mPlayerTransform;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveCamera()
    {
        Vector3 mNewPosition = new Vector3(mRoomPosition.transform.position.x, mRoomPosition.transform.position.y + mOffset.y,
                mRoomPosition.transform.position.z + mOffset.z);

        mCamera.position = mNewPosition;
    }
}