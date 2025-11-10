using UnityEngine;
using System;
using UnityEditor.Rendering.LookDev;
using Unity.XR.OpenVR;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SPlayer : MonoBehaviour
{
    public bool ChestInRange = false;

    private SStats mPlayerStats = null;
    private SChest mCurrentChest = null;
    private PlayerInputs mPlayerInputs;
    [SerializeField] private Slider mHealthSlider;
    public SSceneLoadColor mSceneLoader = null;

    void Start()
    {
        mPlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<SStats>();
        mPlayerInputs = new PlayerInputs();
        mPlayerInputs.Gameplay.Shoot.performed += PlayerShoot;
        mPlayerInputs.Gameplay.OpenChest.performed += OnOpenChest;

        mPlayerInputs.Gameplay.Enable();
        mHealthSlider.maxValue = mPlayerStats.mMaxHP;
        mHealthSlider.value = mPlayerStats.mCurrentHP;
        SetHP();
    }
    void Update()
    {
        PlayerInput();
    }
    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mSceneLoader.QuitGame();
        }
    }
    public void SetHP()
    {
        mPlayerStats.mCurrentHP = Mathf.Clamp(mPlayerStats.mCurrentHP, 0, mPlayerStats.mMaxHP);
        mHealthSlider.value = mPlayerStats.mCurrentHP;
    }
    public void PlayerShoot(InputAction.CallbackContext context)
    {
        mPlayerStats.Shoot();
    }
    private void OnOpenChest(InputAction.CallbackContext context)
    {
        if (ChestInRange && mCurrentChest != null)
        {
            mCurrentChest.GiveLoot();
        }
    }
    public void SetCurrentChest(SChest chest)
    {
        //set script when on trigger enter
        mCurrentChest = chest;
    }

}
