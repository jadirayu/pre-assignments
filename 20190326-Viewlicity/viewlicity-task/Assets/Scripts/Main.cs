using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Button BtnGoToPro;

    private void Awake()
    {
        this.BtnGoToPro.onClick.AddListener(GoToPro);
    }

    private void GoToPro()
    {
        Application.LoadLevel("Professional");
    }

}
