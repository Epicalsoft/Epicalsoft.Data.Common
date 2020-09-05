using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Epicalsoft.Data.Common
{
    public abstract class Enumeration : IComparable
    {
        public string Lang { get; private set; }
        public string Name { get; private set; }
        public int Code { get; private set; }

        protected Enumeration(int code, string name, string lang)
        {
            Code = code;
            Name = name;
            Lang = lang;
        }

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null))
                .Cast<T>();
        }

        public static T Find<T>(int code, string lang) where T : Enumeration
        {
            return GetAll<T>()
                .Single(x => x.Code == code && x.Lang == lang);
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue is null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Code.Equals(otherValue.Code) && Lang.Equals(otherValue.Lang);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other) => Code.CompareTo(((Enumeration)other).Code);

        public override int GetHashCode()
        {
            return (Code + Lang).GetHashCode();
        }
    }
}