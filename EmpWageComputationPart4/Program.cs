using EmpWageComputationPart4;
using System;

namespace EmpWageComputationPart4
{
    class EmpWageBuilder
    {
        //Constant
        public const int IS_FULL_TIME = 1;
        public const int IS_PART_TIME = 0;

        private string company;
        private int empRatePerHour;
        private int numOfWorkingDays;
        private int maxNumOfHours;
        private int empHrsFullTime;
        private int empHrsPartTime;

        public EmpWageBuilder(string company, int empRatePerHour, int numOfWorkingDays, int maxNumOfHours, int empHrsFullTime, int empHrsPartTime)
        {
            this.company = company;
            this.empRatePerHour = empRatePerHour;
            this.numOfWorkingDays = numOfWorkingDays;
            this.maxNumOfHours = maxNumOfHours;
            this.empHrsFullTime = empHrsFullTime;
            this.empHrsPartTime = empHrsPartTime;

        }


        // Class Method
        public void CalculateWage()
        {
            Console.WriteLine("Welcome To Employee Wage Computation Program");

            //Variable
            int totalEmpWage = 0;
            int totalEmpHrs = 0;
            int totalWorkingDays = 0;
            int empHrs;
            int empWage;
            Random rand = new Random();

            //Computation
            while (totalEmpHrs <= maxNumOfHours && totalWorkingDays <= numOfWorkingDays)
            {
                totalEmpHrs++;
                totalWorkingDays++;

                int workingTime = rand.Next(0, 2);
                switch (workingTime)
                {
                    case IS_FULL_TIME:
                        empHrs = empHrsFullTime;
                        break;
                    case IS_PART_TIME:
                        empHrs = empHrsPartTime;
                        break;
                    default:
                        empHrs = 0;
                        break;
                }
                empWage = empHrs * empRatePerHour;
                totalEmpWage += empWage;
                Console.WriteLine(" Emp Daily Wage: " + empWage);
            }
            Console.WriteLine("Emp Total Wage of " + company + " is: " + totalEmpWage + " Rs");
        }

    }


    class Program 
    { 
        static void Main(string[] args)
        {
            EmpWageBuilder company1 = new EmpWageBuilder("Audi", 20, 25, 100, 8, 4);
            EmpWageBuilder company2 = new EmpWageBuilder("BMW", 25, 20, 100, 9, 2);
            EmpWageBuilder company3 = new EmpWageBuilder("Ferrari", 30, 18, 90, 7, 4);
            company1.CalculateWage();
            company2.CalculateWage();
            company3.CalculateWage();
        }

    }
}
