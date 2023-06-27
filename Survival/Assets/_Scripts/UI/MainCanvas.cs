using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour, ILevelProgressionListener, IHealthListener
{
    [SerializeField] private Image _experienceBar;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _healthText;

    public void Initialize()
    {
        var contexts = Contexts.sharedInstance;
        var player = contexts.game.playerEntity;
        player.AddLevelProgressionListener(this);
        player.AddHealthListener(this);
        _healthText.text = player.health.value.ToString();
    }

    private void Update()
    {
        var time = (int)Time.timeSinceLevelLoadAsDouble;
        var minutes = time / 60;
        var seconds = time % 60;
        string minutesStr = minutes < 10 ? $"0{minutes}" : minutes.ToString();
        string secondsStr = seconds < 10 ? $"0{seconds}" : seconds.ToString();
        _timerText.text = $"{minutesStr}:{secondsStr}";
    }

    private void UpdateExperienceBar(float experiencePercent, float duration, int level)
    {
        DOTween.To(() => _experienceBar.fillAmount, 
            x => _experienceBar.fillAmount = x, 
            experiencePercent, duration);

        _levelText.text = $"LVL {level}";
    }
    
    private void UpdateHealth(int value)
    {
        _healthText.text = $"{value}";
    }

    public void OnLevelProgression(GameEntity entity, int level, int currentEXP, int nextLevelRequiredEXP)
    {
        UpdateExperienceBar((float)currentEXP / nextLevelRequiredEXP, 0.1f, level);
    }

    public void OnHealth(GameEntity entity, int value)
    {
        UpdateHealth(value);
    }
}
