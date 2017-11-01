

using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    public class RAND //pbrt 
    {
        private const UInt32 MATRIX_A = 0x9908b0dfU;
        private const UInt32 UPPER_MASK = 0x80000000U;
        private const UInt32 LOWER_MASK = 0x7fffffffU;
        private const int M = 397;

        private const int N = 624;
        public RAND(UInt32 seed = 5489U)
        {
            mt = new UInt32[N];
            mti = N + 1;

        }

        public void Seed(UInt32 seed)
        {
            mt[0] = seed & 0xffffffffU;
            for (mti = 1; mti < N; mti++)
            {
                mt[mti] =
                (UInt32)(1812433253U * (mt[mti - 1] ^ (mt[mti - 1] >> 30)) + mti);
                /* See Knuth TAOCP Vol2. 3rd Ed. P.106 for multiplier. */
                /* In the previous versions, MSBs of the seed affect   */
                /* only MSBs of the array mt[].                        */
                /* 2002/01/09 modified by Makoto Matsumoto             */
                mt[mti] &= 0xffffffffU;
                /* for >32 bit machines */
            }
        }

        public float RandomFloat()
        {
            float v = (RandomUInt() & 0xffffff) / (1 << 24);
            return v;
        }

        UInt32 RandomUInt()
        {
            UInt32 y;

            UInt32[] mag01 = new UInt32[2];
            mag01[0] = 0x0u;
            mag01[1] = MATRIX_A;//0x0U, MATRIX_A };
            /* mag01[x] = x * MATRIX_A  for x=0,1 */

            if (mti >= N)
            { /* generate N words at one time */
               
                int kk;

                if (mti == N + 1)   /* if Seed() has not been called, */
                    Seed(5489U); /* default initial seed */

                for (kk = 0; kk < N - M; kk++)
                {
                    y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
                    mt[kk] = mt[kk + M] ^ (y >> 1) ^ mag01[y & 0x1UL];
                }
                for (; kk < N - 1; kk++)
                {
                    y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
                    mt[kk] = mt[kk + (M - N)] ^ (y >> 1) ^ mag01[y & 0x1UL];
                }
                y = (mt[N - 1] & UPPER_MASK) | (mt[0] & LOWER_MASK);
                mt[N - 1] = mt[M - 1] ^ (y >> 1) ^ mag01[y & 0x1UL];

                mti = 0;
              
            }

            y = mt[mti++];

            /* Tempering */
            y ^= (y >> 11);
            y ^= (y << 7) & 0x9d2c5680U;
            y ^= (y << 15) & 0xefc60000U;
            y ^= (y >> 18);

            return y;
        }

       
        private UInt32[] mt;
        int mti;
    }
}
