using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace CodeDemo
{
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

    public class Chicken
    {
        Human walkingFoodDispencer;
        int cornGrains;

        public void MakeHumanGiveFoot()
        {
            cornGrains += walkingFoodDispencer.GiveCornGrains();
        }





        Mood mood = Mood.Happy;
        
        public void MakeSound()
        {
            switch (mood)
            {
                case Mood.NONE:
                    Say("booook?");
                    break;
                case Mood.Happy:
                    Say("Tuk Tuk Tuk!");
                    break;
                case Mood.Sad:
                    Say("bo bo");
                    break;
            }
        }

        int ammountOfNeededFood = 99;
        bool isHungry;
        bool isHappy;

        public bool IsHungry(int ammountOfFood)
        {
            ammountOfNeededFood-= ammountOfFood;
            return ammountOfNeededFood < ammountOfFood;
        }

        public bool FitsInBucket(float sizeOfBucket, float sizeOfChicken)
        {
            return sizeOfBucket > sizeOfChicken;
        }

        

        public void DoSomething()
        {
            if (isHungry && isHappy)
            {
                Eat();
            }
            else if (isHungry || isHappy)
            {
                MakeSound();
            }
        }

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

        public void Walk()
        {
            
        }

        private void Eat() 
        {
            var ammountOfFoodEaten = 0;

            switch (ammountOfFoodEaten)
            {
                case 0:
                    Say("I'm so hungry");
                    break;
                case 2:
                    Say("I could get some more");
                    break;
                case > 10:
                    Say("I'm good");
                    break;
                default:
                    Say("booooook...");
                    break;
            }
        }

        public void Say(string text)
        {
        
        }

        private void Sleep() { }

        private void MakeHappySound()
        { }

        public Egg LayEgg(string nameOfEgg) 
        { 
            var newEgg = new Egg();
            newEgg.Name = nameOfEgg;
            return newEgg;
        }
    }


    public class Egg 
    {
        public string Name { get; set; }
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