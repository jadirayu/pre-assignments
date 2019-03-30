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
    public Camera Camera;

    private void Awake() {
        this.BtnBack.onClick.AddListener(GoBack);
        this.holes = new List<Hole>();
        this.holeInstances = new List<GameObject>();
        RefreshDropdown();
        this.DpdnHoles.onValueChanged.AddListener(delegate { DpdnValueChanged(this.DpdnHoles); });
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
    private void AddHole(bool isDeletable) {
        Hole newHole = new Hole(Screen.width, Screen.height, isDeletable);
        this.holes.Add(newHole);
        RefreshDropdown();

        if (isDeletable) {
            Vector3 vec3 = this.Camera.ScreenToWorldPoint(new Vector3( newHole.Position[0], newHole.Position[1], 0.5f));
            GameObject holeInstance = (GameObject)Instantiate(PrefabHole, vec3, Quaternion.identity);
            holeInstance.transform.SetParent(this.Canvas.transform);
            this.holeInstances.Add(holeInstance);
        }
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
