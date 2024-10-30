using UnityEngine.Events;

namespace Eloi.IID
{
    public static class IndexIntCmdUnityEvent
{
    [System.Serializable]
    public class InterfaceGet : UnityEvent<I_IndexIntCmdGet> { }

    [System.Serializable]
    public class InterfaceGetSet : UnityEvent<I_IndexIntCmdSetGet> { }

        [System.Serializable]
        public class Integer : UnityEvent<int> { }
        [System.Serializable]
        public class IndexInteger : UnityEvent<int,int> { }
    }

}