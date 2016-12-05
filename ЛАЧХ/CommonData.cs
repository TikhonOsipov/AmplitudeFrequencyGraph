using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ЛАЧХ
{
    public class CommonData
    {
        private static CommonData instance;

        double omegaStart, omegaEnd;
        int l0, l1, l2, l3, l4;
        double K, T1, T2, T3, T4, xi4;

        private CommonData()
        {
        }

        public static CommonData getInstance()
        {
            if (instance == null) instance = new CommonData();
            return instance;
        }

        public void setFields(double omegaStart, double omegaEnd, int l0, int l1, int l2, int l3,
            int l4, double T1, double T2, double T3, double T4, double xi4)
        {
            this.omegaStart = omegaStart;
            this.omegaEnd = omegaEnd;
            this.l0 = l0;
            this.l1 = l1;
            this.l2 = l2;
            this.l3 = l3;
            this.l4 = l4;
            this.T1 = T1;
            this.T2 = T2;
            this.T3 = T3;
            this.T4 = T4;
            this.xi4 = xi4;
        }

        public void setFields(double omegaStart, double omegaEnd, double K, int l0, int l1, int l2, int l3,
            int l4, double T1, double T2, double T3, double T4, double xi4)
        {
            this.omegaStart = omegaStart;
            this.omegaEnd = omegaEnd;
            this.K = K;
            this.l0 = l0;
            this.l1 = l1;
            this.l2 = l2;
            this.l3 = l3;
            this.l4 = l4;
            this.T1 = T1;
            this.T2 = T2;
            this.T3 = T3;
            this.T4 = T4;
            this.xi4 = xi4;
        }

        public double getOmegaStart() { return omegaStart; }
        public double getOmegaEnd() { return omegaEnd; }

        public double getK() { return K; }

        public double getL0() { return l0; }
        public double getL1() { return l1; }
        public double getL2() { return l2; }
        public double getL3() { return l3; }
        public double getL4() { return l4; }

        public double getT1() { return T1; }
        public double getT2() { return T2; }
        public double getT3() { return T3; }
        public double getT4() { return T4; }

        public double getXi4() { return xi4; }

    }
}
