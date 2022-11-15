using UnityEngine;

namespace Dialogue
{
    public abstract class BaseAnswerCondition : ScriptableObject
    {
        public abstract bool IsPass();
    }
}
