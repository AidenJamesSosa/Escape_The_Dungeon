using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject mThisRoomObj;
    private SRoom mThisRoom = null;
    //[SerializeField] bool mDoorlever;
    void Start()
    {
        mThisRoom = mThisRoomObj.GetComponent<SRoom>();
    }
     public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("Open door");
            Open();
        }
    }
    void Open()
    {
        //if (mDoorlever == true)
        //{
            mThisRoom.RoomClear();
        //}
    }
}
