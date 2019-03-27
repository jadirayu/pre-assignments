using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolesViewModel : MonoBehaviour
{
    public HolesViewModel()
    {
        this.holes = Init3holes();
    }

    public Hole AddHole()
    {
        Hole newHole = new Hole(true);
        return newHole;
    }

    public void DeleteHole(Hole deletingHole)
    {
        // delete this deletingHole
    }

    // TODO: check if this function is necessary
    public string[] FormatText()
    {
        string[] formatedTexts = new string[this.holes.Length];
        for (int i = 0; i < this.holes.Length; i++)
        {
            formatedTexts[i] = "Hole: " + (char)i;
        }
        return formatedTexts;
    }

    private int NumberHoles(Hole hole, Hole[] holes)
    {
        // TODO: find element # in a given array
        return 0;
    }

    private Hole[] Init3holes()
    {
        Hole[] holes = new Hole[3];
        for (int i = 0; i < 3; i++)
        {
            holes[i] = new Hole(false, i);
        }
        return holes;
    }

    private Hole[] holes;
}
