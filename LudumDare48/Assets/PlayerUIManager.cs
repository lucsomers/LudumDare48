using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    #region SingleTon

    public static PlayerUIManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    [Header("Diamonds")]
    [SerializeField] TMPro.TMP_Text diamondTextBox;

    [Header("Jump power")]
    [SerializeField] TMPro.TMP_Text jumpPowerTextBox;

    [Header("Hearths")]
    [SerializeField] private List<Image> damagedHearths = new List<Image>();
    [SerializeField] private List<Image> normalHearths = new List<Image>();

    public void UpdateHealth(int currentHealth)
    {
        for (int i = 0; i < damagedHearths.Count; i++)
        {
            if (i < currentHealth)
            {
                damagedHearths[i].gameObject.SetActive(false);
                normalHearths[i].gameObject.SetActive(true);
            }
            else
            {
                normalHearths[i].gameObject.SetActive(false);
                damagedHearths[i].gameObject.SetActive(true);
            }
        }
    }

    public void UpdateDiamondText(string currentDiamondValue)
    {
        diamondTextBox.SetText(currentDiamondValue);
    }

    public void UpdateJumpPowerText(string currentJumpPowerValue)
    {
        jumpPowerTextBox.SetText(currentJumpPowerValue);
    }
}
