#if PC2D_PLAYMAKER_SUPPORT

using Com.LuisPedroFonseca.ProCamera2D;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using UnityEngine;

[ActionCategory(ActionCategory.Camera)]
[Tooltip("Shakes the camera position along its horizontal and vertical axes with the given values")]
public class ProCamera2DShakeAction : FsmStateAction 
{
    [RequiredField]
    [Tooltip("The camera with the ProCamera2D component, most probably the MainCamera")]
    public FsmGameObject MainCamera;

    [Tooltip("The shake strength on each axis")]
    public FsmVector2 Strength;

    [Tooltip("The duration of the shake")]
    public FsmFloat Duration = 1;

    [Tooltip("Indicates how much will the shake vibrate")]
    public FsmInt Vibrato = 10;

    [Tooltip("Indicates how much the shake will be random")]
    [HasFloatSlider(0, 90)]
    public FsmFloat Randomness = 10;

    public override void OnEnter() 
    {
        var shake = MainCamera.Value.GetComponent<ProCamera2DShake>();

        if (shake == null)
            Debug.LogError("The ProCamera2D component needs to have the Shake plugin enabled.");

        if (ProCamera2D.Instance != null && shake != null)
            MainCamera.Value.GetComponent<ProCamera2DShake>().Shake(Duration.Value, Strength.Value, Vibrato.Value, Randomness.Value);

        Finish();
    }
}

#endif