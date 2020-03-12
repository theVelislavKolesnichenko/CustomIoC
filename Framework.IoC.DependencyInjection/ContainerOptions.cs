namespace Framework.IoC.DependencyInjection
{
    using System;

    [Flags]
    public enum ContainerOptions
    {
        None = 0,
        UseDefaultValue = 1,
        UseTestValue = 2,
        UseAlternativeValue = 3
    }
}
