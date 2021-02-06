using EmpWageComputationPart4;
using System;

namespace EmpWageComputationPart4
{
    class CompanyEmpWage
    {
        public string company;
        public int empRatePerHour;
        public int numOfWorkingDays;
        public int maxNumOfHours;
        public int empHrsFullTime;
        public int empHrsPartTime;
        public int totalEmpWage;

        public CompanyEmpWage(string company, int empRatePerHour, int numOfWorkingDays, int maxNumOfHours, int empHrsFullTime, int empHrsPartTime)
        {
            this.company = company;
            this.empRatePerHour = empRatePerHour;
            this.numOfWorkingDays = numOfWorkingDays;
            this.maxNumOfHours = maxNumOfHours;
            this.empHrsFullTime = empHrsFullTime;
            this.empHrsPartTime = empHrsPartTime;

        }
        public void setTotalEmpWage(int totalEmpWage)
        {
            this.totalEmpWage = totalEmpWage;
        }
        public String toString()
        {
            return "Total Emp Wage for Company: " + company + " is: " + totalEmpWage;
        }


    }

    class EmpWageBuilder
    {
        //Constant
        public const int IS_FULL_TIME = 1;
        public const int IS_PART_TIME = 0;

        int numOfCompany = 0;
        CompanyEmpWage[] companyEmpWageArray;
        
        public EmpWageBuilder()
        {
            companyEmpWageArray = new CompanyEmpWage[3];
        }

        public void AddCompany(string company, int empRatePerHour, int numOfWorkingDays, int maxNumOfHours, int empHrsFullTime, int empHrsPartTime)
        {
            companyEmpWageArray[numOfCompany] = new CompanyEmpWage(company, empRatePerHour, numOfWorkingDays, maxNumOfHours, empHrsFullTime, empHrsPartTime);
            numOfCompany++;
        }

        public void ComputeWage()
        {
            for (int i = 0; i < numOfCompany; i++)
            {
                companyEmpWageArray[i].setTotalEmpWage(this.CalculateWage(companyEmpWageArray[i]));
                Console.WriteLine(companyEmpWageArray[i]);
            }
        }

        public int CalculateWage(CompanyEmpWage companyEmpWage)
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
            while (totalEmpHrs <= companyEmpWage.maxNumOfHours && totalWorkingDays <= companyEmpWage.numOfWorkingDays)
            {
                totalEmpHrs++;
                totalWorkingDays++;

                int workingTime = rand.Next(0, 2);
                switch (workingTime)
                {
                    case IS_FULL_TIME:
                        empHrs = companyEmpWage.empHrsFullTime;
                        break;
                    case IS_PART_TIME:
                        empHrs = companyEmpWage.empHrsPartTime;
                        break;
                    default:
                        empHrs = 0;
                        break;
                }
                empWage = empHrs * companyEmpWage.empRatePerHour;
                totalEmpWage += empWage;
                Console.WriteLine(" Emp Daily Wage: " + empWage);
            }
            return totalEmpWage;
        }

    }

    class Program 
    { 
        static void Main(string[] args)
        {
            EmpWageBuilder empWageBuilder = new EmpWageBuilder();
            empWageBuilder.AddCompany("Audi", 20, 25, 100, 8, 4);
            empWageBuilder.AddCompany("BMW", 25, 20, 100, 9, 2);
            empWageBuilder.AddCompany("Ferrari", 30, 18, 90, 7, 4);
            empWageBuilder.ComputeWage();
        }

    }
}
