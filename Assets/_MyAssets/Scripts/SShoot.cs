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


    SStats targetStats = other.GetComponentInParent<SStats>();
    if (targetStats == null) return;
    if (targetStats == mOwner) return;

    if (DestroyOnWall && (other.CompareTag("Wall") || other.transform.root.CompareTag("Wall")))
    {
        Debug.Log("Wall hit!");
        Explode();
        return;
    }

    if (other.CompareTag("Player"))
    {
        Debug.Log($"Bullet hit player: {other.name}");
        bool died = targetStats.TakeDamage(mTotalAttack, 1.0f, targetStats.mTotalDefense);
        if (died) Debug.Log($"{other.name} defeated!");
        Explode();
        return;
    }

    if (DestroyOnEnemy && other.CompareTag("Enemy"))
    {
        Debug.Log($"Bullet hit enemy: {other.name}");
        bool died = targetStats.TakeDamage(mTotalAttack, 1.0f, targetStats.mTotalDefense);
        if (died) Destroy(targetStats.gameObject);
        Explode();
        return;
    }
}
}
