using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulation2
{
    class Counter : System.Windows.Forms.Timer
    {
        int count;
        public Counter()
        {
            Interval = 100;
            base.Tick += (s, e) => {
                if (OnCount != null) OnCount(count);

                if (++count == 10)
                {
                    count = 0;
                    if (OnSecond != null)
                        OnSecond();
                }
            };
        }

        public Action<int> OnCount;
        public Action OnSecond;
    }
}
