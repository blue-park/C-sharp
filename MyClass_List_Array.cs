﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication_MyLibs
{
    class MyClass_List_Array
    {
        public List<int> CreatList ()
        {
            List<int> sub_table2 = new List<int>();//(sub_table);
            return sub_table2;
        }
        public void ClearList(List<int>input)
        {
            input.Clear();
        }
        public void AddToList(List<int> input, int data)
        {
            input.Add(data);
        }
        public void sortList(List <int>inputListData)
        {
            // 오름차순 정렬
            inputListData.Sort();

        }
        public int GetMaxFromList(List<List<int>> temp)
        {
            //List<List<int>> temp = GetTemp(inputData);
            // 내림차순 정렬 후 첫번째 리스트 겟
            int result = temp.OrderByDescending(x => x.Count())
                        .FirstOrDefault<List<int>>()[0];
            return result;
        }
        public List<List<int>> ParseAndConvertExample(string inputData)
        {
            {
                string[] arrInput = inputData.Split('#');

                List<int> listInput = new List<int>();

                for (int i = 0; i < arrInput.Length; i++)
                {
                    listInput.Add(int.Parse(arrInput[i]));
                }

                //오름차순 정렬
                listInput.Sort();

                //자리수별로 배치
                List<List<int>> temp = new List<List<int>>();

                //10의 자리수
                int dec = 0;
                List<int> temp2 = null;
                for (int i = 0; i < listInput.Count; i++)
                {
                    if (i == 0)
                    {
                        temp2 = new List<int>();

                        dec = listInput[i] / 10;

                        //첫번째 입력이면 십의 자리 넣고 일의 자리로 넣고
                        //두번째 부터는 1의 자리
                        if (temp2.Count == 0)
                        {
                            temp2.Add(dec);
                            temp2.Add(listInput[i] % 10);
                        }
                        else
                        {
                            temp2.Add(listInput[i] % 10);
                        }
                    }
                    else
                    {
                        //같은 자리수 인지 비교
                        if (dec == listInput[i] / 10)
                        {
                            temp2.Add(listInput[i] % 10);
                        }
                        else
                        {
                            //다를때 => 자리수가 변경
                            //지금까지 작업한 temp2 를 temp 에 추가
                            temp.Add(temp2);

                            //새로 temp2 시작
                            temp2 = new List<int>();
                            dec = listInput[i] / 10;
                            temp2.Add(dec);
                            temp2.Add(listInput[i] % 10);
                        }
                    }
                }

                temp.Add(temp2);

                return temp;
            }
        }

    }
}
