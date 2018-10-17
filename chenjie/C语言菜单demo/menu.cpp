/*
 * C语言实现一个简单的菜单demo
 * 当输入非法内容时抛错
 * @author chenjie
 * data 2018/10/17 22:45
 */
#include <iostream>
#include <sstream>
#include <string>
using namespace std;
bool isFalse(string s) // 判断输入的字符串是否有非数字内容，如果有，则返回true,否则返回false
{
	for (int i = 1; i < s.size(); i++)
	{
		if (s[i] < '0' || s[i] > '9')
		{
			return true;
		}
	}
	return false;
}
int strtingToNumber(string s) // 将传入的数字字符串转为数字
{
	stringstream ss;
	ss << s;
	int a;
	ss >> a;
	return a;
}
int main()
{
	bool status = true;
	while (status)
	{
		int option;
		cout << endl;
		cout << "1:请输入数字" << endl;
		cout << "2:退出" << endl;
		cout << "请选择:" << endl;
		cin >> option;
		switch (option)
		{
		case 1:
		{
			
			cout << "请输入数字,输入#结束" << endl;
			string i;
			while (true)
			{
				getline(cin, i, '#');// 输入内容赋给字符串i，当遇到#则停止
				if (isFalse(i))		// 如果输入内容非法，则输出提示信息，重新输入
				{
					cout << "error,重新输入" << endl;
					continue;
				}
				else
				{
					int test = strtingToNumber(i);// 将字符串转成数字
					cout << test;
					break;
				}
			}
			break;
		}
		case 2: {status = false; break; }
		default: {cout << "输入有误" << endl; break; }
		}
	}
}