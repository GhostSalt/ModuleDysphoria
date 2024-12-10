using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Rnd = UnityEngine.Random;

public class Button : MDComponent
{
    public GameObject AppearanceParent;
    public Image[] ButtonStripes;
    public MeshRenderer ButtonRend;
    public TextMesh Label;
    public KMSelectable Selectable;

    private int ButtonColour;
    private Color[] PossibleButtonColours = new Color[] { new Color32(230, 50, 50, 255), new Color32(240, 240, 70, 255), new Color32(50, 50, 130, 255), new Color32(220, 220, 220, 255) };
    private Color[] AssociatedLabelColours = new Color[] { Color.black, Color.black, Color.white, Color.black };

    private int[] ButtonStripeColours = new int[2];
    private Color[] PossibleStripeColours = new Color[] { Color.red, new Color(1, 1, 0, 1), Color.green, Color.cyan, Color.blue, Color.magenta, Color.black, Color.white };
    private string[] PossibleLabels = new string[] { "PRESS", "HOLD", "DETONATE", "ABORT" };

    void Awake()
    {
        ButtonStripeColours = Enumerable.Range(0, PossibleStripeColours.Length).ToArray().Shuffle().Take(2).ToArray();
        for (int i = 0; i < ButtonStripes.Length; i++)
            ButtonStripes[i].color = PossibleStripeColours[ButtonStripeColours[i % 2]];

        Label.text = PossibleLabels.PickRandom();

        ButtonColour = Rnd.Range(0, PossibleButtonColours.Length);
        ButtonRend.material.color = PossibleButtonColours[ButtonColour];
        Label.color = AssociatedLabelColours[ButtonColour];
        Label.characterSize = 0.26f / Label.text.Length;
        Label.transform.localPosition = new Vector3(0.001f / Label.text.Length, Label.transform.localPosition.y, Label.transform.localPosition.z); // Ostrich Sans is so scuffed.
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
        return new int[] { 1, 2, 3 };
    }

    public override void DeactivateAppearance()
    {
        AppearanceParent.gameObject.SetActive(false);
    }

    public override void DeactivateLayout()
    {
        Selectable.gameObject.SetActive(false);
    }
}
