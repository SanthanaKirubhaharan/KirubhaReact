// JsonInterfaceSerializer.cs

namespace DotNet8Features
{
    public interface ICar
    {
        public string? Brand { get; set; }
    }

    public interface ISedan : ICar
    {
        public string? Model { get; set; }
    }

    public class CarDetails : ISedan
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
    }
}
