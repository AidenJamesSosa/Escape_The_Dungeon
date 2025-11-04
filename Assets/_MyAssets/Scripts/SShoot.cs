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
    public SStats mOwner;
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
    if (mHasExploded) return;

    Transform root = other.transform.root;
    SStats targetStats = root.GetComponent<SStats>();

    // 🔒 Ignore hitting the shooter themselves
    if (targetStats == mOwner)
    {
        //Debug.Log("Ignored self-hit");
        return;
    }

    // ✅ Hits wall
    if (DestroyOnWall && root.CompareTag("Wall"))
    {
        Debug.Log("Wall hit!");
        Explode();
        return;
    }

    // ✅ Hits player
    if (root.CompareTag("Player"))
    {
        Debug.Log($"Bullet hit player: {root.name}");
        if (targetStats != null)
        {
            bool died = targetStats.TakeDamage(mTotalAttack, 1.0f, targetStats.mTotalDefense);
            if (died) Debug.Log($"{root.name} defeated!");
        }
        Explode();
        return;
    }

    // ✅ Hits enemy
    if (root.CompareTag("Enemy"))
    {
        Debug.Log($"Bullet hit enemy: {root.name}");
        if (targetStats != null)
        {
            bool died = targetStats.TakeDamage(mTotalAttack, 1.0f, targetStats.mTotalDefense);
            if (died) Debug.Log($"{root.name} defeated!");
        }
        Explode();
        return;
    }
}
}
