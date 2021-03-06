﻿using System;
using System.Linq;

namespace Events
{
    public class Publisher
    {
        public event EventHandler<CustomEvent> RaiseCustomEvent;

        public void Greet()
        {
            OnRaiseCustomEvent(new CustomEvent("\'Hello there, stranger!\'"));
        }

        protected virtual void OnRaiseCustomEvent(CustomEvent e)
        {
            EventHandler<CustomEvent> handler = RaiseCustomEvent;

            if (handler != null)
            {
                e.Message += String.Format(" at {0}", DateTime.Now.ToString());
                handler(this, e);
            }
        }
    }
}
