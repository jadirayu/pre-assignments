using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// TODO: figure out model, view model architecture
public class ProfessionalScreen : MonoBehaviour
{
    public Button BtnBack;
    public Button BtnAddHole;

    void Awake()
    {
        this.holesViewModel = new HolesViewModel();
        string[] txtList = holesViewModel.FormatText();
        // TODO: programmatically generate the list
    }

    // Start is called before the first frame update
    void Start()
    {
        this.dropdown = GetComponent<Dropdown>();
        this.dropdown.options.Clear();
        foreach (Hole hole in this.holes)
        {
            dropdown.options.Add(new Dropdown.OptionData("a hole"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        BtnBack.onClick.AddListener(GoToMain);
        BtnAddHole.onClick.AddListener(AddHole);
    }

    private void GoToMain()
    {
        Application.LoadLevel("MainScreen");
    }

    private void AddHole()
    {
        this.holesViewModel.AddHole();
    }

    private HolesViewModel holesViewModel;
    private Dropdown dropdown;
    private List<Hole> holes;
}
