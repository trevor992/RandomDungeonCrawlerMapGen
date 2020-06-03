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
            rand = Random.Range(0, templates.entryRooms_1.Length);
            Instantiate(templates.entryRooms_1[rand], transform.position, templates.entryRooms_1[rand].transform.rotation);
        }
        else if(entryRoomType == 2)
        {
            rand = Random.Range(0, templates.entryRooms_2.Length);
            Instantiate(templates.entryRooms_2[rand], transform.position, templates.entryRooms_2[rand].transform.rotation);

        }
        else if(entryRoomType == 3)
        {
            rand = Random.Range(0, templates.entryRooms_3.Length);
            Instantiate(templates.entryRooms_3[rand], transform.position, templates.entryRooms_3[rand].transform.rotation);
        }
        else if(entryRoomType == 4)
        {
            Instantiate(templates.entryRoom_4, transform.position, templates.entryRoom_4.transform.rotation);
        }
    }

    public int GetEntryRoomType()
    {
        return entryRoomType;
    }

}
