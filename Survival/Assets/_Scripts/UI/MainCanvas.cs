using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour, ILevelProgressionListener
{
    [SerializeField] private Image _experienceBar;
    [SerializeField] private TMP_Text _levelText;

    public void Initialize()
    {
        var contexts = Contexts.sharedInstance;
        var player = contexts.game.playerEntity;
        player.AddLevelProgressionListener(this);
    }

    private void UpdateExperienceBar(float experiencePercent, float duration, int level)
    {
        DOTween.To(() => _experienceBar.fillAmount, 
            x => _experienceBar.fillAmount = x, 
            experiencePercent, duration);

        _levelText.text = $"LVL {level}";
    }

    public void OnLevelProgression(GameEntity entity, int level, int currentEXP, int nextLevelRequiredEXP)
    {
        UpdateExperienceBar((float)currentEXP / nextLevelRequiredEXP, 0.1f, level);
    }
}
