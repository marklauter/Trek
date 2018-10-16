using System;

namespace Trekish.Models.Physics
{
    public interface IMetric<T>
        where T : Enum
    {
        double Value { get; set; }
        T Units { get; set; }
    }

    public class Metric<T> : IMetric<T>
        where T : Enum
    {
        public Metric() { }

        public Metric(double value)
        {
            Value = value;
        }

        public Metric(double value, T units)
        {
            Value = value;
            Units = units;
        }

        public double Value { get; set; }
        public T Units { get; set; }

        #region operators
        public static explicit operator Metric<T>(double value)
        {
            return new Metric<T>(value);
        }

        public static explicit operator double(Metric<T> metric)
        {
            return metric.Value;
        }

        public static Metric<T> operator /(Metric<T> metric, double value)
        {
            return new Metric<T>(metric.Value / value, metric.Units);
        }

        public static Metric<T> operator *(Metric<T> metric, double value)
        {
            return new Metric<T>(metric.Value * value, metric.Units);
        }

        public static Metric<T> operator -(Metric<T> metric, double value)
        {
            return new Metric<T>(metric.Value - value, metric.Units);
        }

        public static Metric<T> operator +(Metric<T> metric, double value)
        {
            return new Metric<T>(metric.Value + value, metric.Units);
        }
        #endregion
    }
}
