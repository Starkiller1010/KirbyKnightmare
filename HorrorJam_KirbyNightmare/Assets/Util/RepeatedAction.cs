using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Util
{
    delegate void Action();

    class RepeatedAction
    {
        Action action;
        float intervalInSeconds;
        MonoBehaviour context;
        bool enabled = false;

        public RepeatedAction(Action action, float intervalInSeconds, MonoBehaviour context)
        {
            this.action = action;
            this.intervalInSeconds = intervalInSeconds;
            this.context = context;
        }

        public void Start()
        {
            enabled = true;
            context.StartCoroutine(DoAction());
        }

        public void Stop()
        {
            enabled = false;
        }

        private IEnumerator DoAction()
        {
            yield return new WaitForSeconds(intervalInSeconds);
            if (enabled)
            {
                context.StartCoroutine(DoAction());
                action();
            }
        }
    }
}
