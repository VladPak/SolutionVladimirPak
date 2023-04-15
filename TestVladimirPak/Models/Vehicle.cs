using System.Xml.Serialization;

namespace TestVladimirPak
{
    
    [XmlInclude(typeof(Car), Type = typeof(Car))]
    [XmlInclude(typeof(Bus), Type = typeof(Bus))]
    [XmlInclude(typeof(Scooter), Type = typeof(Scooter))]
    [XmlInclude(typeof(Truck), Type = typeof(Truck))]
    [Serializable]
    public class Vehicle
    {
        public int VehicleId { get; set; }
        [XmlElement]
        public Engine Engine { get; set; }
        [XmlElement]
        public Chassis Chassis { get; set; }
        [XmlElement]
        public Transmission Transmission { get; set; }
    }
}
