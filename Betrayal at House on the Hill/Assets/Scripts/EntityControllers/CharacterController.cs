using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TraitController))]
public class CharacterController : MonoBehaviour
{

    public string Name { get; private set; }

    public int Age { get; private set; }
    public float Height { get; private set; }
    public float Weight { get; private set; }
    public List<string> Hobbies { get; private set; }
    public DateTime Birthday { get; private set; }

    public bool Alive { get; private set; }

    private TraitController _traitController;

    // Start is called before the first frame update
    void Awake()
    {
        _traitController = GetComponent<TraitController>();
        Alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
