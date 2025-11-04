using UnityEngine;

public class SDoor : MonoBehaviour
{
    [SerializeField] private Transform mRoomSpawnLocation;
    [SerializeField] private GameObject[] mDoors;
    [SerializeField] private GameObject mThisRoomObj;
    public SRoom mThisRoom = null;

    [SerializeField] private GameObject[] mRooms;
    void Start()
    {
        mThisRoom = mThisRoomObj.GetComponent<SRoom>();

        //mThisRoomTrans = mThisRoomObj;

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GenerateRoom();
            mThisRoom.ShutDoors();
            Destroy(mThisRoomObj);
        }
    }
    void GenerateRoom()
    {

        int randomIndex = Random.Range(0, mRooms.Length);
        GameObject mRandomRoom = mRooms[randomIndex];

        GameObject mRoomSpawn = Instantiate(mRandomRoom, mRoomSpawnLocation.transform.position, mRoomSpawnLocation.transform.rotation);
    }
}
