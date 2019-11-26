namespace ASW.Sensors.API.DataTransfer
{
  /// <summary>Class representing sensor value</summary>
  public class SensorValue : IDataTransferObject
  {    
    /// <summary>Sensor reference </summary>
    public string Name { get; set; }

    /// <summary>Sensor value</summary>
    public decimal Value { get; set; }
  }
}