﻿#if PC2D_PLAYMAKER_SUPPORT

using Com.LuisPedroFonseca.ProCamera2D;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.Camera)]
[Tooltip("Apply the given influence to the camera")]
public class ProCamera2DApplyInfluenceAction : FsmStateAction 
{
    [Tooltip("The vector representing the influence to be applied")]
    public FsmVector2 Influence;

    [Tooltip("Is this influence a shake? (Ignores boundaries)")]
    public FsmBool IsShakeInfluence;

    public override void OnUpdate() 
    {
        if (ProCamera2D.Instance != null)
            ProCamera2D.Instance.ApplyInfluence(Influence.Value, IsShakeInfluence.Value);
    }
}

#endif