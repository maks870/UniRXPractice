using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    public TextMeshProUGUI tickSpawnCountTxt;
    public TextMeshProUGUI tickTimeTxt;

    public TextMeshProUGUI lackCoinTxt;

    public Button tickSpawnerUpgrade;
    public Button tickSpawnerIncreaseCount;

    void Start()
    {
        if (lackCoinTxt.gameObject.activeInHierarchy)
            lackCoinTxt.gameObject.SetActive(false);
    }

    public IEnumerator NotifyLackCoin()
    {
        float blurTime = 0.5f;
        float showTime = 0.5f;
        Color textColor = lackCoinTxt.color;

        textColor.a = 0;
        lackCoinTxt.gameObject.SetActive(true);

        for (float t = 0; t < blurTime; t += Time.deltaTime)
        {
            textColor.a = Mathf.InverseLerp(0, blurTime, t);
            lackCoinTxt.color = textColor;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        yield return new WaitForSeconds(showTime);

        for (float t = blurTime; t > 0; t -= Time.deltaTime)
        {
            textColor.a = Mathf.InverseLerp(0, blurTime, t);
            lackCoinTxt.color = textColor;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        lackCoinTxt.gameObject.SetActive(false);
    }
}
