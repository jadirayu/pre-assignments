using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// TODO: change the whole project to 2D
public class ProfessionalScreen : MonoBehaviour
{
    public Button BtnBack;
    public Dropdown Dropdown;
    public GameObject PrefabHole;

    // Start is called before the first frame update
    void Start()
    {
        BtnBack.onClick.AddListener(GoToMain);
        Init3Holes();
        this.Dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(this.Dropdown); });
        this.indexPrevSelectedHole = -1;
    }

    private void GoToMain() => Application.LoadLevel("MainScreen");

    /// <summary>
    /// Initialize three holes & dropdown menu
    /// </summary>
    private void Init3Holes()
    {
        this.holes = new List<Hole>();
        this.holeInstances = new List<GameObject>();
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
            DeleteHole(dropdown.value);
        }
    }

    /// <summary>
    /// Add a hole to the dropdown menu and to the screen
    /// </summary>
    /// <param name="isDeletable">if the hole is one of the three initial holes which is undeletable</param>
    /// <param name="nr">the number of the hole</param>
    private void AddNewHole(bool isDeletable, int nr = -1)
    {
        Hole newHole = new Hole(isDeletable, nr);
        this.holes.Add(newHole);
        RefreshDropdown(this.Dropdown);
        GameObject holeInstance = (GameObject) Instantiate(PrefabHole, new Vector3(newHole.Position[0], newHole.Position[1], -8.5f), Quaternion.identity);
        this.holeInstances.Add(holeInstance);
    }

    // delete a hole from the dropdown, too
    private void DeleteHole(int index)
    {
        if (this.holes[index].IsDeletable)
        {
            this.holes.RemoveAt(index);
            RefreshDropdown(this.Dropdown);
            Destroy(this.holeInstances[index]);
        }
        else {
            EditorUtility.DisplayDialog("Oops!", "This is one of the first three holes which are undeletable. Try another hole :)", "OK", "Cancel");
        }
        
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


    private List<Hole> holes;
    private int indexPrevSelectedHole;
    private List<GameObject> holeInstances;
}
