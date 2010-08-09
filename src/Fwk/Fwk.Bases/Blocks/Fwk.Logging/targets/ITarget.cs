using System;
namespace Fwk.Logging.Targets
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITarget
    {
        Events SearchByParam(Fwk.Logging.Event pEvent);
        Fwk.Logging.Targets.TargetType Type { get; set; }
        void Write(Fwk.Logging.Event pEvent);
        Events SearchByParam(Fwk.Logging.Event pEvent, DateTime pEndDate);
    }
}
