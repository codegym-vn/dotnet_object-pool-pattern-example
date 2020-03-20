using System;
using System.Collections.Generic;
namespace Practice_ObjectPool
{
    public static class PickerPool
    {
        const int PICKERCOUNT = 5;
        private static List<AutomatedPicker> available = new List<AutomatedPicker>();
        private static List<AutomatedPicker> inUse = new List<AutomatedPicker>();
        static PickerPool()
        {
            for(int i = 1; i <= PICKERCOUNT; i++)
            {
                available.Add(new AutomatedPicker(i));
            }
        }

        public static AutomatedPicker GetPicker()
        {
            lock (available)
            {
                if(available.Count > 0)
                {
                    AutomatedPicker picker = available[0];
                    inUse.Add(picker);
                    available.RemoveAt(0);
                    return picker;
                }
                else 
                throw new InvalidOperationException("No available picker");
            }
        }

        private static void Reset(AutomatedPicker picker)
        {
            if(picker.Carrying != null)
            {
                picker.Drop();
            }

            picker.GoToLocation("Recharing Location");
        }
        
        public static void ReleasePicker(AutomatedPicker picker)
        {
            Reset(picker);
            lock(available)
            {
                available.Add(picker);
                inUse.Remove(picker);
            }
        }
    }
}