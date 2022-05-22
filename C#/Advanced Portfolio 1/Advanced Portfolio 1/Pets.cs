using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced_Portfolio_1
{
    class Pets
    {
        private string Petname;
        private int Petage;
        private double Petweight;
        private int Types;

        public Pets(String petname, int petage, double petweight,int types)
        {
            Petname = petname;
            Petage = petage;
            Petweight = petweight;
            Types = types;
        }

       
        public string GetPetname()
        {
            return Petname;
        }

        public int GetPetage()
        {
            return Petage;
        }
        public double GetPetweight()
        {
            return Petweight;
        }

        public int GetTypes()
        {
            return Types;
        }


        public void SetPetname(string petname)
        {
            Petname = petname;
        }

        public void SetPetage(int petage)
        {
            Petage = petage;
        }

        public void SetPetweight(double petweight)
        {
            Petweight = petweight;
        }

        public void SetTypes(int types)
        {
            Types = types;
        }

    }
}
