using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Button spawnButton;

    public Button SpawnButton => spawnButton;

    public void UpdateCoinText(int count)
    {
        coinText.text = count.ToString();
    }

    void Update()
    {

    }
}
