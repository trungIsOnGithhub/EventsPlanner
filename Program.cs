// gRPC is the framework that is used to implement APIs using HTTP/2
// efficiently connect services across data centers, pluggable for load balancing, tracing, health checking, and authentication. 
// faster than REST and SOAP
using System;
using System.Diagnostics.CodeAnalysis;

namespace Application
{
    class Option<T> where T : notnull
    {
        public static Option<T> None() => default;
        public static Option<T> Some(T value) => new Option<T>(value);

        readonly T value;
        readonly bool isSome;

        internal Option(T value)
        {
            this.value = value;
            this.isSome = this.value is T;
        }

        public bool IsSome(out T value)
        {
            value = this.value;
            return this.isSome;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Option<string> optionObject  = new (null);

            if (optionObject.IsSome(out var str1))
            {
                Console.WriteLine(str1);
            }
            else
            {
                Console.WriteLine(Option<string>.None());
            }
        }
    }
}
