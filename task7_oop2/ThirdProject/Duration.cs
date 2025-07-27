using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdProject
{
    using System;

    class Duration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public Duration()
        {
            Hours = Minutes = Seconds = 0;
        }

        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            Normalize();
        }

        public Duration(int totalSeconds)
        {
            Hours = totalSeconds / 3600;
            totalSeconds %= 3600;
            Minutes = totalSeconds / 60;
            Seconds = totalSeconds % 60;
        }

        private void Normalize()
        {
            int total = ToTotalSeconds();
            Hours = total / 3600;
            total %= 3600;
            Minutes = total / 60;
            Seconds = total % 60;
        }

        public int ToTotalSeconds() => Hours * 3600 + Minutes * 60 + Seconds;

        public override string ToString()
        {
            if (Hours > 0)
                return $"Hours: {Hours}, Minutes :{Minutes}, Seconds :{Seconds}";
            else
                return $"Minutes :{Minutes}, Seconds :{Seconds}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Duration d)
                return ToTotalSeconds() == d.ToTotalSeconds();
            return false;
        }

        public override int GetHashCode()
        {
            return ToTotalSeconds().GetHashCode();
        }
        public static Duration operator +(Duration d1, Duration d2)
        {
            return new Duration(d1.ToTotalSeconds() + d2.ToTotalSeconds());
        }

        public static Duration operator +(Duration d, int seconds)
        {
            return new Duration(d.ToTotalSeconds() + seconds);
        }

        public static Duration operator +(int seconds, Duration d)
        {
            return d + seconds;
        }

        public static Duration operator -(Duration d1, Duration d2)
        {
            return new Duration(Math.Max(0, d1.ToTotalSeconds() - d2.ToTotalSeconds()));
        }

        public static Duration operator -(Duration d, int seconds)
        {
            return new Duration(Math.Max(0, d.ToTotalSeconds() - seconds));
        }

        public static Duration operator ++(Duration d)
        {
            return new Duration(d.ToTotalSeconds() + 60);
        }

        public static Duration operator --(Duration d)
        {
            return new Duration(Math.Max(0, d.ToTotalSeconds() - 60));
        }

        public static bool operator >(Duration d1, Duration d2) => d1.ToTotalSeconds() > d2.ToTotalSeconds();
        public static bool operator <(Duration d1, Duration d2) => d1.ToTotalSeconds() < d2.ToTotalSeconds();
        public static bool operator >=(Duration d1, Duration d2) => d1.ToTotalSeconds() >= d2.ToTotalSeconds();
        public static bool operator <=(Duration d1, Duration d2) => d1.ToTotalSeconds() <= d2.ToTotalSeconds();
        public static bool operator ==(Duration d1, Duration d2) => d1.Equals(d2);
        public static bool operator !=(Duration d1, Duration d2) => !d1.Equals(d2);

        public static bool operator true(Duration d) => d.ToTotalSeconds() > 0;
        public static bool operator false(Duration d) => d.ToTotalSeconds() == 0;

        // Explicit conversion to DateTime
        public static explicit operator DateTime(Duration d)
        {
            return new DateTime(1, 1, 1, d.Hours, d.Minutes, d.Seconds);
        }
    }

}
