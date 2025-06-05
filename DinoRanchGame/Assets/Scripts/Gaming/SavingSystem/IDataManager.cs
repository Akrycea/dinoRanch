using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataManager
{
    void LoadData(DinoData data);

    void SaveData(ref DinoData data);
}
