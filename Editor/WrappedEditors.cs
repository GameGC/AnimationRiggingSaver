using UnityEngine.Animations.Rigging;
using UnityEngine.Animations.Rigging.Saving;

namespace UnityEditor.Animations.Rigging.Saving
{
    [CustomEditor(typeof(BlendConstraint), false)]
    public class BlendConstraintSEditor : WrappedCustomEditor<BlendConstraint, BlendConstraintSaver> { }
    
    [CustomEditor(typeof(MultiRotationConstraint),false)]
    public class MultiRotationConstraintSEditor : WrappedCustomEditor<MultiRotationConstraint,MultiRotationConstraintSaver> { }
    
    [CustomEditor(typeof(ChainIKConstraint),false)]
    public class ChainIKConstraintSEditor : WrappedCustomEditor<ChainIKConstraint,ChainIKConstraintSaver> { }
    
    [CustomEditor(typeof(DampedTransform),false)]
    public class DampedTransformSEditor : WrappedCustomEditor<DampedTransform,DampedTransformSaver> { }
    
    [CustomEditor(typeof(MultiParentConstraint),false)]
    public class MultiParentConstraintSEditor : WrappedCustomEditor<MultiParentConstraint,MultiParentConstraintSaver> { }
    
    [CustomEditor(typeof(MultiAimConstraint),false)]
    public class MultiAimConstraintSEditor : WrappedCustomEditor<MultiAimConstraint,MultiAimConstraintSaver> { }
    
    [CustomEditor(typeof(OverrideTransform),false)]
    public class OverrideTransformSEditor : WrappedCustomEditor<OverrideTransform,OverrideTransformSaver> { }
    
    [CustomEditor(typeof(MultiPositionConstraint),false)]
    public class MultiPositionConstraintSEditor : WrappedCustomEditor<MultiPositionConstraint,MultiPositionConstraintSaver> { }
    
    [CustomEditor(typeof(MultiReferentialConstraint),false)]
    public class MultiReferentialConstraintSEditor : WrappedCustomEditor<MultiReferentialConstraint,MultiReferentialConstraintSaver> { }
    
    [CustomEditor(typeof(TwistChainConstraint),false)]
    public class TwistChainConstraintSEditor : WrappedCustomEditor<TwistChainConstraint,TwistChainConstraintSaver> { }
    
    [CustomEditor(typeof(TwistCorrection),false)]
    public class TwistCorrectionSEditor : WrappedCustomEditor<TwistCorrection,TwistCorrectionSaver> { }
    
    [CustomEditor(typeof(TwoBoneIKConstraint),false)]
    public class TwoBoneIKConstraintSEditor : WrappedCustomEditor<TwoBoneIKConstraint,TwoBoneIKConstraintSaver> { }
}