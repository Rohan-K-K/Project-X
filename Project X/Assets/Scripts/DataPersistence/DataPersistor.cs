using UnityEngine;

public interface DataPersistor
{
    void LoadSave(GameData data);
    void WriteSave(ref GameData data);
}
