/*
 * C����ʵ��һ���򵥵Ĳ˵�demo
 * ������Ƿ�����ʱ�״�
 * @author chenjie
 * data 2018/10/17 22:45
 */
#include <iostream>
#include <sstream>
#include <string>
using namespace std;
bool isFalse(string s) // �ж�������ַ����Ƿ��з��������ݣ�����У��򷵻�true,���򷵻�false
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
int strtingToNumber(string s) // ������������ַ���תΪ����
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
		cout << "1:����������" << endl;
		cout << "2:�˳�" << endl;
		cout << "��ѡ��:" << endl;
		cin >> option;
		switch (option)
		{
		case 1:
		{
			
			cout << "����������,����#����" << endl;
			string i;
			while (true)
			{
				getline(cin, i, '#');// �������ݸ����ַ���i��������#��ֹͣ
				if (isFalse(i))		// ����������ݷǷ����������ʾ��Ϣ����������
				{
					cout << "error,��������" << endl;
					continue;
				}
				else
				{
					int test = strtingToNumber(i);// ���ַ���ת������
					cout << test;
					break;
				}
			}
			break;
		}
		case 2: {status = false; break; }
		default: {cout << "��������" << endl; break; }
		}
	}
}