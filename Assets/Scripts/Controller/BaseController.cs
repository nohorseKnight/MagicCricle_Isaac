using QFramework;
using UnityEngine;

namespace MagicCricle_Isaac
{
    public class BaseController : MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            return MagicCricle_Isaac_Context.Interface;
        }
    }
}