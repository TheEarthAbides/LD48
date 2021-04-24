using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    public GameObject [] upgradePool;

    public float upgradeSpawnChance = 20;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RollForUpgrade(Vector3 _pos)
    {
        if(Random.Range(0, 100) < upgradeSpawnChance)
        {
            SpawnUpgrade(_pos);
        }
    }

    public void SpawnUpgrade(Vector3 _pos)
    {
        int upgradeType = Random.Range(0, upgradePool.Length);

        GameObject upgrade = Instantiate(upgradePool[upgradeType]);
        upgrade.transform.parent = null;
        upgrade.transform.position = _pos;
        upgrade.gameObject.SetActive(true);

    }
}
