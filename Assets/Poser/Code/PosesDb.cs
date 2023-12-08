using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PosesDB", menuName = "ScriptableObjects/PosesDB")]
public class PosesDb : ScriptableObject {
    public List<AnimationClip> poses = new();

    public AnimationClip GetRandom() {
        return poses[Random.Range(0, poses.Count)];
    }
}
