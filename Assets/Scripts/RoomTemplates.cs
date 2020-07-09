using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    
    public GameObject[] BottomRooms { get;  private set;}
    public GameObject[] TopRooms { get; private set; }
    public GameObject[] LeftRooms { get; private set; }
    public GameObject[] RightRooms { get; private set; }
    
    //Long Rooms with one ExIT/Entrance
    public GameObject[] LongRooms { get; private set; }
    //Rooms with two or more exits for when entry has only one exit
    public GameObject[] BottomRooms_2 { get; private set; }
    public GameObject[] TopRooms_2 { get; private set; }
    public GameObject[] LeftRooms_2 { get; private set; }
    public GameObject[] RightRooms_2 { get; private set; }
    //entry rooms followed by the number of exits i.e. entryRooms_1 is the entry rooms with 1 exit
    public GameObject[] EntryRooms_1 { get; private set; }
    public GameObject[] EntryRooms_2 { get; private set; }
    public GameObject[] EntryRooms_3 { get; private set; }
 
    public GameObject EntryRoom_4 { get; private set; } // obviously only one room has 4 exits no need for an array...

    public List<GameObject> rooms;

    private bool spawnedBoss;
    public GameObject boss;


    private void Awake()
    {
        List<GameObject> roomList = new List<GameObject>();
        List<GameObject> room_2List = new List<GameObject>();
        GameObject[][] tempJagged = new GameObject[2][];



        string[] roomPrefix = { "B", "BR","BL", "BLR", "TLR","TBLR", "TB","TBL", "T",
            "TBR", "TR", "TL", "L", "R", "LR" };


        tempJagged = AttacheGameObjects(roomList,room_2List ,roomPrefix, "B");
        BottomRooms = tempJagged[0];
        BottomRooms_2 = tempJagged[1];

        tempJagged = AttacheGameObjects(roomList, room_2List, roomPrefix, "T");
        TopRooms = tempJagged[0];
        TopRooms_2 = tempJagged[1];

        tempJagged = AttacheGameObjects(roomList, room_2List, roomPrefix, "L");
        LeftRooms = tempJagged[0];
        LeftRooms_2 = tempJagged[1];

        tempJagged = AttacheGameObjects(roomList, room_2List, roomPrefix, "R");
        RightRooms = tempJagged[0];
        RightRooms_2 = tempJagged[1];

        EntryRooms_1 = GameObject.FindGameObjectsWithTag("Entry1");
        EntryRooms_2 = GameObject.FindGameObjectsWithTag("Entry2");
        EntryRooms_3 = GameObject.FindGameObjectsWithTag("Entry3");
        EntryRoom_4 = GameObject.FindGameObjectWithTag("Entry4");



    }

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

    private GameObject[][] AttacheGameObjects(List<GameObject> tempList, List<GameObject> tempList_2,string[] roomPrefixes, string prefixToFind)
    {
        GameObject[][] result = new GameObject[2][];

        for (int i = 0; i < roomPrefixes.Length; i++)
        {
            if (roomPrefixes[i].IndexOf(prefixToFind) > -1)
            {
                tempList.Add(GameObject.FindGameObjectWithTag(roomPrefixes[i]));

            }
            if (roomPrefixes[i].Length > 1)
            {
                tempList_2.Add(GameObject.FindGameObjectWithTag(roomPrefixes[i]));
            }
        }
        
        result[0] = new GameObject[tempList.Count];
        result[1] = new GameObject[tempList_2.Count];
        result[0] = tempList.ToArray();
        result[1] = tempList_2.ToArray();
        return result;
    }
}
