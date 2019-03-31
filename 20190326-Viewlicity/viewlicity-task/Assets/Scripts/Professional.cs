using System;
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
    public Button BtnReset;

    private void Awake() {
        InitHoles();
        this.DpdnHoles.onValueChanged.AddListener(delegate { DpdnValueChanged(this.DpdnHoles); });
        this.BtnBack.onClick.AddListener(GoBack);
        this.BtnReset.onClick.AddListener(OnReset);
    }

    private void InitHoles() {
        this.holes = new List<Hole>();
        this.holeInstances = new List<GameObject>();
        this.textObjs = new List<GameObject>();
        for (int i = 0; i < 3; i++) {
            AddHole(false, i);
        }
        RefreshScreen();
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
    /// Add a hole in this.Holes with a position that is
    /// 1) invisible if it's one of the first three holes,
    /// or 2) random otherwise;
    /// and refresh the dropdown menu
    /// </summary>
    /// <param name="isDeletable">is one of the first three holes</param>
    /// <param name="nr">the number of the hole</param>
    private void AddHole(bool isDeletable, int nr = -1) {
        Hole newHole = new Hole(Screen.width, Screen.height, isDeletable, nr);
        if (newHole.Position[0] != Single.NaN) {
            this.holes.Add(newHole);
            RefreshScreen();
        }
    }

    /// <summary>
    /// Delete a hole from this.Hole
    /// </summary>
    /// <param name="index">index of the selected hole from the dropdown menu</param>
    private void DeleteHole(int index) {
        if (this.holes[index].IsDeletable)
        {
            this.holes.RemoveAt(index);
            RefreshScreen();
        }
        else {
            EditorUtility.DisplayDialog("Oops", "This is one of the first three holes which are undeletable. Try another hole!", "OK", "Cancel");
        }
    }


    /// <summary>
    /// Refresh dropdown menu
    /// Add/delete holes on screen
    /// </summary>
    private void RefreshScreen() {
        this.DpdnHoles.options.Clear();
        foreach (GameObject holeInstance in this.holeInstances)
            Destroy(holeInstance);
        this.holeInstances.Clear();
        this.textObjs.Clear();

        for (int i = 0; i < this.holes.Count; i++) {
            this.DpdnHoles.options.Add(new Dropdown.OptionData("Hole: " + (i + 1)));

            Vector3 vec3 = new Vector3();
            if (i < 3)
            {
                vec3 = this.Camera.ScreenToWorldPoint(new Vector3(this.holes[i].Position[0], this.holes[i].Position[1], -1000f));
            }
            else {
                vec3 = this.Camera.ScreenToWorldPoint(new Vector3(this.holes[i].Position[0], this.holes[i].Position[1], 0.5f));
            }
            GameObject holeInstance = (GameObject)Instantiate(PrefabHole, vec3, Quaternion.identity);
            holeInstance.transform.SetParent(this.Canvas.transform);
            this.holeInstances.Add(holeInstance);

            this.textObjs.Add(new GameObject());
            Text textObj = this.textObjs[this.textObjs.Count - 1].AddComponent<Text>();
            textObj.text = i.ToString();
            textObj.fontSize = 15;
            textObj.color = Color.white;
            textObj.horizontalOverflow = HorizontalWrapMode.Overflow;
            textObj.verticalOverflow = VerticalWrapMode.Overflow;
            textObj.transform.SetParent(this.Canvas.transform);
            textObj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            textObj.transform.position = this.Camera.ScreenToWorldPoint(new Vector3(this.holes[i].Position[0], this.holes[i].Position[1], 0.5f));
        }

        this.DpdnHoles.options.Add(new Dropdown.OptionData("Add New"));
        this.DpdnHoles.RefreshShownValue();

        Debug.Log("holes: " + this.holes.Count + " | instance: " + this.holeInstances.Count + " | text: " + this.textObjs.Count);

    }

    private void GoBack() {
        Application.LoadLevel("Main");
    }

    private void OnReset()
    {
        this.holes.Clear();
        for (int i = 0; i < 3; i++)
        {
            AddHole(false, i);
        }
        RefreshScreen();
        Debug.Log("reset");
    }

    private List<Hole> holes;
    private List<GameObject> holeInstances;
    private List<GameObject> textObjs;
}
