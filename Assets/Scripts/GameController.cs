using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public Transform player;
    public Transform pillar;
    public GameObject platformPrefab;
    public GameObject badPlatformPrefab;

    int levelsCount = 5;
    float levelsDistance = 3f;
    float baseLevelY = -7;

    struct PlatformTransform {
        public float x;
        public float z;
        public float rx; // rotation around x
        public float rz; // rotation around z
    }

    List<PlatformTransform> platformCorners = new() {
        new () { x = -0.35f, z = 0.35f, rx = -90, rz = 0},
        new () { x = -0.35f, z = -0.35f, rx = -90, rz = -90},
        new () { x = 0.35f, z = 0.35f, rx = -90, rz = 90},
        new () { x = 0.35f, z = -0.35f, rx = -90, rz = 180},
    };

    void Start()
    {
        for (int i = 0; i < levelsCount; i++)
        {
            List<int> platformsToUse = new() {0,1,2,3};

            int badPlatformIndex = Random.Range(0,3);

            for (int j = 0; j < 3; j++)
            {
                bool isBad = i > 0 && j == badPlatformIndex;

                var randIndex = Random.Range(0, platformsToUse.Count);

                CreatePlatform(platformsToUse[randIndex], i, isBad);

                platformsToUse.RemoveAt(randIndex);
            }
        }
    }

    void CreatePlatform(int platformTransformIndex, int level, bool isBad)
    {
        // ternary operator: a ? b : c ---> b if a=true, c if a=false
        var platform = isBad ? badPlatformPrefab : platformPrefab;
        var platformTr = platformCorners[platformTransformIndex];

        var pos = new Vector3(
            platformTr.x,
            // level 4 -> 0, level 3 -> 1, ..., level 0 -> 4
            ((levelsCount-1) - level) * levelsDistance + baseLevelY, 
            platformTr.z
        );

        var rot = Quaternion.Euler(platformTr.rx, 0, platformTr.rz);

        // object to create, position, rotation, (optional) parent's transform 
        Instantiate(platform, pos, rot, pillar.transform);
    }
}
