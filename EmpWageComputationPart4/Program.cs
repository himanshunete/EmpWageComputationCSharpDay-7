using EmpWageComputationPart4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EmpWageComputationPart4
{

    interface ICompanyEmpWage
    {
        public void AddCompanyWage(string company, int empRatePerHour, int numOfWorkingDays, int maxNumOfHours, int empHrsFullTime, int empHrsPartTime);
        public void ComputeWage();
    }
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

    class EmpWageBuilder : ICompanyEmpWage
    {
        //Constant
        public const int IS_FULL_TIME = 1;
        public const int IS_PART_TIME = 0;


        ArrayList companyEmpWageList;
        Dictionary<string, CompanyEmpWage> companyEmpWageMap;

        public EmpWageBuilder()
        {
            companyEmpWageList = new ArrayList();
            companyEmpWageMap = new Dictionary<string, CompanyEmpWage>();
        }

        public void AddCompanyWage(string company, int empRatePerHour, int numOfWorkingDays, int maxNumOfHours, int empHrsFullTime, int empHrsPartTime)
        {
            CompanyEmpWage companyEmpWage = new CompanyEmpWage(company, empRatePerHour, numOfWorkingDays, maxNumOfHours, empHrsFullTime, empHrsPartTime);
            companyEmpWageList.Add(companyEmpWage);
            companyEmpWageMap.Add(company, companyEmpWage);
        }

        public void ComputeWage()
        {
            for (int i = 0; i < companyEmpWageList.Count; i++)
            {
                CompanyEmpWage companyEmpWage = (CompanyEmpWage)companyEmpWageList[i];
                companyEmpWage.setTotalEmpWage(this.CalculateWage(companyEmpWage));
                Console.WriteLine(companyEmpWage);
            }
        }

        public int CalculateWage(CompanyEmpWage companyEmpWage)
        {
            Console.WriteLine("Welcome To Employee Wage Computation Program");

            //Variable
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
                companyEmpWage.totalEmpWage += empWage;
                Console.WriteLine(" Emp Daily Wage: " + empWage);
            }
            return companyEmpWage.totalEmpWage;
        }

    }

    class Program 
    { 
        static void Main(string[] args)
        {
            EmpWageBuilder empWageBuilder = new EmpWageBuilder();
            empWageBuilder.AddCompanyWage("Audi", 20, 25, 100, 8, 4);
            empWageBuilder.AddCompanyWage("BMW", 25, 20, 100, 9, 2);
            empWageBuilder.AddCompanyWage("Ferrari", 30, 18, 90, 7, 4);
            empWageBuilder.ComputeWage();
        }

    }
}
