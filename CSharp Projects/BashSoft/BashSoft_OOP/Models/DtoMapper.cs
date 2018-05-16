namespace BashSoft_OOP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class DtoMapper<T, D>
    {
        private Dictionary<string, ParameterInfo> targetParams;
        private Dictionary<string, PropertyInfo> dtoProps;

        private object[] parameters;

        public DtoMapper()
        {
            this.InitializeTarget();
            this.InitializeDto();
        }

        Func<string, string> firstCharToLower = srt => Char.ToLower(srt[0]) + srt.Substring(1);

        private void InitializeDto()
        {
            Type typeDto = typeof(D);

            this.dtoProps = typeDto
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(p => this.firstCharToLower(p.Name), p => p);
        }

        private void InitializeTarget()
        {
            Type typeTarget = typeof(T);

            this.targetParams = typeTarget
                .GetConstructors()
                .FirstOrDefault()
                .GetParameters()
                .ToDictionary(p => p.Name, p => p);

            this.parameters = new object[this.targetParams.Count];
        }

        public T Map(D dto)
        {
            int index = 0;

            foreach (KeyValuePair<string, ParameterInfo> targetParam in this.targetParams)
            {
                if (this.dtoProps.ContainsKey(targetParam.Key))
                {
                    this.parameters[index] = this.dtoProps[targetParam.Key].GetValue(dto);
                }

                index++;
            }

            T instance = (T)Activator.CreateInstance(typeof(T), this.parameters);

            return instance;
        }
    }
}
