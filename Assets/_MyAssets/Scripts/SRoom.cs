using UnityEngine;


public class SRoom : MonoBehaviour
{
    [SerializeField] private GameObject[] mDoors;
    [SerializeField] private GameObject[] mDoorsShut;
    [SerializeField] private GameObject mDoorEntered;

    [SerializeField] private bool StartUnlocked;
    [SerializeField] private bool mEnemyRoom;
    [SerializeField] private int mEnemyAmount;

    public FollowPlayer mFollowPlayer;

    void Start()
    {
        ShutDoors();
        if (StartUnlocked == true)
        {
            RoomClear();
        }
        mFollowPlayer = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowPlayer>();
        mFollowPlayer.mRoomPosition = transform;
        mFollowPlayer.MoveCamera();
    }
    public void RoomClear()
    {
        foreach (GameObject obj in mDoors)
        {
            if (obj != null && !obj.activeSelf)
            {
                obj.SetActive(true);
            }
        }
        foreach (GameObject obj in mDoorsShut)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
    public void ShutDoors()
    {
        foreach (GameObject obj in mDoors)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
        foreach (GameObject obj in mDoorsShut)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
