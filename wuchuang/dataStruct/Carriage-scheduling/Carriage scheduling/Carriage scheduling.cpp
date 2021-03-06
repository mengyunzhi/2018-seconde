// Carriage scheduling.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
#include <string>
#include "Carriage scheduling.h"

using namespace std;
int main()
{
	Track a, b, e;
	Stack c, d;
	int status = 0;
	char x; int y = 1,z = 0;
	char in_order, out_order;
	while (cin.get() != '\n') {
		cin.unget();
		cin >> in_order;
		a.queueIn(in_order);
	}
	while (cin.get() != '\n')
	{
		cin.unget();
		cin >> out_order;
		b.queueIn(out_order);
	}
	for (;;)
	{
		while(y) {
			if (a.getHeadelem() != b.getHeadelem() && d.getTop() == -1) {
			c.push(a.queueOut());
			e.queueIn('+');
			}
			else {
				d.push(a.queueOut());
				x = b.queueOut();
				y = 0;
				e.queueIn('-');
			}
		}
		if (!b.is_Empty() && c.getTopelem() == b.getHeadelem()) {
			d.push(c.pop());
			x = b.queueOut();
			e.queueIn('*');// 3->2
		}
		else {
			if (!a.is_Empty() && a.getHeadelem() != b.getHeadelem()) {
				c.push(a.queueOut());
				e.queueIn('+');//1->3
			}
			else {
				if (!a.is_Empty() && a.getHeadelem() == b.getHeadelem()) {
					d.push(a.queueOut());
					x = b.queueOut();
					e.queueIn('-');//1->2
				}
				else {
					z = 1;
				}
			}
		}
		if (z && b.is_Empty()) {
			status = 1;
			break;
		}
		if (z && !b.is_Empty()) {
			status = 0;
			break;
		}
	}
	if (status) {
		for (; !e.is_Empty();)
		{
			char x;
			x = e.queueOut();
			if (x == '+')
				cout << "1->3" << endl;
			if (x == '-')
				cout << "1->2" << endl;
			if (x == '*')
				cout << "3->2" << endl;
		}
	}
	else {
		cout << "Are you kidding me?";
	}
	
	return 0;
}

// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门提示: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
