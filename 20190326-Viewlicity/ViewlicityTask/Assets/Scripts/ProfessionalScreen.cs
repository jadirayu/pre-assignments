using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfessionalScreen : MonoBehaviour
{
    public Button BtnBack;
    public Dropdown Dropdown;
    public Transform PrefabHole;

    // Start is called before the first frame update
    void Start()
    {
        BtnBack.onClick.AddListener(GoToMain);
        Init3Holes();
        this.Dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(this.Dropdown); });
        this.indexPrevSelectedHole = -1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void GoToMain() => Application.LoadLevel("MainScreen");

    /// <summary>
    /// Initialize three holes & dropdown menu
    /// </summary>
    private void Init3Holes()
    {
        this.holes = new List<Hole>();
        for (int i = 0; i < 3; i++)
        {
            AddNewHole(false, i);
        }
        RefreshDropdown(this.Dropdown);
    }

    private void DropdownValueChanged(Dropdown dropdown)
    {
        if (dropdown.value == this.holes.Count)
        {
            AddNewHole(true);
        }
        else
        {
            SelectExistingHole(dropdown.value);
        }
    }

    // add a hole from the dropdown
    private void AddNewHole(bool isDeletable, int nr = -1)
    {
        Hole newHole = new Hole(isDeletable, nr);
        this.holes.Add(newHole);
        RefreshDropdown(this.Dropdown);
        Instantiate(PrefabHole, new Vector3(newHole.Position[0], newHole.Position[1], -8.5f), Quaternion.identity);
    }

    // change the dropdown appearance for a confirmed step "Delete Hole: X?"
    private void SelectExistingHole(int indexSelectedHole)
    {
        //if (this.indexPrevSelectedHole == indexSelectedHole)
        //{
        //    DeleteHole(indexSelectedHole);
        //}
        //else
        //{
        //    this.Dropdown.options[indexSelectedHole] = new Dropdown.OptionData("Delete Hole: " + (char)(indexSelectedHole + 1) + "?");
        //}
        //this.indexPrevSelectedHole = indexSelectedHole;
    }

    /// <summary>
    /// Refresh the dropdown with the last option "Add New"
    /// </summary>
    /// <param name="dropdown">gameobject Dropdown</param>
    private void RefreshDropdown(Dropdown dropdown)
    {
        this.Dropdown.options.Clear();
        for (int i = 0; i < this.holes.Count; i++)
        {
            this.Dropdown.options.Add(new Dropdown.OptionData(" " + i));
        }
        this.Dropdown.options.Add(new Dropdown.OptionData("Add New"));
        dropdown.RefreshShownValue();
    }

    // delete a hole from the dropdown, too
    // TODO: delete a hole by tapping on it and select "delete" from popup context menu
    private void DeleteHole(int indexDeletingHole)
    {
    }

    private void FormatDropdown()
    {
    }


    private List<Hole> holes;
    private int indexPrevSelectedHole;
}
