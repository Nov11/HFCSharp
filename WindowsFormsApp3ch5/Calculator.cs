using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp3ch5
{
    class Calculator
    {
        int numberOfPeople;
        bool healthyOption;
        bool fancyDecoration;

        public Calculator(int numberOfPeople, bool healthyOption, bool fancyDecoration)
        {
            this.NumberOfPeople = numberOfPeople;
            this.HealthyOption = healthyOption;
            this.FancyDecoration = fancyDecoration;
        }

        const decimal foodPerPerson = 25m;

        public int NumberOfPeople { get => numberOfPeople; set => numberOfPeople = value; }
        public bool HealthyOption { get => healthyOption; set => healthyOption = value; }
        public bool FancyDecoration { get => fancyDecoration; set => fancyDecoration = value; }

        decimal getFoodCost()
        {
            return NumberOfPeople * foodPerPerson;
        }

        decimal getDecorationCost()
        {
            if (FancyDecoration)
            {
                return NumberOfPeople * 15 + 50;
            }
            return NumberOfPeople * 7.5m + 30;
        }

        public decimal getTotalCost()
        {
            decimal cost = getFoodCost() + getDecorationCost();
            if (HealthyOption)
            {
                return (cost + NumberOfPeople * 5) * 0.95m;
            }

            return cost + NumberOfPeople * 20;
        }
    }
}
