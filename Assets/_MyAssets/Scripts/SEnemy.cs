using UnityEngine;

public class SEnemy : MonoBehaviour
{
    [SerializeField] private float mShootDelay;
    private float mCountdown;
    private bool mHasShot = false;
    GameObject mPlayer;
    [SerializeField] private GameObject mThisRoomObj;

    private SStats mSelfStats = null;
    private SRoom mThisRoom = null;

    void Start()
    {
        mCountdown = mShootDelay;
        mSelfStats = this.gameObject.GetComponent<SStats>();
        mThisRoom = mThisRoomObj.GetComponent<SRoom>();
    }
    void Update()
    {
        mCountdown -= Time.deltaTime;
        if (mCountdown <= 0.0f && mHasShot == false)
        {
            mHasShot = true;
            EnemyShoot();
        }
    }
    void EnemyShoot()
    {
        mSelfStats.Shoot();
        mCountdown = mShootDelay;
        mHasShot = false;
    }
}
