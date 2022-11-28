using UnityEngine;
using UnityEngine.UI;

public sealed class UiNavigationCursor : MonoBehaviour
{
    [SerializeField] private Image _posych;
    [SerializeField] private Animator _posychAnimator;
    private readonly int _property = Animator.StringToHash("Posych Staying");
    
    public void TranslateTo(Vector2 position)
    {
        _posych.transform.position = position;
    }

    public void PlayAnimation()
    {
        _posychAnimator.SetBool(_property, true);
    }

    public void StopAnimation()
    {
        _posychAnimator.SetBool(_property, false);
    }
}