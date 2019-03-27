using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour
{
    public Button BtnProfessional;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BtnProfessional.onClick.AddListener(GoToProfessional);
    }

    void GoToProfessional()
    {
        Application.LoadLevel("ProfessionalScreen");
    }
}