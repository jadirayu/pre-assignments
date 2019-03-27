using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Professional : MonoBehaviour
{
    public Button BtnBack;
    public Dropdown DpdnHoles;
    public GameObject PrefabHole;

    private void Awake() {
        this.BtnBack.onClick.AddListener(GoBack);
        Init3Holes();
        this.DpdnHoles.onValueChanged.AddListener(delegate { DpdnValueChanged(this.DpdnHoles); });
    }

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

    private void AddHole(bool isDeletable, int nr = -1) {
        Hole newHole = new Hole(isDeletable, nr);
        this.holes.Add(newHole);
        RefreshDropdown();
        GameObject holeInstance = (GameObject)Instantiate(PrefabHole, new Vector2(newHole.Position[0], newHole.Position[1]), Quaternion.identity);
        this.holeInstances.Add(holeInstance);
    }

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
