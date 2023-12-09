using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class KeyManager
{
    public bool hasLevelOneKey;
    public bool hasLevelTwoKey;
    public bool hasLevelThreeKey;
    public bool hasGuardbadge;

    public KeyManager() 
    { 
        hasLevelOneKey = true;
        hasLevelTwoKey = true;
        hasLevelThreeKey = false;
        hasGuardbadge = false;
    }

    public KeyManager(bool hasLevelOneKey, bool hasLevelTwoKey, bool hasLevelThreeKey)
    {
        this.hasLevelOneKey = hasLevelOneKey;
        this.hasLevelTwoKey = hasLevelTwoKey;
        this.hasLevelThreeKey = hasLevelThreeKey;
    }

    public void setLevelOneKey(bool hasKey)
    {
          this.hasLevelOneKey= hasKey;
    }

    public void setLevelTwoKey(bool hasKey)
    {
        this.hasLevelTwoKey = hasKey;
    }

    public void setLevelThreeKey(bool hasKey)
    {
        this.hasLevelThreeKey = hasKey;
    }

    public void setHasGuardBadge(bool hasBadge)
    {
        this.hasGuardbadge= hasBadge;
    }
}
