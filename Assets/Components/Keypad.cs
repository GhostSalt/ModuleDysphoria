using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MDComponent
{
    public GameObject AppearanceParent;
    public MeshRenderer[] LEDs;
    public SpriteRenderer[] SymbolRends;
    public Sprite[] Symbols;
    public KMSelectable[] Selectables;

    private int[] SymbolIxs = new int[4];

    void Awake()
    {
        SymbolIxs = Enumerable.Range(0, Symbols.Length).ToArray().Shuffle().Take(4).ToArray();
        for (int i = 0; i < SymbolRends.Length; i++)
            SymbolRends[i].sprite = Symbols[SymbolIxs[i]];
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override int[] GetRegisters()
    {
        return new int[] { 1, 2, 3, 4 };
    }

    public override void DeactivateAppearance()
    {
        AppearanceParent.gameObject.SetActive(false);
    }

    public override void DeactivateLayout()
    {
        for (int i = 0; i < Selectables.Length; i++)
            Selectables[i].gameObject.SetActive(false);
    }
}
