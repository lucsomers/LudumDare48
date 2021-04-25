using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScoreOnEndscreen : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMPro.TMP_Text>().SetText(PlayerStats.instance.DiamondTotal.ToString());
    }
}
