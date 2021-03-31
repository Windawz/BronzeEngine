
using System;

namespace Engine {
    internal readonly struct RuntimeValue {
        public RuntimeValue(object value) {
            Value = value;
            Type = Value.GetType();
        }

        public Type Type { get; }
        public object Value { get; }

        public T Extract<T>() {
            if (TryExtract(out T value)) {
                return value;
            } else {
                throw new InvalidOperationException(
                    $"Type {typeof(T)} cannot store a value of type {Type}");
            }
        }
        public bool TryExtract<T>(out T result) {
            if (typeof(T) == Type) {
                result = (T)Value;
                return true;
            } else {
                result = default!;
                return false;
            }
        }
    }
}
