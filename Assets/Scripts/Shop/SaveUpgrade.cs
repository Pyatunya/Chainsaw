using System;

public sealed class SaveUpgrade<TStorageUser, TSaveType> : IUpgrade
{
    private readonly IStorage _hasUsedStorage;
    private readonly StorageWithNameSaveObject<TStorageUser, TSaveType> _saveTypeStorage;
    private readonly TSaveType _saveType;
    private readonly string _path;

    public SaveUpgrade(IStorage storage, TSaveType saveType, string path)
    {
        _path = path ?? throw new ArgumentNullException(nameof(path));
        _hasUsedStorage = storage ?? throw new ArgumentNullException(nameof(storage));
        _saveTypeStorage = new(storage);
        _saveType = saveType ?? throw new ArgumentNullException(nameof(saveType));
        HasUsed = _hasUsedStorage.Exists(_path) ? _hasUsedStorage.Load<bool>(_path) : false;
    }

    public bool HasUsed { get; private set; }
    
    public void Use()
    {
        if (HasUsed)
            throw new InvalidOperationException("Has Used!");
        
        HasUsed = true;
        _hasUsedStorage.Save(_path, true);
        _saveTypeStorage.Save(_saveType);
    }
}