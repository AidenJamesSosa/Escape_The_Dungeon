# Escape-the-Dungeon
School Personal Project. Based on Binding of Issac
* Engine Configuration

|Engine | Version|
|-------|--------|
|Unity|6000.0.34f1|
----
## Structure

The project is composed of the following major classes:

#### SStats
* Holds enemy and player stats
* Holds the abilty to shoot
* Uses the ```SMasterBulletHolder``` class to read what projectile to shoot
    - This class holds all of the bullet game objects
* Uses the ```SShoot``` class to determine projectile speed.
    - That class determines the projectile velocity and has an on trigger enter for hitting enemies

|#### SPlayer | #### SEnemy|
|---|---|
|Holds player stats|Holds enemy stats|
|---|---|
|Allows shoot on command|shoots on timers|
|---|---|
|Allows chest interactions|Chases the player|
---
#### SShoot
* Defines bullets stats
      - Damage, speed, and how long the bullet could be shot
* Destroys itself when it hits a wall.
* When stats for ```SStats``` are updated the code updates
  ```
  private void AddStats()
    {
        mTotalAttack = mBaseAttack + mStats.mAddAttack;
    }
```
* Reads from ```SMasterBulletHolder``` to grab the respective game object


#### SRoom
* Reads from an array to see it's own ```SDoor``` class
* This class opens the doors
* When instantiated the camera controlled by "MCameraMove" is moved overhead this room within ```MCameraMove```'s code
```
 public void MoveCamera()
    {
        Vector3 mNewPosition = new Vector3(mRoomPosition.transform.position.x, mRoomPosition.transform.position.y + mOffset.y,
                mRoomPosition.transform.position.z + mOffset.z);
     mCamera.position = mNewPosition;

        StartCoroutine(RebuildNavMeshNextFrame());
    }
```
#### SDoor
* When The player collides with an open door the camera instantly moves
* The previous room is destroyed and a new one is created.
* An array and a random range is used to simulate randomness in room generation
 ```C#
  int randomIndex = Random.Range(0, mRooms.Length);
        GameObject mRandomRoom = mRooms[randomIndex];
  ```


