using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Professional : MonoBehaviour
{
    public Button BtnBack;
    public Dropdown DpdnHoles;
    public GameObject PrefabHole;
    public Canvas Canvas;

    private void Awake() {
        this.BtnBack.onClick.AddListener(GoBack);
        Init3Holes();
        this.DpdnHoles.onValueChanged.AddListener(delegate { DpdnValueChanged(this.DpdnHoles); });
    }

    /// <summary>
    /// Initialize the first three holes in given positions
    /// </summary>
    private void Init3Holes() {
        this.holes = new List<Hole>();
        this.holeInstances = new List<GameObject>();
        for (int i = 0; i < 3; i++) {
            AddHole(false, i);
        }
        RefreshDropdown();
    }

    private void DpdnValueChanged(Dropdown dpdnHoles) {
        if (dpdnHoles.value == this.holes.Count) {
            AddHole(true);
        }
        else
        {
            DeleteHole(dpdnHoles.value);
        }
    }

    /// <summary>
    /// Add a hole 
    /// in a given position if it's one of the first three holes
    /// in a random position otherwise
    /// </summary>
    /// <param name="isDeletable">is one of the first three holes</param>
    /// <param name="nr">the number of the hole</param>
    private void AddHole(bool isDeletable, int nr = -1) {
        Hole newHole = new Hole(isDeletable, nr);
        this.holes.Add(newHole);
        RefreshDropdown();

        if (isDeletable) {
            GameObject holeInstance = (GameObject)Instantiate(PrefabHole, new Vector3(this.Canvas.transform.position.x + newHole.Position[0],
            this.Canvas.transform.position.y + newHole.Position[1], 0), Quaternion.identity);
            holeInstance.transform.SetParent(this.Canvas.transform);
            this.holeInstances.Add(holeInstance);
        }
        
        //Debug.Log("x: " + newHole.Position[0]  + " y: " + newHole.Position[1]);
    }

    /// <summary>
    /// Delete a hole
    /// </summary>
    /// <param name="index">index of the selected hole from the dropdown menu</param>
    private void DeleteHole(int index) {
        if (this.holes[index].IsDeletable)
        {
            this.holes.RemoveAt(index);
            RefreshDropdown();
            Destroy(this.holeInstances[index]);
        }
        else {
            EditorUtility.DisplayDialog("Oops", "This is one of the first three holes which are undeletable. Try another hole!", "OK", "Cancel");
        }
    }


    private void RefreshDropdown() {
        this.DpdnHoles.options.Clear();
        for (int i = 0; i < this.holes.Count; i++) {
            this.DpdnHoles.options.Add(new Dropdown.OptionData("Hole: " + (i + 1)));
        }
        this.DpdnHoles.options.Add(new Dropdown.OptionData("Add New"));
        this.DpdnHoles.RefreshShownValue();
    }

    private void GoBack() {
        Application.LoadLevel("Main");
    }

    private List<Hole> holes;
    private List<GameObject> holeInstances;
}
