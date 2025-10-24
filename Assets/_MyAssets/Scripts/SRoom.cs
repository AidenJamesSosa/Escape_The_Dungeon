using UnityEngine;


public class SRoom : MonoBehaviour
{
    [SerializeField] private GameObject[] mDoors;
    [SerializeField] private GameObject[] mDoorsShut;
    [SerializeField] private GameObject mDoorEntered;

    public FollowPlayer mFollowPlayer;

    void Start()
    {
        ShutDoors();
        mFollowPlayer = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowPlayer>();
        mFollowPlayer.mRoomPosition = transform;
        mFollowPlayer.MoveCamera();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            RoomClear();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ShutDoors();
        }
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
