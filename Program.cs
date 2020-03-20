using System;

namespace Practice_ObjectPool
{
    class Program
    {
        static void Main(string[] args)
        {
            AutomatedPicker picker1 = PickerPool.GetPicker();
            AutomatedPicker picker2 = PickerPool.GetPicker();

            picker1.Identify("Picker 1");
            picker2.Identify("Picker 2");

            picker1.GoToLocation("Slot 1");
            picker2.GoToLocation("Slot 3");

            picker1.Pick("CPU");
            picker2.Pick("RAM");

            picker1.GoToLocation("Build Room");
            picker2.GoToLocation("Build Room");
            
            picker1.Drop();
            picker2.Drop();
            
            PickerPool.ReleasePicker(picker1);
            PickerPool.ReleasePicker(picker2);
            
            AutomatedPicker picker3 = PickerPool.GetPicker();
            AutomatedPicker picker4 = PickerPool.GetPicker();
            AutomatedPicker picker5 = PickerPool.GetPicker();
            AutomatedPicker picker6 = PickerPool.GetPicker();
            AutomatedPicker picker7 = PickerPool.GetPicker();
            AutomatedPicker picker8 = PickerPool.GetPicker();
        }
    }
}
