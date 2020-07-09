using MoodanalyzerTest;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Mood_analyzer
{
   public class MoodanalyzerReflector
    {
          Type type = typeof(Moodanalyzer);  
       public ConstructorInfo GetConstructor(int parameters)
        {
             try
            {
                ConstructorInfo[] constructors = type.GetConstructors();
                foreach(ConstructorInfo constructor in constructors)
                {
                    if (constructor.GetParameters().Length == parameters)
                        return constructor;
                }
                return constructors[0];
            }
            catch (Exception)
            {
                throw new MoodanalyzerException(MoodanalyzerException.ExceptionType.METHOD_NOT_FOUND, "method is not found");
            }
        }

      public object CreateObject(string className, ConstructorInfo constructor, int parameters)
        {
            if (className != type.Name)
                throw new MoodanalyzerException(MoodanalyzerException.ExceptionType.CLASS_NOT_FOUND, "Class is not found");
            if(constructor != this.GetConstructor(parameters))
                throw new MoodanalyzerException(MoodanalyzerException.ExceptionType.METHOD_NOT_FOUND, "Method is not found");
            object returnObject = Activator.CreateInstance(Type.GetType("className"));
            return returnObject;
        }

        public string InvokeMoodAnalyser(String methodName, String mood)
        {
            try
            {
                MethodInfo info = type.GetMethod(methodName, new Type[] { typeof(string) });
                object instance = Activator.CreateInstance(type, mood);
                return (string)info.Invoke(instance, new String[] { mood });
            }
            catch (NullReferenceException)
            {
                throw new MoodanalyzerException(MoodanalyzerException.ExceptionType.METHOD_NOT_FOUND, "Method is not found");
            }
        }

    }

}