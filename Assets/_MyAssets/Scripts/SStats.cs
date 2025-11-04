using UnityEngine;

public class SStats : MonoBehaviour
{

    public int mMaxHP;
    public int mCurrentHP;
    public int mBaseDefense;
    public int mTotalDefense;
    public float mFireRes = 1f;
    public float mIceRes = 1f;
    public float mLitRes = 1f;
    public float mWindRes = 1f;

    public int mAddAttack;
    

    private float mWeaponFireRate;
    public float mFireRateAdd;
    public float mTotalFireRate;
    private bool mReloading = false;
    private bool mCanFire = true;
    [SerializeField] private float mExplosionDelay = 1.0f;
    private float mCountdown = 0.0f; 
    public int mCritChance;
    public int BulletSpeed;

    public int mWeaponType;
    public GameObject mWeapon;
    private SMasterBulletHolder mBulletHolder = null;
    private SShoot mShoot = null;

    public Transform mWeaponSpawn;


    public int mItem;


    void Start()
    {
        mBulletHolder = GameObject.FindGameObjectWithTag("GameController").GetComponent<SMasterBulletHolder>();
        GetWeaponStats();
    }
    public void GetWeaponStats()
    {
        if (mWeaponType == 0)
        {
            mWeapon = mBulletHolder.mArrow;
            mWeaponFireRate = 0.75f;
        }
        if (mWeaponType == 1)
        {
            mWeapon = mBulletHolder.mFireball;
            mWeaponFireRate = 2f;
        }
        if (mWeaponType == 3)
        {
            mWeapon = mBulletHolder.mBullet;
            mWeaponFireRate = 0.25f;
        }
        UpdateWeapon();
    }
    void Update()
    {
        if (mReloading == true)
        {
            mCountdown -= Time.deltaTime;
        if (mCountdown <= 0.0f && mCanFire == false)
        {
            mReloading = false;
            mCanFire = true;
        }
        }
    }
    public void UpdateWeapon()
    {
        mTotalFireRate = mWeaponFireRate - (mFireRateAdd * mWeaponFireRate)/100;
        mCountdown = mTotalFireRate;
    }
    public void Reload()
    {
        mCountdown = mTotalFireRate;
        mReloading = true;
    }
    public void Shoot()
    {
        if (mCanFire == true)
        {
            GameObject bullet = Instantiate(mWeapon, mWeaponSpawn.position, mWeaponSpawn.rotation);
            SShoot shootScript = bullet.GetComponent<SShoot>();
            if (shootScript != null)
            {
                shootScript.mStats = this;
                shootScript.mOwner = this;
                }
            shootScript.mStats = this;
            mCanFire = false;
            Reload();
        }

    }
    public bool TakeDamage(int dmg, float weak, int def)
    {
        int Damage = dmg;
        int finalDamage = Mathf.Max(0, (int)(weak * Damage - def));
        if (finalDamage > 0)
        {
            mCurrentHP -= (int)finalDamage;
            //SetHP();
        }
        if (mCurrentHP <= 0)
        { return true; }
        else
        { return false; }
    }
}
