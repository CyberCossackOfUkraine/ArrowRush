using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyPolicy : MonoBehaviour
{
    public void OpenPrivacyPolicy()
    {
        Application.OpenURL("https://doc-hosting.flycricket.io/arrow-rush-privacy-policy/cd559b6e-65e3-451c-b451-af638c8aa015/privacy");
    }
}
