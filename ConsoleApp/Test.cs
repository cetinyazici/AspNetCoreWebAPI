using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Test
    {
        public int Calc(params int[] nums)
        {
            int result = 0;
            foreach (int num in nums)
            {
                result += num;
            }
            return result;
        }

        public void SetAge(ref int age)
        {
            age += 10;
        }

        public void SetAge2(out int age)
        {
            age = 10;   
        }
    }
}
