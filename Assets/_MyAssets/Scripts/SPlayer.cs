using UnityEngine;

public class SPlayer : MonoBehaviour
{
    private SStats mPlayerStats = null;

    private SChest mCurrentChest;

    public bool ChestInRange = false;



    void Start()
    {
        mPlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<SStats>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputs();
    }
    private void PlayerInputs()
    {
        if (Input.GetKey(KeyCode.J))
        {
            Debug.Log("Shoot");
            mPlayerStats.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ChestInRange == true)
            {
                mCurrentChest.GiveLoot();
            }
        }
    }
    public void SetCurrentChest(SChest chest)
    {
        //set script when on trigger enter
        mCurrentChest = chest;
    }

}
