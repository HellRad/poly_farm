using UnityEngine;

namespace PerryPixelAdventure {
    public abstract class Quest : MonoBehaviour {
        public bool Started => started;
        public bool Finished => finished;
        public bool Fulfilled => fulfilled;
        public bool Succeeded => succeeded;

        protected bool started;
        protected bool finished;
        protected bool fulfilled;
        protected bool succeeded;

        public abstract void Begin();
    }
}
