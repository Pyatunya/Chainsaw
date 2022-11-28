using UnityEngine;

public sealed class BestScore : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private CountView _view;
    
    private readonly StorageWithNameSaveObject<BestScore, int> _storage = new();
    private int _record;
    
    private void OnEnable()
    {
        _record = _storage.HasSave() ? _storage.Load() : 0;
        _view.Visualize(_record);
        _score.OnChanged += TryIncrease;
    }

    public void Init(int record)
    {
        _record = record;
        _view.Visualize(_record);
        _score.OnChanged += TryIncrease;
    }

    private void TryIncrease(int count)
    {
        if(_record < count)
        {
            _record = count;
            _view.Visualize(_record);
            _storage.Save(_record);
        }
    }

    private void OnDestroy() => _score.OnChanged -= TryIncrease;
    
}