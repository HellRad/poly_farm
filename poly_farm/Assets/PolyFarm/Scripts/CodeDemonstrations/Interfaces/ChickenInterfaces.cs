using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace CodeDemo.Interfaces
{
    public interface IAnimal { }

    public interface ICute
    {
        int AmmountOfCuteness { get; }
        void BeCute();
    }

    public interface IRun
    {
        void Run();
    }

    public class Chicken: IAnimal, ICute, IRun
    {
        public int AmmountOfCuteness { get { return currentCuteness; } }
        int currentCuteness;

        public void BeCute() { Debug.Log("Chicken tries to be cute"); }

        public void Run() { Debug.Log("Chicken tries to run!"); }
    }

    public class Sheep : IAnimal, ICute
    {
        public int AmmountOfCuteness { get { return currentCuteness; } }
        int currentCuteness;

        public void BeCute() { Debug.Log("Chicken tries to be cute"); }
    }

    public class AnimalHusbandry
    {
        public IAnimal Animals { get; private set; }

        public void TreatAnimals(IAnimal[] animals)
        {
            foreach (var animal in animals)
            {
                switch (animal)
                {
                    case ICute cute:
                        cute.BeCute();             
                        break;
                    case IRun runner:
                        runner.Run();
                        break;
                }

                if (animal is ICute cuteAnimal)
                {
                    PetAnimal(cuteAnimal);
                }
            }
        }


        void PetAnimal(ICute animal)
        { }
        void CatchAnimal()
        { }
    }
}
