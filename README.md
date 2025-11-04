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

#### SRoom
* Reads from an array to see it's own ```SDoor``` class
* This class opens the doors
#### SDoor
* When The player collides with an open door the camera instantly moves
* The previous room is destroyed and a new one is created.
* An array and a random range is used to simulate randomness in room generation
 ```C#
  int randomIndex = Random.Range(0, mRooms.Length);
        GameObject mRandomRoom = mRooms[randomIndex];
  ```
#### SPlayer
* Holds player stats only unique to them
#### SEnemy
* Holds enemy stats only unique to them
* Allows enemies to shoot on a timer
|#### SPlayer | #### SEnemy|
|-------|--------|
|Holds player stats|Holds enemy stats|
