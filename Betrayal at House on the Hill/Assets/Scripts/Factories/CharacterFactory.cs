using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    public GameObject CharacterPrefab;
    
    public struct CharacterJson
    {
        public string Name;

        public int Age;
        public float Height;
        public int Weight;
        public List<string> Hobbies;
        public DateTime Birthday;
        public Traits Traits;
    }

    public struct Traits
    {
        public int SpeedLevel;
        public int MightLevel;
        public int SanityLevel;
        public int KnowledgeLevel;

        public List<int> SpeedLevels;
        public List<int> MightLevels;
        public List<int> SanityLevels;
        public List<int> KnowledgeLevels;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCharacter(string json)
    {
        CharacterJson characterJson = JsonUtility.FromJson<CharacterJson>(json);
        GameObject character = Instantiate(CharacterPrefab);
        character.GetComponent<CharacterController>().InitialiseValues(characterJson);
    }
}
