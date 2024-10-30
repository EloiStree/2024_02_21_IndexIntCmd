using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IID
{
    public class IIMono_IndexSplitterToIntegerEvent : MonoBehaviour
    {

        public IndexToCommandEventRelay[] m_indexIntCmdToInGameElements;

        [System.Serializable]
        public class IndexToCommandEventRelay
        {
            public int m_index;
            public int m_command;
            public UnityEvent<int> m_onCommandReceived;
            public AbstractIntCmdHolderMono[] m_onCommandReceivedListener;
            public bool TryToPush(in int index, in int command)
            {
                if (m_index == index)
                {
                    if (m_command != command)
                    {
                        m_command = command;
                        m_onCommandReceived.Invoke(m_command);
                        foreach (var item in m_onCommandReceivedListener)
                        {
                            item.SetValue(command);
                        }
                    }
                    return true;
                }
                return false;
            }
        }
        public void PushIn(I_IndexIntCmdGet received)
        {

            PushIn(received.GetIndexInt(), received.GetCommandInt());
        }

        public void PushIn(int index, int command)
        {

            foreach (var item in m_indexIntCmdToInGameElements)
            {
                if (item.TryToPush(in index, in command))
                {

                    return;
                }
            }
        }

    }
}
