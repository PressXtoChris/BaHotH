using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TraitController))]
public class CharacterController : MonoBehaviour
{
    public TraitController TraitController;

    public string Name { get; private set; }

    public int Age { get; private set; }
    public float Height { get; private set; }
    public int Weight { get; private set; }
    public List<string> Hobbies { get; private set; }
    public DateTime Birthday { get; private set; }

    public bool Alive { get; set; }


    // Start is called before the first frame update
    void Awake()
    {
        TraitController = GetComponent<TraitController>();
        Alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitialiseValues(CharacterFactory.CharacterJson characterJson)
    {
        Name = characterJson.Name;
        Age = characterJson.Age;
        Height = characterJson.Height;
        Weight = characterJson.Weight;
        Hobbies = characterJson.Hobbies;
        TraitController.InitialiseValues(characterJson.Traits);
    }
}
