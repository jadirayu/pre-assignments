using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfHoles : MonoBehaviour
{
    public ListOfHoles()
    {
        thisHoles = Init3holes();

    }

    public void AddHole()
    {
    }

    public void DeleteHole()
    {
    }

    public void FormatText()
    {
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

    private Hole[] thisHoles;
}
