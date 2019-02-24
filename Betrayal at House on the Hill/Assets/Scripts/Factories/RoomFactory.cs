using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomFactory : MonoBehaviour
{
    public static RoomFactory Instance;

    public GameObject RoomPrefab;

    public static List<RoomJson> RoomJsons = new List<RoomJson>();

    public struct RoomJson
    {
        public string Name;
        public Floor Floor;
        public bool CanExitNorth;
        public bool CanExitEast;
        public bool CanExitSouth;
        public bool CanExitWest;
        public string NorthRoom;
        public string EastRoom;
        public string SouthRoom;
        public string WestRoom;
        public string[] ConnectedRooms;
    }

    private void Awake()
    {
        Instance = this;
    }

    public void CreateRoomJsonsList(string json)
    {
        RoomJsons.Add(JsonUtility.FromJson<RoomJson>(json));
    }

    public static RoomJson GetRoomJsonWithName(string name)
    {
        return RoomJsons.Where(r => r.Name == name).First();
    }
}
