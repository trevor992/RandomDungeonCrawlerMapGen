using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    //Rooms with two or more exits for when entry has only one exit
    public GameObject[] bottomRooms_2;
    public GameObject[] topRooms_2;
    public GameObject[] leftRooms_2;
    public GameObject[] rightRooms_2;
    //entry rooms followed by the number of exits i.e. entryRooms_1 is the entry rooms with 1 exit
    public GameObject[] entryRooms_1;
    public GameObject[] entryRooms_2;
    public GameObject[] entryRooms_3;
    public GameObject entryRoom_4; // obviously only one room has 4 exits no need for an array...

    public List<GameObject> rooms;

    private bool spawnedBoss;
    public GameObject boss;
    
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("RoomSpawnPoint").Length == 0 && spawnedBoss == false)
        {
            for(int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count-1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }
    }
}
