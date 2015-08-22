using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Safehouse
{
    public interface IObservable<T>
    {
        void Subscribe(IObserver<T> observer);

        void DetatchObserver(IObserver<T> observer);
    }
}
