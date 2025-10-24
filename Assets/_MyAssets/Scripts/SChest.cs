using UnityEngine;

public class SChest : MonoBehaviour
{

    [SerializeField] private GameObject mChestTop;
    [SerializeField] private int[] mLoot;
    int mRandomLoot;

    [SerializeField] private bool mWeaponChest = true;
    [SerializeField] private int mSetAffix = 1; //change stat by 1



    //give back
    private bool mOpened;
    private int mOldWeapon;
    private int mTransferWeapon;


    private bool isPlayerInRange = false;
    private SStats mPlayerStats;
    private SPlayer mPlayer;
    private SStatUpgrades mStatUpgrades = null;
    void Start()
    {
        mPlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<SStats>();
        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<SPlayer>();
        mStatUpgrades = GameObject.FindGameObjectWithTag("GameController").GetComponent<SStatUpgrades>();
        RandomLoot();
    }

    void RandomLoot()
    {
        int randomIndex = Random.Range(0, mLoot.Length);
        mRandomLoot = mLoot[randomIndex];
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mPlayer.ChestInRange = true;
            other.GetComponent<SPlayer>()?.SetCurrentChest(this);
        }
    }
    public void GiveLoot()
    {
        if (mWeaponChest == true)
        {
            if (mOpened == false)
            {
                mOldWeapon = mPlayerStats.mWeaponType;
                mPlayerStats.mWeaponType = mRandomLoot;
                mPlayerStats.GetWeaponStats();
                OpenedChest();
            }
            else
            {
                mTransferWeapon = mPlayerStats.mWeaponType;
                mPlayerStats.mWeaponType = mOldWeapon;
                mOldWeapon = mTransferWeapon;
                mPlayerStats.GetWeaponStats();
            }

        }
        if (mWeaponChest == false)
        {
            if (mOpened == false)
            {
                mStatUpgrades.mAffix = mSetAffix;
                mStatUpgrades.Upgrade = mRandomLoot;
                mStatUpgrades.UpgradeStats();
                OpenedChest();
            }
            else
            {
                mStatUpgrades.mAffix = mSetAffix;
                mStatUpgrades.Upgrade = mRandomLoot;
                mStatUpgrades.RemoveUpgrade();
                ClosedChest();
            }

        }

    }
    public void OpenedChest()
    {
        if (mChestTop != null)
        {
            mChestTop.SetActive(false);
        }
        mOpened = true;
    }
    public void ClosedChest()
    {
        if (mChestTop != null)
        {
            mChestTop.SetActive(true);
        }
        mOpened = false;
    }
}
