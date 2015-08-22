using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Safehouse
{
    public interface IObserver<T>
    {
        void Notify(T data);
    }
}
