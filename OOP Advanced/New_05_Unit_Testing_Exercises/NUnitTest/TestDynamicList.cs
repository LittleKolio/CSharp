using Exercise_08_Custom_Linked_List;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest
{
    [TestFixture]
    public class TestDynamicList
    {

        [Test]
        public void Add_CreateNode()
        {
            //Arrange
            int[] nums = { 1, 0, int.MinValue, int.MaxValue, 3532, -456453, 5};
            DynamicList<int> list = new DynamicList<int>();

            //Act
            for (int i = 0; i < nums.Length; i++)
            {
                list.Add(nums[i]);
            }

            //Type type = typeof(DynamicList<int>).cla

            FieldInfo current = typeof(DynamicList<int>)
                .GetField("head", BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo prev = null;

            while (current != null)
            {
                prev = current;
                current = current.FieldType
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .First(f => f.FieldType == current.FieldType);
            }
            //Assert

        }
    }
}
