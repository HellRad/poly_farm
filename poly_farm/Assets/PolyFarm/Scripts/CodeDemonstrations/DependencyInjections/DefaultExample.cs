namespace CodeDemonstrations.DependencyInjections
{
    public class Mommy
    {
        void SpawnChick()
        {
            var chick = new Chick(this);
        }
        public void Hug(){ }
    }

    public class Chick
    {
        Mommy mommy;
        public Chick(Mommy mom)
        {
            mommy = mom;
        }
        void HugMom()
        {
            mommy.Hug();
        }
    }
}
