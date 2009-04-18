using System;
namespace Fwk.Blocking
{
    /// <summary>
    /// Interfaz la las marcas de bloqueos.-
    /// </summary>
    /// <Auhor>moviedo</Auhor>
    public interface IBlockingMark
    {
        Boolean AlreadyExists { get; set; }
        DateTime? DueDate { get; }
        String Process { get; set; }
        Guid? FwkGuid { get; set; }
        Int32? BlockingId { get; set; }
        String User { get; set; }
        Int32? TTL { get; set; }
        //Int32? BlockingTime { get; set; }
        String TableName { get; }
        string Attribute { get; set; }
        string AttValue { get; set; }
    }
}
