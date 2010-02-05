using System;
namespace AppChecker
{
    interface ICheckerBase
    {
        event CheckEven FinalizeEvent;
        event CheckEven MessageEvent;
        void Run();
        event CheckEven StartEvent;
    }
}
