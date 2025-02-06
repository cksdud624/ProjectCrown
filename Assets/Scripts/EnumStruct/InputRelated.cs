using System.Collections.Generic;

namespace ControllerRelated
{
    public struct InputInfo<T>
    {
        public T Value;
        public List<ESendTarget> SendTarget;
        public EValueTarget ValueTarget;
    }
}