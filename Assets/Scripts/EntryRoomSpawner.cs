using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryRoomSpawner : MonoBehaviour
{


    private int rand;
    private RoomTemplates templates;
    private int entryRoomType;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        entryRoomType = Random.Range(1, 5);
        if(entryRoomType == 1)
        {
            rand = Random.Range(0, templates.EntryRooms_1.Length);
            Instantiate(templates.EntryRooms_1[rand], transform.position, templates.EntryRooms_1[rand].transform.rotation);
        }
        else if(entryRoomType == 2)
        {
            rand = Random.Range(0, templates.EntryRooms_2.Length);
            Instantiate(templates.EntryRooms_2[rand], transform.position, templates.EntryRooms_2[rand].transform.rotation);

        }
        else if(entryRoomType == 3)
        {
            rand = Random.Range(0, templates.EntryRooms_3.Length);
            Instantiate(templates.EntryRooms_3[rand], transform.position, templates.EntryRooms_3[rand].transform.rotation);
        }
        else if(entryRoomType == 4)
        {
            Instantiate(templates.EntryRoom_4, transform.position, templates.EntryRoom_4.transform.rotation);
        }
    }

    public int GetEntryRoomType()
    {
        return entryRoomType;
    }

}
