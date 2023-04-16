using UnityEngine;
using UnityEngine.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeDemo
{
    public struct ChickenFeather
    {
        public string Name;
        public Color Color;
        public float Size;
    }

    public class Chicken: MonoBehaviour
    {
        public List<ChickenFeather> feathers = new List<ChickenFeather>();

        public ChickenFeather LooseFeather()
        {
            int randomIndex = UnityEngine.Random.Range(0, feathers.Count);
            var feather = feathers[randomIndex];
            feathers.Remove(feather);
            return feather;
        }




        //void MakeSounds(uint numberOfRepeats)
        //{
        //    int repeats = 0;

        //    do
        //    {
        //        MakeSound("Bok!");
        //        repeats++;
        //    }
        //    while (repeats < numberOfRepeats);
        //}


        //private Dictionary<string, Egg> namedEggs = new Dictionary<string, Egg>();

        //void AddNamedEggs()
        //{
        //    namedEggs.Add("Berta", new Egg());
        //    namedEggs.Add("George", new Egg());
        //}

        void MakeSound(string sound)
        { }

        //private Egg brandNewEgg;

        //public void LayEgg()
        //{
        //    brandNewEgg = new Egg("Berta");
        //    var mother = new MotherChicken() { NumerOfFeathers = 2};
        //}

        //public void LayEgg()
        //{
        //    brandNewEgg = new Egg() { Name = "Berta" };
        //}

        //public void LayEgg()
        //{
        //    var eggOriginal = new GameObject("Egg", typeof(Egg));
        //    var eggInstance = Instantiate(eggOriginal);
        //}

        //public void LayEgg()
        //{
        //    brandNewEgg = new Egg() { name = "berta" };
        //}

        private Egg[] herEggs = new Egg[] { };

        //public void LayEggs()
        //{
        //    var egg1 = new Egg();
        //    var egg2 = new Egg();
        //    herEggs = new Egg[] { egg1, egg2 };
        //}

        //private List<Egg> eggs = new List<Egg>();

        //public void PlayWithEgg()
        //{
        //    var egg = new Egg();
        //    eggs.Add(egg);
        //    eggs.Remove(egg);
        //}
    }





    public class ChickenDemo : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public class MotherChicken
    {
        public bool myPublicBool;
        private bool myPrivateBool;
        public int NumerOfFeathers { get; set; }


        public void MakeNewChicken()
        {
            var chic = new Chicken();
        }

        void DancePrivate()
        {
        }
    }

    public enum Mood
    {
        NONE,
        Happy,
        Sad
    }

    public class Human
    {
        public int GiveCornGrains()
        {
            return 3;
        }
    }

    //public class Chicken
    //{
    //    Human walkingFoodDispencer;
    //    int cornGrains;

    //    public void MakeHumanGiveFoot()
    //    {
    //        cornGrains += walkingFoodDispencer.GiveCornGrains();
    //    }





    //    Mood mood = Mood.Happy;
        
    //    public void MakeSound()
    //    {
    //        switch (mood)
    //        {
    //            case Mood.NONE:
    //                Say("booook?");
    //                break;
    //            case Mood.Happy:
    //                Say("Tuk Tuk Tuk!");
    //                break;
    //            case Mood.Sad:
    //                Say("bo bo");
    //                break;
    //        }
    //    }

    //    int ammountOfNeededFood = 99;
    //    bool isHungry;
    //    bool isHappy;

    //    public bool IsHungry(int ammountOfFood)
    //    {
    //        ammountOfNeededFood-= ammountOfFood;
    //        return ammountOfNeededFood < ammountOfFood;
    //    }

    //    public bool FitsInBucket(float sizeOfBucket, float sizeOfChicken)
    //    {
    //        return sizeOfBucket > sizeOfChicken;
    //    }

        

    //    public void DoSomething()
    //    {
    //        if (isHungry && isHappy)
    //        {
    //            Eat();
    //        }
    //        else if (isHungry || isHappy)
    //        {
    //            MakeSound();
    //        }
    //    }

        //public void DoSomething()
        //{
        //    if (isHungry)
        //    {
        //        Eat();
        //    }
        //    else if (isHappy)
        //    {
        //        MakeHappySound();
        //    }
        //    else
        //    {
        //        Sleep();
        //    }
        //}

    //    public void Walk()
    //    {
            
    //    }

    //    private void Eat() 
    //    {
    //        var ammountOfFoodEaten = 0;

    //        switch (ammountOfFoodEaten)
    //        {
    //            case 0:
    //                Say("I'm so hungry");
    //                break;
    //            case 2:
    //                Say("I could get some more");
    //                break;
    //            case > 10:
    //                Say("I'm good");
    //                break;
    //            default:
    //                Say("booooook...");
    //                break;
    //        }
    //    }

    //    public void Say(string text)
    //    {
        
    //    }

    //    private void Sleep() { }

    //    private void MakeHappySound()
    //    { }

    //    public Egg LayEgg(string nameOfEgg) 
    //    { 
    //        var newEgg = new Egg();
    //        newEgg.Name = nameOfEgg;
    //        return newEgg;
    //    }
    //}


    public class Egg
    {
        public string Name { get; set; }

        public Egg() {}

        public Egg(string name)
        {
            Name = name;
        }
    }

    public class OverChicken
    {
        public bool isFemale;
        private bool isSecretlyInLove;

        public void Dance()
        {
            DoTheWiggle();
        }

        void DoTheWiggle()
        { }
    }


    public class Attack : MonoBehaviour { }
}