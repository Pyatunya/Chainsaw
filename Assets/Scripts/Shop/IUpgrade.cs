public interface IUpgrade
{
    bool HasUsed { get; }
    
    void Use();
}