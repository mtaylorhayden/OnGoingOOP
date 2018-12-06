using System.Collections.Generic;
using System;

namespace _1._4_House_Lab
{
    public class House
    {
        private List<IWashable> washables = new List<IWashable>();

        public House()
        {
            this.washables.Add(new PickleJar());

            this.washables.Add(new GlassWindow());
            this.washables.Add(new GlassWindow());
            this.washables.Add(new GlassWindow());
            this.washables.Add(new GlassWindow());

            this.washables.Add(new Door());
            this.washables.Add(new Door());
            this.washables.Add(new Door());
        }

        public void Wash()
        {
            // For each IWashable in the washables list.
            foreach(IWashable w in washables)
            {
                if(w is ILockable)
                {
                    (w as ILockable).Unlock();
                }

                // If the item in the washables list is a IOpenable..
                if(w is IOpenable)
                {
                    // Cast the list item as an Iopenable and open the item.
                    (w as IOpenable).Open();
                }

                w.Wash();

                if(w is IOpenable)
                {
                    (w as IOpenable).Close();
                }

            }
            
        }
    }
}