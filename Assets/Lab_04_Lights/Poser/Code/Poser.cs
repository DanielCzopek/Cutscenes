using UnityEngine;

public class Poser : MonoBehaviour {
    [SerializeField] PosesDb posesDb;
    [SerializeField] AnimationClip selectedPose;
    
    #if UNITY_EDITOR
    public void Reset() {
        InitPosesDb();
        selectedPose = posesDb.GetRandom();
        UpdateModelPose();
    }

    void InitPosesDb() {
        if (posesDb == null) {
            var dbGuid = UnityEditor.AssetDatabase.FindAssets("t:PosesDB")[0];
            var path = UnityEditor.AssetDatabase.GUIDToAssetPath(dbGuid);
            posesDb = UnityEditor.AssetDatabase.LoadAssetAtPath<PosesDb>(path);
        }
    }
    
    void UpdateModelPose() {
        var animator = GetComponent<Animator>();
        var animatorController = new UnityEditor.Animations.AnimatorController();
        animatorController.AddLayer("Base Layer");
        animatorController.AddMotion(selectedPose);
        animator.runtimeAnimatorController = animatorController;
        animator.Update(0);
    }
    #endif
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(Poser))]
public class PoserInspector : UnityEditor.Editor
{
    public override void OnInspectorGUI() {
        if(GUILayout.Button("Randomize"))
            (target as Poser)?.Reset();
        base.OnInspectorGUI();
    }
}
#endif