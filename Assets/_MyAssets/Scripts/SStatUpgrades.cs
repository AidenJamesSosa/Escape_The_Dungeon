using UnityEngine;
using StarterAssets;
using TMPro;

public class SStatUpgrades : MonoBehaviour
{
    public int Upgrade = 0;
    public int mAffix = 1;
    
    [SerializeField] private TextMeshProUGUI mUpgradeText;

    private SStats mPlayerStats = null;
    private ThirdPersonController mPlayerController = null;
    private SPlayer mPlayer;
    void Start()
    {
        mPlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<SStats>();
        mPlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<SPlayer>();
    }
    public void UpgradeStats()
    {
        string upgradeMessage = "";

        switch (Upgrade)
        {
            case 0:// hp upgrade
                mPlayerStats.mMaxHP += mAffix;
                upgradeMessage = $"+{mAffix} Max HP";
                break;
            case 1:// defense upgrade
                mPlayerStats.mBaseDefense += mAffix;
                upgradeMessage = $"+{mAffix} Defense";
                break;
            case 2:// Attack upgrade
                mPlayerStats.mAddAttack += mAffix;
                upgradeMessage = $"+{mAffix} Attack";
                break;
            case 3:// firerate upgrade
                mPlayerStats.mFireRateAdd += mAffix;
                mPlayerStats.UpdateWeapon();
                upgradeMessage = $"+{mAffix} Fire Rate";
                break;
            case 4:// critchance upgrade
                mPlayerStats.mCritChance += mAffix;
                upgradeMessage = $"+{mAffix}% Crit Chance";
                break;
            case 5: // MovementSpeed upgrade
                mPlayerController.MoveSpeed += mAffix;
                upgradeMessage = $"+{mAffix} Move Speed";
                break;
            case 10: // mFireRes upgrade
                mPlayerStats.mFireRes /= 2;
                upgradeMessage = $"Fire Resistance Improved!";
                break;
            case 11:// IceRes upgrade
                mPlayerStats.mIceRes /= 2;
                upgradeMessage = $"Ice Resistance Improved!";
                break;
            case 12:// LitRes upgrade
                mPlayerStats.mLitRes /= 2;
                upgradeMessage = $"Lightning Resistance Improved!";
                break;
            case 13:  // WindRes upgrade
                mPlayerStats.mWindRes /= 2;
                upgradeMessage = $"Wind Resistance Improved!";
                break;
        }

        mPlayerStats.mCurrentHP = mPlayerStats.mMaxHP;
        mPlayer.SetHP();
        CheckMax();

        if (mUpgradeText != null)
        {
            mUpgradeText.text = upgradeMessage;
            mUpgradeText.gameObject.SetActive(true);
        }
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
