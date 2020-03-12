namespace Framework.Mapper
{
    using System;

    public class MapperAttribute : Attribute
    {
        private string name;

        public string Name { get { return name; } }

        public MapperAttribute(string name)
        {
            this.name = name;
        }
    }
}
