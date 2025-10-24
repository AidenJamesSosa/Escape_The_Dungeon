using UnityEngine;
using StarterAssets;

public class SStatUpgrades : MonoBehaviour
{
    public int Upgrade = 0;
    public int mAffix = 1;
    private SStats mPlayerStats = null;
    private ThirdPersonController mPlayerController = null;
    void Start()
    {
        mPlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<SStats>();
        mPlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
    }

    public void UpgradeStats()
    {
        if (Upgrade == 0) // hp upgrade
        {
            mPlayerStats.mMaxHP = mPlayerStats.mMaxHP + mAffix;
            Debug.Log("HP");
        }
        if (Upgrade == 1) // defense upgrade (rare)
        {
            mPlayerStats.mBaseDefense = mPlayerStats.mBaseDefense + mAffix;
            Debug.Log("Defense");
        }
        if (Upgrade == 2) // Attack upgrade
        {
            mPlayerStats.mAddAttack = mPlayerStats.mAddAttack + mAffix;
            Debug.Log("Attack");
        }
        if (Upgrade == 3) // firerate upgrade
        {
            mPlayerStats.mFireRateAdd = mPlayerStats.mFireRateAdd + (mAffix / 1);
            mPlayerStats.UpdateWeapon();
            Debug.Log("firerate");
        }
        if (Upgrade == 4) // critchance upgrade
        {
            mPlayerStats.mCritChance = mPlayerStats.mCritChance + mAffix;
            Debug.Log("Crit");
        }
        if (Upgrade == 5) // MovementSpeed upgrade
        {
            mPlayerController.MoveSpeed = mPlayerController.MoveSpeed + mAffix;
            Debug.Log("Speed");
        }
        if (Upgrade == 10) // mFireRes upgrade
        {
            mPlayerStats.mFireRes = mPlayerStats.mFireRes / 2;
            Debug.Log("Fire");
        }
        if (Upgrade == 11) // IceRes upgrade
        {
            mPlayerStats.mIceRes = mPlayerStats.mIceRes / 2;
            Debug.Log("Ice");
        }
        if (Upgrade == 12) // LitRes upgrade
        {
            mPlayerStats.mLitRes = mPlayerStats.mLitRes / 2;
            Debug.Log("Lit");
        }
        if (Upgrade == 13) // WindRes upgrade
        {
            mPlayerStats.mWindRes = mPlayerStats.mWindRes / 2;
            Debug.Log("WindRes");
        }
        CheckMax();
    }
    public void RemoveUpgrade()
    {
        if (Upgrade == 0) // hp upgrade
        {
            mPlayerStats.mMaxHP = mPlayerStats.mMaxHP - mAffix;
            Debug.Log("HP");
        }
        if (Upgrade == 1) // defense upgrade
        {
            mPlayerStats.mBaseDefense = mPlayerStats.mBaseDefense - mAffix;
            Debug.Log("Defense");
        }
        if (Upgrade == 2) // Attack upgrade
        {
            mPlayerStats.mAddAttack = mPlayerStats.mAddAttack - mAffix;
            Debug.Log("Attack");
        }
        if (Upgrade == 3) // firerate upgrade
        {
            mPlayerStats.mFireRateAdd = mPlayerStats.mFireRateAdd - mAffix;
            mPlayerStats.UpdateWeapon();
            Debug.Log("firerate");
        }
        if (Upgrade == 4) // critchance upgrade
        {
            mPlayerStats.mCritChance = mPlayerStats.mCritChance - mAffix;
            Debug.Log("Crit");
        }
        if (Upgrade == 5) // MovementSpeed upgrade
        {
            mPlayerController.MoveSpeed = mPlayerController.MoveSpeed - mAffix;
            Debug.Log("Speed");
        }
        if (Upgrade == 10) // mFireRes upgrade
        {
            mPlayerStats.mFireRes = mPlayerStats.mFireRes * 2;
            Debug.Log("Fire");
        }
        if (Upgrade == 11) // IceRes upgrade
        {
            mPlayerStats.mIceRes = mPlayerStats.mIceRes * 2;
            Debug.Log("Ice");
        }
        if (Upgrade == 12) // LitRes upgrade
        {
            mPlayerStats.mLitRes = mPlayerStats.mLitRes * 2;
            Debug.Log("Lit");
        }
        if (Upgrade == 13) // WindRes upgrade
        {
            mPlayerStats.mWindRes = mPlayerStats.mWindRes * 2;
            Debug.Log("WindRes");
        }
    }
    public void CheckMax()
    {
        if (mPlayerController.MoveSpeed > 25)
        {
            mPlayerController.MoveSpeed = 25;
        }
        
    }
}
