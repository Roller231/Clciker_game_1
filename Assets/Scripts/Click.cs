using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public Text scoreText;
    public int score;

    public int scoreToPlus = 1;
    public int autoClick = 1;

    public Text energyText;
    public Text energyMAxText;
    public int energyMax;
    public int enegrgy = 100;
    public Image progressBar;


    public int cost_upgrade_click = 3;
    public int cost_upgrade_autoclick = 3;
    public int cost_upgrade_energy = 3;

    public Text cost_upgrade_click_text;
    public Text cost_upgrade_autoclick_text;
    public Text cost_upgrade_energy_text;


    public Image[] iconsMoney;


    private void Update()
    {
        scoreText.text = FormatNumberWithCommas(score);
        energyText.text = enegrgy.ToString();
        energyMAxText.text = energyMax.ToString();

        cost_upgrade_click_text.text = cost_upgrade_click.ToString();
        cost_upgrade_autoclick_text.text = cost_upgrade_autoclick.ToString();
        cost_upgrade_energy_text.text = cost_upgrade_energy.ToString();

        // Прогресс-бар заполняется на основе энергии и максимальной энергии
        progressBar.fillAmount = (float)enegrgy / energyMax;
    }


    private void Start()
    {
        StartCoroutine(PlusEnergy());
        StartCoroutine(AutoClick());

    }

    public void AddScore()
    {
        if(enegrgy >= 10)
        {
            enegrgy -= 10;
            score += scoreToPlus;
        }
    }

    private IEnumerator PlusEnergy()
    {
        yield return new WaitForSeconds(6f);
        if (enegrgy < energyMax)
        {
            enegrgy += 1;
        }
        StartCoroutine(PlusEnergy());
    }

    private IEnumerator AutoClick()
    {
        yield return new WaitForSeconds(2f);
        if (autoClick != 1) 
        {
            score += autoClick;

        }
        StartCoroutine(AutoClick());


    }


    public static string FormatNumberWithCommas(int number)
        {
            return number.ToString("N0", CultureInfo.InvariantCulture);
        }

    public void UpgradeClick()
    {
        if(cost_upgrade_click <= score)
        {
            scoreToPlus *= 2;
            score -= cost_upgrade_click;
            cost_upgrade_click *= 2;
        }


    }

    public void UpgradeAutoClick()
    {
        if (cost_upgrade_autoclick <= score)
        {
            autoClick *= 2;
            score -= cost_upgrade_autoclick;
            cost_upgrade_autoclick *= 2;
        }


    }

    public void UpgradeEnergy()
    {
        if (cost_upgrade_energy <= score)
        {
            energyMax *= 2;
            score -= cost_upgrade_energy;
            cost_upgrade_energy *= 2;
        }


    }

    public void ChangeScin(GameObject sprite)
    {
        if(score >= sprite.GetComponentInParent<ScinButton>().cost && !sprite.GetComponentInParent<ScinButton>().isOpened)
        {


            sprite.GetComponentInParent<ScinButton>().isOpened = true;
            score -= sprite.GetComponentInParent<ScinButton>().cost;
        }

        else if (sprite.GetComponentInParent<ScinButton>().isOpened)
        {
            foreach (var item in iconsMoney)
            {
                item.sprite = sprite.GetComponent<Image>().sprite;
            }
        }




    }

}
