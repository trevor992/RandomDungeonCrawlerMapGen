using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;
using System.IO;

public class RoomTemplates : MonoBehaviour
{
    
    public GameObject[] BottomRooms { get;  private set;}
    public GameObject[] TopRooms { get; private set; }
    public GameObject[] LeftRooms { get; private set; }
    public GameObject[] RightRooms { get; private set; }
    public GameObject[] AllRooms { get; private set; }
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
    
    public GameObject EntryRoom_4 { get;private set; } // obviously only one room has 4 exits no need for an array...

    public List<GameObject> rooms;

    private bool spawnedBoss;
    public GameObject boss;

    /*
     * As I add more roooms, different sizes different shapes etc. it becomes
     * more and more apparent that I should  refactor this and build a Room
     * class to increase modularity and decrease redundancy. 
     */
    private void Awake()
    {
        // This will create problems on windows machines!
        string roomPath = "Prefabs/Room_Prefabs";
        string entryRoomsPath = "Prefabs/Entry_Prefabs";


        // need to be mindful when using LoadAll it could potentially
        // load large amount of assets into Main Memory for this small project
        // However for this project the approach works fine
        //Furthermore I have used 
        AllRooms = Resources.LoadAll(roomPath).Cast<GameObject>().ToArray();
        GameObject[] entryRooms = Resources.LoadAll(entryRoomsPath).Cast<GameObject>().ToArray();

        BottomRooms = FilterObjects(g => g.tag.IndexOf("B") > -1, AllRooms);

        TopRooms = FilterObjects(g => g.tag.IndexOf("T") > -1, AllRooms);

        LeftRooms = FilterObjects(g => g.tag.IndexOf("L") > -1, AllRooms);

        RightRooms = FilterObjects(g => g.tag.IndexOf("R") > -1, AllRooms);

        //creating rooms with two or more     
        BottomRooms_2 = FilterObjects(g => g.tag.Length >= 2 && g.tag.IndexOf("B") > -1, AllRooms);

    
        TopRooms_2 = FilterObjects(g => g.tag.Length >= 2 && g.tag.IndexOf("T") > -1, AllRooms);

        LeftRooms_2 = FilterObjects(g => g.tag.Length >= 2 && g.tag.IndexOf("L") > -1, AllRooms);
  
        RightRooms_2 = FilterObjects(g => g.tag.Length >= 2 && g.tag.IndexOf("R") > -1, AllRooms);


        EntryRooms_1 = FilterObjects(g => g.CompareTag("Entry1"), entryRooms);


        EntryRooms_2 = FilterObjects(g => g.CompareTag("Entry2"), entryRooms);

        EntryRooms_3 = FilterObjects(g => g.CompareTag("Entry3"), entryRooms);

        for (int i = 0; i < entryRooms.Length; i++)
        {
            if (entryRooms[i].CompareTag("Entry4"))
            {
                EntryRoom_4 = entryRooms[i];
            }
        }      



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


    private GameObject[] FilterObjects(Func< GameObject,bool> filterFunc, GameObject[] listToBeFiltered)
    {
        List<GameObject> filteredList = new List<GameObject>();

        for (int i = 0; i < listToBeFiltered.Length; i++)
        {
            if (filterFunc(listToBeFiltered[i]))
            {
                filteredList.Add(listToBeFiltered[i]);
            }
        }
        return filteredList.ToArray();
    }


}

