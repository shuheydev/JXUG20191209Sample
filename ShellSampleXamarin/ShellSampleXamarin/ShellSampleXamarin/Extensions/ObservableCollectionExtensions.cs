using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ShellSampleXamarin.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static ObservableCollection<T> Random<T>(this ObservableCollection<T> me)
        {
            return new ObservableCollection<T>(me.OrderBy(x => Guid.NewGuid()));
        }
    }
}
