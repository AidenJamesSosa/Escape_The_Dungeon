using UnityEngine;
using System.Collections.Generic;



public class SRoom : MonoBehaviour
{
    [SerializeField] private GameObject[] mDoors;
    [SerializeField] private GameObject[] mDoorsShut;
    [SerializeField] private GameObject mDoorEntered;

    [SerializeField] private bool StartUnlocked;
    [SerializeField] private int mEnemyAmount;

    [SerializeField] private GameObject mEnemyPrefab;
    [SerializeField] private Transform[] mEnemySpawns;
    private bool mEnemiesSpawned = false;

    private List<GameObject> mSpawnedEnemies = new List<GameObject>();

    public FollowPlayer mFollowPlayer;

    void Start()
    {
        ShutDoors();
        if (StartUnlocked == true)
        {
            RoomClear();
        }
        mFollowPlayer = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowPlayer>();
        mFollowPlayer.mRoomPosition = transform;
        mFollowPlayer.MoveCamera();
        SpawnEnemies();
    }
    public void RoomClear()
    {
        foreach (GameObject obj in mDoors)
        {
            if (obj != null && !obj.activeSelf)
            {
                obj.SetActive(true);
            }
        }
        foreach (GameObject obj in mDoorsShut)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
    public void ShutDoors()
    {
        foreach (GameObject obj in mDoors)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
        foreach (GameObject obj in mDoorsShut)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
    public void SpawnEnemies()
    {
        if (mEnemyPrefab == null || mEnemySpawns == null) return;

        foreach (Transform spawn in mEnemySpawns)
        {
            if (spawn == null) continue;

            GameObject newEnemy = Instantiate(mEnemyPrefab, spawn.position, spawn.rotation);
            SEnemy enemyScript = newEnemy.GetComponent<SEnemy>();

            if (enemyScript != null)
            {
                enemyScript.mThisRoomObj = this.gameObject;
            }

            mSpawnedEnemies.Add(newEnemy);
            mEnemyAmount++;
        }
    }
    public void DestroyEnemies()
    {
        foreach (GameObject enemy in mSpawnedEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }

        mSpawnedEnemies.Clear();
        mEnemyAmount = 0;
        mEnemiesSpawned = false;
    }
}
