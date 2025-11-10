using UnityEngine;
using Unity.Behavior;
public class SEnemy : MonoBehaviour
{
        [SerializeField] private float mShootDelay;
    private float mCountdown;
    private bool mHasShot = false;
    GameObject mPlayer;
    public GameObject mThisRoomObj;

    private SStats mSelfStats = null;
    private SRoom mThisRoom = null;
    private BehaviorGraphAgent agent; // 👈 Change here

    void Start()
    {
        var col = GetComponent<Collider>();
        mCountdown = mShootDelay;
        mSelfStats = GetComponent<SStats>();
        mThisRoom = mThisRoomObj.GetComponent<SRoom>();

        agent = GetComponent<BehaviorGraphAgent>();
        if (agent != null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
               agent.SetVariableValue<GameObject>("Player", player);
            }
        }
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
