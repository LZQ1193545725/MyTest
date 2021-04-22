using System;
using System.Collections.Generic;
using System.Text;

namespace MyTest
{
    /// <summary>
    /// 简单的算法列子
    /// </summary>
    public class AgorithmExample
    {
        #region 冒泡排序
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr">待排序数组</param>
        /// <param name="sortType">排序方式，小到大或者大到小</param>
        public void BubbleSort(int[] arr, SortType sortType = SortType.ASC)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (sortType == SortType.ASC)
                    {
                        if (arr[i] > arr[j])
                        {
                            swap(arr, i, j);
                        }
                    }
                    else
                    {
                        if (arr[i] < arr[j])
                        {
                            swap(arr, i, j);
                        }
                    }
                }
            }
        }

        #endregion

        #region  选择排序

        /// <summary>
        ///算法步骤
        ///首先在未排序序列中找到最小（大）元素，存放到排序序列的起始位置。
        ///再从剩余未排序元素中继续寻找最小（大）元素，然后放到已排序序列的末尾。
        ///重复第二步，直到所有元素均排序完毕。
        /// </summary>
        /// <param name="arr"></param>
        public  void SelectSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                //最小值的下标
                int minValueIndex = i;
                for (int j = i; j < arr.Length - 1; j++)
                {
                    if (arr[minValueIndex] > arr[j])
                    {
                        minValueIndex = j;
                    }
                }
                if (i != minValueIndex)
                {
                    swap(arr, i, minValueIndex);
                }
            }
        }

        #endregion

        #region 插入排序

        /// <summary>
        /// 算法步骤
        /// 将第一待排序序列第一个元素看做一个有序序列，把第二个元素到最后一个元素当成是未排序序列。
        /// 从头到尾依次扫描未排序序列，将扫描到的每个元素插入有序序列的适当位置。
        ///（如果待插入的元素与有序序列中的某个元素相等，则将待插入元素插入到相等元素的后面。）
        /// </summary>
        /// <param name="arr"></param>
        public  void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                var indexValue = arr[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[j] > indexValue)
                    {
                        arr[j + 1] = arr[j];
                        arr[j] = indexValue;
                    }
                }


            }
        }

        #endregion

        /// <summary>
        /// 值交换
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="left">左下标</param>
        /// <param name="right">右下标</param>
        private  void swap(int[] arr, int left, int right)
        {
            var temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }



        #region 字符串去空格。两端空格去掉，字符串内的连续空格只保留一个

        /// <summary>
        /// 字符串去空格。两端空格去掉，字符串内的连续空格只保留一个
        /// </summary>
        /// <param name="str">待处理的字符串</param>
        /// <returns></returns>
        public string DeleteStringSpace(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return "";
            string result = "";
            string IndexStr = " ";   //空格字符串
            str = str.Trim();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].ToString() != IndexStr)
                {
                    result += str[i].ToString();
                }
                if (str[i].ToString() == IndexStr)
                {
                    if (i + 1 < str.Length && str[i].ToString() != str[i + 1].ToString())
                    {
                        result += str[i].ToString();
                    }
                }
            }

            return result;
        }

        #endregion


        #region 非零元素保持原数组的顺序   输入: nums = [0, 1, 0, 3, 12],   输出: [1, 3, 12, 0, 0].
        /// <summary>
        /// 非零元素保持原数组的顺序   输入: nums = [0, 1, 0, 3, 12],   输出: [1, 3, 12, 0, 0].
        /// </summary>
        /// <param name="nums"></param>
        public void moveZeroes(int[] nums)
        {
            if (nums == null) return;
            int startIndex = 0;    //起始位置
            int endIndex = nums.Length - 1;     //结束位置

            while (startIndex <= endIndex)
            {
                //判断第一个元素是否等于零，等于零就全体往前移一位，最后一位补零
                if (nums[startIndex] == 0)
                {
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        nums[i] = nums[i + 1];
                    }
                    nums[endIndex] = 0;
                    endIndex--;
                }
                //判断移位完第一个元素是否等于零，不能零，下标才++
                if (nums[startIndex] != 0)
                {
                    startIndex++;
                }
            }
        }

        #endregion


        #region  回文数,给你一个整数 x ，如果 x 是一个回文整数，返回 true ；否则，返回 false 。回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。例如，121 是回文，而 123 不是
        
        /// <summary>
        /// 回文数,给你一个整数 x ，如果 x 是一个回文整数，返回 true ；否则，返回 false 。回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。例如，121 是回文，而 123 不是
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            bool result = true;
            string str = x.ToString();
            int left = 0;
            int right = str.Length - 1;
            while (left < right)
            {
                if (str[left] != str[right])
                {
                    result = false;
                    break;
                }
                left++;
                right--;

            }
            return result;
        }

        #endregion


        #region  字符串中，相邻或者位置相近的字符如果相同，flag+1，比如 "abccba"  flag=3, "abcdcd" flag=0  "abccdf"  flag=1
        /// <summary>
        /// 字符串中，相邻或者位置相对相同的字符如果相同，flag+1，比如 "abccba"  flag=3, "abcdcd" flag=0  "abccdf"  flag=1
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int StringFlag(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;
            int flag = 0;
            for (int i = 0; i < str.Length; i++)
            {
                flag += (SearchSame(str, i, i + 1));
            }
            return flag;
        }
        /// <summary>
        /// 递归查找相邻的
        /// </summary>
        /// <param name="str"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="indexList"></param>
        /// <returns></returns>
        private static int SearchSame(string str, int left, int right)
        {
            if (left < 0 || right > str.Length - 1) return 0;
            else
            {

                if (str[left] == str[right])
                {

                    return SearchSame(str, left - 1, right + 1) + 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion
    }
}
