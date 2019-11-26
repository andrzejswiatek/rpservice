namespace ASW.Sensors.API.DataTransfer
{
  /// <summary>Data sensor representing some device sensor</summary>
  public class Sensor : IDataTransferObject
  {
    /// <summary>Sensor identifier</summary>
    public long Id { get; set; }

    /// <summary>Name of the sensor</summary>
    public string Name { get; set; }

    /// <summary>Sensor group</summary>
    public string SensorGroup { get; set; }
  }
}