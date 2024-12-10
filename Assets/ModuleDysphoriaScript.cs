using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;
using Rnd = UnityEngine.Random;
using UnityEngine.UI;

public class ModuleDysphoriaScript : MonoBehaviour
{
    static int _moduleIdCounter = 1;
    int _moduleID = 0;

    public KMBombModule Module;
    public KMBombInfo Bomb;
    public KMAudio Audio;
    public MDComponent[] AllComponents;

    private int AppearanceComponent;
    private int LayoutComponent;

    void Awake()
    {
        _moduleID = _moduleIdCounter++;
    }

    void Start()
    {
        var ixs = Enumerable.Range(0, AllComponents.Length).ToArray().Shuffle();
        AppearanceComponent = ixs.First();
        LayoutComponent = ixs.Last();

        for (int i = 0; i < AllComponents.Length; i++)
        {
            if (i != AppearanceComponent)
                AllComponents[i].DeactivateAppearance();
            if (i != LayoutComponent)
                AllComponents[i].DeactivateLayout();
        }

        AllComponents[AppearanceComponent].SetRegisters(AllComponents[AppearanceComponent].GetRegisters());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
