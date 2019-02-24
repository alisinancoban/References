namespace Workshop
{
    class Car
    {
        private int currentSpeed;
        public int MaxSpeed { get; private set; }
        private readonly string engineCode;
        public int CurrentSpeed
        {
            get { return currentSpeed; }
            set { if (value > MaxSpeed) { } else { currentSpeed = value; } }
        }

        public Car(int maxSpeed)
        {
            MaxSpeed = maxSpeed;
        }
        public Car()
        {
            MaxSpeed = 110;
        }

        public override string ToString()
        {
            return string.Format($"[Max Speed: {MaxSpeed}; Current Speed: {CurrentSpeed}");
        }

        public override bool Equals(object obj)
        {
            if (obj is Car && obj != null)
            {
                Car temp;
                temp = (Car)obj;
                if (temp.engineCode == this.engineCode)
                {return true;}
                else{return false;}
            }
            return false;
        }
    }
}

