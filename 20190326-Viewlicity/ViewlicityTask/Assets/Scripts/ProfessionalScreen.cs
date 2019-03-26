using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfessionalScreen : MonoBehaviour
{
    public Button BtnBack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BtnBack.onClick.AddListener(GoToMain);
    }

    void GoToMain()
    {
        Application.LoadLevel("MainScreen");
    }
}
