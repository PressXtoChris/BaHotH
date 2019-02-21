﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private const int MaxLevel = 8;

    public string Name { get; private set; }

    public int Speed { get => _speedLevels[_speedLevel]; }
    public int Might { get => _mightLevels[_mightLevel]; }
    public int Sanity { get => _sanityLevels[_sanityLevel]; }
    public int Knowledge { get => _sanityLevels[_sanityLevel]; }

    public int Age { get; private set; }
    public float Height { get; private set; }
    public float Weight { get; private set; }
    public List<string> Hobbies { get; private set; }
    public DateTime Birthday { get; private set; }

    public bool Alive { get; private set; }

    private int _speedLevel;
    private int _mightLevel;
    private int _sanityLevel;
    private int _knowledgeLevel;

    private List<int> _speedLevels;
    private List<int> _mightLevels;
    private List<int> _sanityLevels;
    private List<int> _knowledgeLevels;

    [Range(0, int.MaxValue)]
    private int _speedOverflow;
    [Range(0, int.MaxValue)]
    private int _mightOverflow;
    [Range(0, int.MaxValue)]
    private int _sanityOverflow;
    [Range(0, int.MaxValue)]
    private int _knowledgeOverflow;

    // Start is called before the first frame update
    void Awake()
    {
        Alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Roll (Trait trait)
    {
        switch (trait)
        {
            case Trait.Speed:
                return Roll(Speed);
            case Trait.Might:
                return Roll(Might);
            case Trait.Sanity:
                return Roll(Sanity);
            case Trait.Knowledge:
                return Roll(Knowledge);
            default:
                throw new Exception("Unknown trait provided for roll: " + trait.ToString());
        }
    }

    public void ModifyTraitLevel(Trait trait, int amount)
    {
        switch (trait) {
            case Trait.Speed:
                ModifyTraitLevel(ref _speedLevel, ref _speedOverflow, amount);
                break;
            case Trait.Might:
                ModifyTraitLevel(ref _mightLevel, ref _mightOverflow, amount);
                break;
            case Trait.Sanity:
                ModifyTraitLevel(ref _sanityLevel, ref _sanityOverflow, amount);
                break;
            case Trait.Knowledge:
                ModifyTraitLevel(ref _knowledgeLevel, ref _knowledgeOverflow, amount);
                break;
            default:
                throw new Exception("Unknown trait provided for ModifyTraitLevel: " + trait.ToString());
        }
    }

    private int Roll(int trait)
    {
        int total = 0;

        for (int i = 0; i < trait; i++)
        {
            total += UnityEngine.Random.Range(0, 2);
        }

        return total;
    }

    private void ModifyTraitLevel(ref int trait, ref int traitOverflow, int amount)
    {
        if (amount > 0)
        {
            if (trait + amount <= MaxLevel)
            {
                trait += amount;
            }
            else
            {
                trait = MaxLevel;
                traitOverflow = trait + amount - MaxLevel;
            }
        }
        else
        {
            if (trait + amount <= 0)
            {
                if (Globals.HauntActive)
                {
                    Alive = false;
                }
                else
                {
                    trait = 1;
                }
            }
            else
            {
                trait += traitOverflow + amount;
                traitOverflow += amount;
            }
        }
    }
}
