using UnityEngine;

public class SShoot : MonoBehaviour
{

    private Rigidbody mRBody;

    public int mBaseAttack; //Damage
    public int mTotalAttack; //Damage + Char Damage Modifier


    [SerializeField] private float mMoveSpeed; //5
    [SerializeField] private Transform mBulletSpawn;
    [SerializeField] private float mExplosionDelay;
    private float mCountdown;
    private bool mHasExploded = false;
    [SerializeField] private bool DestroyOnPlayer; //for enemy bullets
    [SerializeField] private bool DestroyOnEnemy; //for player bullets
    [SerializeField] private bool DestroyOnWall; //most will not pierce walls
    public SStats mStats = null;




    void Start()
    {
        mRBody = GetComponent<Rigidbody>();
        mRBody.AddForce(transform.forward * mMoveSpeed, ForceMode.Impulse);
        mCountdown = mExplosionDelay;
        if (mStats != null)
        {
            AddStats(); // now using passed-in shooter stats
        }
    }
    void Update()
    {
        mCountdown -= Time.deltaTime;
        if (mCountdown <= 0.0f && mHasExploded == false)
        {
            mHasExploded = true;
            Explode();
        }
    }

    private void AddStats()
    {
        mTotalAttack = mBaseAttack + mStats.mAddAttack;
    }

    private void Explode()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
    
}
