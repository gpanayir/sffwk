using System;
namespace Fwk.Logging.Targets
{
    interface ITarget
    {
        Events SearchByParam(Fwk.Logging.Event pEvent);
        Fwk.Logging.Targets.TargetType Type { get; set; }
        void Write(Fwk.Logging.Event pEvent);
    }
}
