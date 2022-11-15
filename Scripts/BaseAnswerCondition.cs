using System.Threading.Tasks;
using UnityEngine;

namespace Dialogue
{
    public abstract class BaseAnswerCondition : ScriptableObject
    {
        public abstract Task<bool> IsPass();
    }
}
