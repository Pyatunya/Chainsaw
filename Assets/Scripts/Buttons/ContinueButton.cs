using UnityEngine;
using YandexSDK;

public sealed class ContinueButton : Button
{
    [SerializeField] private string _reward;
    [SerializeField] private GameLoop _gameLoop;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private GameObject _endGamePanel;

    private void OnEnable() => YaSDK.onRewardedAdReward += GetReward;

    private void OnDisable() => YaSDK.onRewardedAdReward -= GetReward;
    
    protected override void OnClick()
    {
        YaSDK.instance.ShowRewarded(_reward);
    }
    
    private void GetReward(string reward)
    {
        if (_reward == reward)
        {
            _endGamePanel.gameObject.SetActive(false);
            _gameLoop.Continue();
            _playerHealth.Heal();
        }
    }
}