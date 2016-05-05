using System;
using LoggerAspect;
using LoggerAspect.Enums;

namespace InstrumentationPostSharp
{
    [LoggingAspect(Exclude = ExclusionFlags.None  )]
    class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int CalculateYears()
        {
            return CalculateYearsFromDate(DateOfBirth);
        }

        bool CanDrinkAlcohool()
        {
            return CalculateYears() > 17;
        }

        public void Drink(int beersNumber, int vodkaNumber)
        {
            bool haveADrink = beersNumber >= 0 || vodkaNumber >= 0;
            if(haveADrink && !CanDrinkAlcohool())
                throw new ArgumentException("can not drink alcohol");
        }
        static int CalculateYearsFromDate(DateTime dt)
        {
            return (int)(DateTime.Now.Subtract(dt).TotalDays/365);
        }
    }
}