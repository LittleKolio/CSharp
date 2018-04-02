namespace Exercise_06_Traffic_Lights
{
    using System;

    public class LightSignal
    {
        public LightSignal(Light light)
        {
            this.Light = light;
        }

        public Light Light { get; private set; }

        public void ChangeLight()
        {
            int count = Enum.GetValues(typeof(Light)).Length;
            int index = ((int)this.Light + 1) % count;
            this.Light = (Light)index;
        }
    }
}
