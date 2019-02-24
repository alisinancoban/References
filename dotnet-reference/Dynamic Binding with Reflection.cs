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
    class Program
    {
        static void Main(string[] args)
        {
            dynamic textData = "Hello";
            try
            {
                Console.WriteLine(textData.ToUpper());
                Console.WriteLine(textData.sds());
            }
            catch(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }

            var dynamicClass = new VeryDynamic();
            var num = dynamicClass.DynamicMethod("2");
            Console.WriteLine(num);

            var asm = Assembly.Load("CarLibrary");
            CreateUsingLateBinding(asm);

            AddCallMethodWithDynamic(asm);
        }

        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                Type superCar = asm.GetType("CarLibrary.SportsCar", false);
                dynamic obj = Activator.CreateInstance(superCar);
                obj.TurboBoost();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddCallMethodWithDynamic(Assembly asm)
        {
            try
            {
                Type sportsCar = asm.GetType("CarLibrary.SportsCar");
                dynamic obj = Activator.CreateInstance(sportsCar);
                obj.Accelerate(20, "pozitif"); //bu sekilde cagirinca private uyelere erisilemez.
                Console.WriteLine(obj.GetCurrentSpeed()); 
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class VeryDynamic
    {
        private static dynamic myDynamicField;
        public dynamic DynamicProperty { get; set; }

        public dynamic DynamicMethod(dynamic dynamicParam)
        {
            dynamic dynamicLocalVar = "Local Variable";
            int myInt = 10;
            if(dynamicParam is int) { return dynamicLocalVar; }
            else { return myInt; }
        }
    }
}

namespace CarLibrary
{
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
            Console.WriteLine("Ramming speed!", "Faster is better...");
        }
        public void Accelerate(int acceleration, string direction)
        {
            CurrentSpeed += acceleration;
        }
        public int GetCurrentSpeed()
        {
            return CurrentSpeed;
        }
    }
}






