#if PC2D_PLAYMAKER_SUPPORT

using Com.LuisPedroFonseca.ProCamera2D;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.Camera)]
[Tooltip("Remove a target from the camera")]
public class ProCamera2DRemoveTargetAction : FsmStateAction 
{
    [RequiredField]
    [Tooltip("The Transform of the target")]
    public FsmGameObject target;

    public override void OnEnter() 
    {
        if (ProCamera2D.Instance != null && target.Value)
            ProCamera2D.Instance.RemoveCameraTarget(target.Value.transform);

        Finish();
    }
}

#endif