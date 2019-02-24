using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Linq;
using System.Text;
using System.IO;

namespace Workshop
{
    /// <summary>
    /// Summary:
    ///      Now, before you run this application, you will need to manually place a copy of CarLibrary.dll into
    ///       the bin\Debug folder of this new application using Windows Explorer.The reason is that you are calling
    ///       Assembly.Load() and, therefore, the CLR will probe only in the client folder(if you want, you could enter a
    ///       path to the assembly using Assembly.LoadFrom(); however, there is no need to do so).
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Late Binding *****");
            Assembly assembly = null;
            try
            {
                assembly = Assembly.Load("CarLibrary");
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            if (assembly != null)
                CreateUsingLateBinding(assembly);
           
        }
        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                Type car = asm.GetType("CarLibrary.SportsCar");
                object oSportsCar = Activator.CreateInstance(car);
                Console.WriteLine($"Created a {oSportsCar} using late binding");

                //Cast to get access to the members of MiniVan?
                //Compiler error!
                //object obj = (SportsCar)Activator.CreateInstance(car);
				
				//You can access all method public,private...
                MethodInfo methodInfoParameterless = car.GetMethod("TurboBoost"); //invoking parameterless method
                methodInfoParameterless.Invoke(oSportsCar, null);

                MethodInfo methodInfo = car.GetMethod("Accelerate"); //invoking method
                methodInfo.Invoke(oSportsCar, new object[] {20});

                MethodInfo methodInfoReturnValue = car.GetMethod("GetCurrentSpeed"); //invoking method
                Console.WriteLine(methodInfoReturnValue.Invoke(oSportsCar, null));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
           
    }
    /* These are in CarLibrary.dll
    public enum EngineState
    { engineAlive, engineDead }
    // The abstract base class in the hierarchy.
    public abstract class Car
    {
        public string serieNumber;
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        protected EngineState egnState = EngineState.engineAlive;
        public EngineState EngineState
        {
            get { return egnState; }
        }
        public abstract void TurboBoost();

        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            PetName = name; MaxSpeed = maxSp; CurrentSpeed = currSp;
        }
    }
    public class SportsCar : Car
    {
        public SportsCar() { }
        public SportsCar(string name, int maxSp, int currSp)
        : base(name, maxSp, currSp) { }
        public override void TurboBoost()
        {
            MessageBox.Show("Ramming speed!", "Faster is better...");
        }
        public void Accelerate(int acceleration)
        {
            CurrentSpeed += acceleration;
        }
        public int GetCurrentSpeed()
        {
            return CurrentSpeed;
        }



    }*/
}






